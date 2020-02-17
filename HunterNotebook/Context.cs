using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using IWshRuntimeLibrary;
using System.Reflection;
namespace HunterNotebook
{
    public class ContextFile
    {
        public string CurrentFile;
        public bool HasChanged;
        /// <summary>
        /// file either has been written to disk once or laoaded from disk
        /// </summary>
        public bool FileExists;

        public SupportedFileHandleFormats Format { get; set; }

        public DateTime ModifiedTime;
        /*
        Task<bool> TrackModifiedTime()
        {
            FileInfo fn;
            while (true)
            {
                fn = new FileInfo(CurrentFile);
                if (fn.LastWriteTime != ModifiedTime)
                {
                    
                }
            }
        }
        */



        /// <summary>
        /// do the mainWindow title update
        /// </summary>
        /// <param name="main"></param>
        public void UpdateContextTitle(mainWindow main)
        {
            string general = "notebook{0} ({2})-- {1}";
            string change;
            string formatContext;
            if (HasChanged)
            {
                change = "*";
            }
            else
            {
                change = string.Empty;
            }
            if (string.IsNullOrEmpty(CurrentFile))
            {
                CurrentFile = "untitled.txt";
            }
            if (Format == SupportedFileHandleFormats.Unknown)
            {
                formatContext = string.Empty;
            }
            else
            {
                switch (Format)
                {
                    case SupportedFileHandleFormats.ZippedTrackPlain:
                        formatContext = "Tracked Change Unicode Text"; break;
                    case SupportedFileHandleFormats.TextUnicodeRTF:
                        formatContext = "Unicode Rich Text"; break;
                    case SupportedFileHandleFormats.TextUnicodePlain:
                        formatContext = "Unicode Text"; break;
                    case SupportedFileHandleFormats.TextAnsiRTF:
                        formatContext = "Ansi RTF"; break;
                    default: formatContext = "(No Context)"; break;
                }

            }
            main.Text = string.Format(general, change, CurrentFile, formatContext);
        }
    }

    public class ContextSetting
    {
        /// <summary>
        /// The Word Wrap Flag
        /// </summary>
        public bool WordWrap=false;
        /// <summary>
        /// Save to desktop as file if shutdown. This will overread other files
        /// </summary>
        public bool ShutdownAutoSave=false;
        /// <summary>
        /// When the user signs in. Auto Reload 
        /// </summary>
        public bool AutoLoadSignIn=false;
        /// <summary>
        /// If the file's date modified (if it exists) offert to reload
        /// </summary>
        public bool AutoReloadOnChange=false;
        /// <summary>
        /// if true then the window is set to be on top of most other windows
        /// </summary>
        public bool AlwaysOnTop;

        /// <summary>
        /// set the main window opacity
        /// </summary>
        public double Opacity = 1;

        public float PreferredZoom = 1.0f;
        /// <summary>
        /// return a font class instance make from Style, FontName and FontSize
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute]
        public Font LevelFont
        {
            get
            {
                var ret = new Font(FontName, FontSize, Style);
                
                return ret;
            }
            set
            {
                Style = value.Style;
                FontName = value.Name;
                FontSize = value.Size;
            }
        }

        public bool AllowReceiveTextByDrag;
        public bool AllowGiveTextByDrag;

        /// <summary>
        /// the tr
        /// </summary>
        public FontStyle Style = FontStyle.Regular;
        public string FontName = "Times New Roman";
        public float FontSize = 12;


        private string GetShortcutPath()
        {
            StringBuilder ret = new StringBuilder();
            ret.Append(Assembly.GetExecutingAssembly().Location);
            ret.Append("  \"");
            ret.Append(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            ret.Append("\\Reload.txt");
            return ret.ToString();
        }
        public void SaveShortcut(string pointer, string target)
        {
            var linkme = new WshShell();
            try
            {
                IWshShortcut point = linkme.CreateShortcut(pointer + ".lnk");
                {
                    point.TargetPath = target;
                    point.Save();
                }

            }
            finally
            {
                // I QUIT
            }

            
        }
      



       
        public static ContextSetting LoadFromFile(string name)
        {
            using (var fn = System.IO.File.Open(name, FileMode.Open))
            {
                var Serial = new XmlSerializer(typeof(ContextSetting));
                return (ContextSetting)Serial.Deserialize(fn);
            }
        }

        public void SaveToFile(string name)
        {
            SaveToFile(this, name);
        }
        public static void SaveToFile(ContextSetting that, string Name)
        {
            
            {
                using (var fn = System.IO.File.Open(Name, FileMode.Create))
                {
                    var Serial = new XmlSerializer(typeof(ContextSetting));
                    Serial.Serialize(fn, that);
                    fn.Flush();
                }
            }
            
        }
    }

}
