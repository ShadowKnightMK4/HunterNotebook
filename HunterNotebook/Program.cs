using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HunterNotebook
{
    static class Program
    {

        static bool DisableConfigLoad = false;
        static string TargetFile = string.Empty;
        static SupportedFileHandleFormats Format = SupportedFileHandleFormats.Unknown;

        static bool BadCommand = false;
        static void HandleArgs()
        {
            var cmds = Environment.GetCommandLineArgs();
             for (int step =1; step < cmds.Length; step++)
            {
                switch (cmds[step].ToLower())
                {
                    case "-noconfig":
                        DisableConfigLoad = true;
                        break;
                    case "-shortcut":
                        {
                            // remote the shortcut 
                            FileHandling.DeleteAutoShortcut();
                            break; 
                        }
                    case "-load":
                        if (cmds.Length-step >= 3)
                        {
                            step++;
                            switch (cmds[step].ToLower())
                            {
                                case "ansi":
                                    Format = SupportedFileHandleFormats.TextAnsiPlain;
                                    TargetFile = cmds[step];
                                    break;
                                case "unicode":
                                    Format = SupportedFileHandleFormats.TextUnicodePlain;
                                    TargetFile = cmds[step];
                                    break;
                                case "rtf":
                                    Format = SupportedFileHandleFormats.TextUnicodeRTF;
                                    TargetFile = cmds[step];
                                    break;
                                case "tdb":
                                    Format = SupportedFileHandleFormats.ZippedTrackPlain;
                                    TargetFile = cmds[step];
                                    break;
                                default:
                                    TargetFile = cmds[step];
                                    break;
                            }
                            step++;
                        }
                        else
                        {
                            TargetFile = cmds[step];
                            return;
                        }
                        break;
                    default:
                        TargetFile = cmds[step];
                        Format = SupportedFileHandleFormats.Unknown;
                        return;
                }

            }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            HandleArgs();
            if (!BadCommand)
            {

                using (var MainForm = new mainWindow())
                {
                    MainForm.DisableConfigLoad = DisableConfigLoad;
                
                    FileHandling.TargetWindow = MainForm;
                    MainForm.Text = "Hunter's Notebook";
                    if (string.IsNullOrWhiteSpace(TargetFile ) == false)
                    {
                        if (Format == SupportedFileHandleFormats.Unknown)
                        {
                            var BESTGUESS = FileHandling.IsFileUnicode(TargetFile);
                            if (BESTGUESS == false)
                            {
                                Format
                                     = SupportedFileHandleFormats.TextAnsiPlain;
                            }
                            else
                            {
                                Format = SupportedFileHandleFormats.TextUnicodePlain;
                            }
                        }

                        if (Format != SupportedFileHandleFormats.Unknown)
                        {
                            FileHandling.FileLoad(FileHandling.GetHandlerClassInstance(Format), TargetFile, Format);
                            
                        }
                        else
                        {
                            MessageBox.Show("Unable to detect " + TargetFile + "'s encoding. Please Specific a format when loaded (use -load FORMAT \"Target\")");
                        }
                    }
                    
                    Application.Run(MainForm);
                }
            }
            else
            {
                StringBuilder err = new StringBuilder();
                foreach (string s in Environment.GetCommandLineArgs())
                {
                    err.AppendLine(s);
                }
                MessageBox.Show(err.ToString(), "Invalid Command Arg", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Application.Run();
        }
    }
}
