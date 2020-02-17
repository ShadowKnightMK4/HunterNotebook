using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;
namespace HunterNotebook
{
    /*
     * 
     */
    public partial class mainWindow : Form
    {

        public mainWindow()
        {
            InitializeComponent();
            FileHandling.TargetWindow = this;
        }

        #region local shit
          public  ContextFile CurrentFile = new ContextFile();
          public ContextSetting CurrentSettings = new ContextSetting();

        /// <summary>
        /// Set before first shown. turns of the config load
        /// </summary>
        public bool DisableConfigLoad = false;
        #endregion

        

        private void MainWindow_LocationChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// update the GUI and apply shit as needed
        /// </summary>
        private void ImplementCurrentSettings()
        {
            alwaysOnTopToolStripMenuItem.Checked = CurrentSettings.AlwaysOnTop;
            wordWrapToolStripMenuItem.Checked = CurrentSettings.WordWrap;
            saveToDesktopToolStripMenuItem.Checked = CurrentSettings.ShutdownAutoSave;
            ReloadOnSignInToolStripMenuItem.Checked = CurrentSettings.AutoLoadSignIn;
            reloadOnChangeToolStripMenuItem.Checked = CurrentSettings.AutoReloadOnChange;
            
            
            AllowReceiveTextToolStripMenuItem.Checked = CurrentSettings.AllowReceiveTextByDrag;
            AllowGiveTextToolStripMenuItem.Checked = CurrentSettings.AllowGiveTextByDrag ;

            Opacity = CurrentSettings.Opacity;
            if (Opacity != 1)
            {
                makeTransparentToolStripMenuItem.Checked = true;
            }
            else
            {
                makeTransparentToolStripMenuItem.Checked = false;
            }

            


        }

        /// <summary>
        /// return the name of the default non debug config file
        /// </summary>
        /// <returns></returns>
        private string DefaultConfigName()
        {
            return "Hunternotebook.xml";
        }


        /// <summary>
        /// return the name of the default debug config file
        /// </summary>
        /// <returns></returns>
        private string DebugConfigName()
        {
            return "HunterNotebookDebug.xml";
        }

        /// <summary>
        /// return the save and load location of the runtime config file
        /// </summary>
        /// <returns></returns>
        private string GetUserConfigFileLocation()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), DefaultConfigName());
        }


#if DEBUG
        /// <summary>
        /// used in debug only. Returns the prefered debug config file location
        /// </summary>
        /// <returns></returns>
        private string GetUserDebugConfigFileLocation()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), DebugConfigName());
        }
#endif
        private void MainWindow_Load(object sender, EventArgs e)
        {
            if (!DisableConfigLoad)
            {

#if DEBUG
                if (File.Exists(GetUserDebugConfigFileLocation()))
                {
                    CurrentSettings = ContextSetting.LoadFromFile(GetUserDebugConfigFileLocation());
                    File.Delete(GetUserDebugConfigFileLocation());
                }
                else
                {
                    if (File.Exists(GetUserConfigFileLocation()))
                    {
                        CurrentSettings = ContextSetting.LoadFromFile(GetUserConfigFileLocation());
                    }
                    else
                    {
                        CurrentSettings = new ContextSetting(); // hard coded feauled
                    }
                }

#else
            CurrentSettings = ContextSetting.LoadFromFile(GetUserConfigFileLocation());

            if (File.Exists(GetUserConfigFileLocation()))
            {
                CurrentSettings = ContextSetting.LoadFromFile(GetUserConfigFileLocation());
            }
            else
            {
                CurrentSettings = new ContextSetting(); // hard coded feauled
            }
#endif

            }
            ImplementCurrentSettings();
        }

        private void AboutThisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (AboutApp aboutme = new AboutApp())
                aboutme.ShowDialog(this);
        }

        private void MainWindowRichText_TextChanged(object sender, EventArgs e)
        {
            if (CurrentFile.HasChanged == false)
            {
                CurrentFile.HasChanged = true;
                CurrentFile.UpdateContextTitle(this);
            }
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if ( (e.CloseReason == CloseReason.WindowsShutDown) )
            {
                if (CurrentSettings.ShutdownAutoSave)
                {
                    FileHandling.FileSave(FileHandling.GetHandlerClassInstance(SupportedFileHandleFormats.TextUnicodePlain), Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "DesktopSave.txt"));

                    if (CurrentSettings.AutoLoadSignIn)
                    {
                        
                        CurrentSettings.SaveShortcut(
                            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "DesktopSave.txt"),
                            Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "DesktopSave.txt")
                        );
                    }

                }
            }
#if DEBUG
            var debugloc = GetUserDebugConfigFileLocation();
            if (File.Exists(debugloc) && (InternalConfig.DisableDebugConfigDeleteOnExit == true))
            {
                File.Delete(debugloc);
            }
            CurrentSettings.SaveToFile(debugloc);
#else
            CurrentSettings.SaveToFile(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HunterNotebook.xml"));
#endif
        }

        private void ToggleMenuItem(ToolStripMenuItem that, ref bool Sync)
        {
            that.Checked = (that.Checked != true);
            Sync = that.Checked;
        }

        private void AutoloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ToggleMenuItem(autoloadToolStripMenuItem, ref CurrentSettings.AutoLoadSignIn);
        }


        private void UnicodeTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void ANSITextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var openme = FileHandling.GetOpenDialogForHandler(SupportedFileHandleFormats.TextAnsiPlain))
            {
                openme.ShowDialog();
            }
        }

    
        private void ReloadOnChangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleMenuItem(reloadOnChangeToolStripMenuItem, ref CurrentSettings.AutoReloadOnChange);
        }

        private void SaveZippedTrackerTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var openme = FileHandling.GetSaveDialogForHandler(SupportedFileHandleFormats.ZippedTrackPlain))
            {
                openme.ShowDialog();
            }
        }

        private void UnicodeTextToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void UnicodeRichTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var openme = FileHandling.GetOpenDialogForHandler(SupportedFileHandleFormats.TextUnicodeRTF))
            {
                openme.ShowDialog();
            }
        }

        private void ZipTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var openme = FileHandling.GetOpenDialogForHandler(SupportedFileHandleFormats.TextAnsiPlain))
            {
                openme.ShowDialog();
            }
        }

        private void AnsiTextToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void EditToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            int fancy = 0;
            if (mainWindowRichText.CanUndo)
            {
                undoToolStripMenuItem.Visible = undoToolStripMenuItem.Enabled = true;
                fancy++;
            }
            else
            {
                undoToolStripMenuItem.Visible = undoToolStripMenuItem.Enabled = false;
                fancy--;
            }

            if (mainWindowRichText.CanRedo)
            {
                redoToolStripMenuItem.Visible = redoToolStripMenuItem.Enabled = true;
                fancy++;
            }
            else
            {
                redoToolStripMenuItem.Visible = redoToolStripMenuItem.Enabled = false;
                fancy--;
            }

            pasteToolStripMenuItem.Enabled = Clipboard.ContainsText();
            if (fancy <= -2)
            {
                toolStripUndoRedo_bar.Visible = false;
            }
            else
            {
                toolStripUndoRedo_bar.Visible = true;
            }

        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainWindowRichText.Undo();
        }

        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainWindowRichText.Redo();
        }

        private void PasteTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = Clipboard.GetText();
            mainWindowRichText.SelectedText = text;
        }

        private void PasteWiithFormatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var FormatPaste = new FormatPasteDialog())
            {
                FormatPaste.TargetBox = mainWindowRichText;
                FormatPaste.ShowDialog();
            }
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(mainWindowRichText.SelectedText);
            mainWindowRichText.SelectedText = string.Empty;
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(mainWindowRichText.SelectedText);
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainWindowRichText.SelectAll();
        }

        private void ClearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainWindowRichText.SelectedText = string.Empty;
        }

        private FancyFindDialog FindDialog = null;
        private void FindToolStripMenuItem_Click(object sender, EventArgs e)
        {

          
            /*
            using (var FindDialog = new FindDialog())
            {
                FindDialog.TargetWindow = mainWindowRichText;
                   FindDialog.ShowDialog(this);
            }*/
            
            if (FindDialog != null)
            {
                try
                {
                    FindDialog.Show();
                }
                catch (ObjectDisposedException)
                {
                    FindDialog = new FancyFindDialog
                    {
                        TargetWindow = mainWindowRichText
                    };
                }
            }
            else
            {
                FindDialog = new FancyFindDialog
                {
                    TargetWindow = mainWindowRichText
                };
                FindDialog.Show();
            }
            
            FindDialog.TopMost = true;
            FindDialog.TopMost = false;

        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (ChooseLevelFontDialog.ShowDialog() == DialogResult.OK)
            {
                mainWindowRichText.SelectionFont = ChooseLevelFontDialog.Font;
                mainWindowRichText.SelectionColor = ChooseLevelFontDialog.Color;
                CurrentSettings.LevelFont = mainWindowRichText.SelectionFont;
           }
            
        }

        private void ToysToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (CurrentSettings.LevelFont != null)
            {
                levelTextToolStripMenuItem.Enabled = true;
            }
            else
            {
                levelTextToolStripMenuItem.Enabled = false;

            }
        }

        private void ToggleMenuItem(ToolStripMenuItem Item)
        {
            if (Item.Checked)
            {
                Item.Checked = false;
            }
            else
            {
                Item.Checked = true;
            }
        }
        private void LevelTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // sasve selection
            int start, len;
            start = mainWindowRichText.SelectionStart;
            len = mainWindowRichText.SelectionLength;

            mainWindowRichText.SelectAll();
            mainWindowRichText.SelectionFont = CurrentSettings.LevelFont;
            mainWindowRichText.SelectionStart = start;
            mainWindowRichText.SelectionLength = len;

        }

        private void ShowHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    


    

        private void SaveToDesktopToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            CurrentSettings.ShutdownAutoSave = saveToDesktopToolStripMenuItem.Checked;

        }

        private void AutoloadToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            CurrentSettings.AutoLoadSignIn = ReloadOnSignInToolStripMenuItem.Checked;
        }

        private void WordWrapToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            CurrentSettings.WordWrap = wordWrapToolStripMenuItem.Checked;
            mainWindowRichText.WordWrap = CurrentSettings.WordWrap;
        }



        private void SaveToDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleMenuItem(saveToDesktopToolStripMenuItem);
        }

        private void AlwaysOnTopToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ToggleMenuItem(alwaysOnTopToolStripMenuItem);
        }

        private void AlwaysOnTopToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            CurrentSettings.AlwaysOnTop = this.TopMost = alwaysOnTopToolStripMenuItem.Checked;

        }

        private void ReloadOnChangeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ToggleMenuItem(reloadOnChangeToolStripMenuItem);
        }

        private void ReloadOnChangeToolStripMenuItem_CheckedChanged_1(object sender, EventArgs e)
        {
            CurrentSettings.AutoReloadOnChange = reloadOnChangeToolStripMenuItem.Checked;
            // watch it again
        }

        private void ReloadOnSignInToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            CurrentSettings.AutoLoadSignIn = reloadOnChangeToolStripMenuItem.Checked;
        }

        private void ReloadOnSignInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleMenuItem(ReloadOnSignInToolStripMenuItem);
        }

        private void AllowReceiveTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleMenuItem(AllowReceiveTextToolStripMenuItem);
        }

        private void AllowReceiveTextToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            CurrentSettings.AllowReceiveTextByDrag = AllowReceiveTextToolStripMenuItem.Checked;
        }

        private void AllowGiveTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleMenuItem(AllowGiveTextToolStripMenuItem);
        }

        private void AllowGiveTextToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            // set the flagf
            CurrentSettings.AllowGiveTextByDrag = AllowGiveTextToolStripMenuItem.Checked;
        }

     

        private void ZoomInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainWindowRichText.ZoomFactor *= 1.10f;
            
        }

        private void ZoomOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainWindowRichText.ZoomFactor *= 1.10f;
        }

        private void ResetZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            mainWindowRichText.ZoomFactor = 1f;
        }

        private void SpecificZoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var ZoomDialog = new ChooseZoom())
            {
                ZoomDialog.Target = mainWindowRichText;
                if (ZoomDialog.ShowDialog() == DialogResult.OK)
                {

                    if (ZoomDialog.CheckBoxRememberZoom.Checked)
                    {
                        try
                        {
                            var zoomFactor = float.Parse(ZoomDialog.ComboBoxChooseZoom.Text);
                            CurrentSettings.PreferredZoom = zoomFactor;
                        }
                        catch (FormatException)
                        {
                            MessageBox.Show("Could not save the ZoomFactor", "Error", MessageBoxButtons.OK);
                        }

                    }
                }
            }
        }

        private void ShowUserConfigFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var self = new Process())
            {
                self.StartInfo = new ProcessStartInfo(Assembly.GetExecutingAssembly().Location)
                {
                    Arguments = "-load ANSI \"" + GetUserConfigFileLocation() + "\""
                };
                self.Start();
            }
        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (CurrentFile.HasChanged)
            {
                switch (MessageBox.Show(Path.GetFileName(CurrentFile.CurrentFile) + " has changed. Save Changes?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                {
                    case DialogResult.Cancel:
                        {
                            return;
                        }
                    case DialogResult.Yes:
                        {
                            if (CurrentFile.FileExists)
                            {
                                FileHandling.FileSave(FileHandling.GetHandlerClassInstance(CurrentFile.Format), CurrentFile.CurrentFile);
                            }
                            else
                            {
                                using (var SaveDialog = FileHandling.GetOpenDialogForHandler(CurrentFile.Format))
                                {

                                }
                                
                            }
                        }
                        break;
                    case DialogResult.No:
                        break;
                    default: throw new Exception("Someone forgot to add code for different DialogResult in File->New");
                }

            }

            CurrentFile = new ContextFile();
            CurrentFile.UpdateContextTitle(this);
        }

        private void MainWindowRichText_ModifiedChanged(object sender, EventArgs e)
        {
            CurrentFile.HasChanged = true;
        }

        private void MakeTransparentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleMenuItem(makeTransparentToolStripMenuItem);
        }

        private void MakeTransparentToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            
            if (makeTransparentToolStripMenuItem.Checked)
            {
                Opacity = 0.5f;
            }
            else
            {
                Opacity = 1;
            }
            CurrentSettings.Opacity = Opacity;
        }

        private void WordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToggleMenuItem(wordWrapToolStripMenuItem);
        }

        private void FileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            // don't mess with the menu if we are in the Designer.
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;

            // zip feature
            OpenZippedTrackerTextToolStripMenuItem.Visible =
            SaveZippedTrackerTextMenuItem.Visible =
            OpenDivideBetweenRTFandZip.Visible =
            SaveTextRTFZipDiv.Visible = (!InternalConfig.DisableZip);

            // rtf feature
            OpenRTFAnsiTextToolStripMenuItem.Visible =
            OpenRTFUnicodeTextToolStripMenuItem.Visible =
            SaveUnicodeRichTextMenuItem.Visible =
            SaveAnsiRichTextMenuItem.Visible =
            OpenDivideBetweenPlainAndRtf.Visible =
            SaveDivideBetweenPlainAndRTF.Visible =
            (!InternalConfig.DisableRTF);

        }

        private void OpenUnicodeTextMenuItem_onClick(object sender, EventArgs e)
        {
            using (var openme = FileHandling.GetOpenDialogForHandler(SupportedFileHandleFormats.TextUnicodePlain))
            {
                openme.ShowDialog();
            }
        }

        private void OpenAnsiTextMenuItem_onClick(object sender, EventArgs e)
        {
            using (var openme = FileHandling.GetOpenDialogForHandler(SupportedFileHandleFormats.TextAnsiPlain))
            {
                openme.ShowDialog();
            }
        }

        private void OpenRTFAnsiText_onClick(object sender, EventArgs e)
        {
            using (var openme = FileHandling.GetOpenDialogForHandler(SupportedFileHandleFormats.TextAnsiRTF))
            {
                openme.ShowDialog();
            }
        }

        private void OpenRTFUnicodeText_onClick(object sender, EventArgs e)
        {
            using (var openme = FileHandling.GetOpenDialogForHandler(SupportedFileHandleFormats.TextUnicodeRTF))
            {
                openme.ShowDialog();
            }
        }

        private void OpenZippedTrackerText_onClick(object sender, EventArgs e)
        {
            using (var openme = FileHandling.GetOpenDialogForHandler(SupportedFileHandleFormats.ZippedTrackPlain))
            {
                openme.ShowDialog();
            }
        }

        private void SaveUnicodeTextToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (var openme = FileHandling.GetSaveDialogForHandler(SupportedFileHandleFormats.TextUnicodePlain))
            {
                openme.ShowDialog();
            }
        }

        private void SaveAnsiTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var openme = FileHandling.GetSaveDialogForHandler(SupportedFileHandleFormats.TextAnsiPlain))
            {
                openme.ShowDialog();
            }
        }

        private void SaveUnicodeRichTextMenuItem_Click(object sender, EventArgs e)
        {
            using (var openme = FileHandling.GetSaveDialogForHandler(SupportedFileHandleFormats.TextUnicodeRTF))
            {
                openme.ShowDialog();
            }
        }

        private void SaveAnsiRichTextMenuItem_Click(object sender, EventArgs e)
        {
            using (var openme = FileHandling.GetSaveDialogForHandler(SupportedFileHandleFormats.TextAnsiRTF))
            {
                openme.ShowDialog();
            }
        }

        private void FeatureRequestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sorry. Not Currently Supported Yet");
        }

        private void HelpToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
                return;
            if (InternalConfig.DisableFeatureSuggestion)
            {
                featureRequestToolStripMenuItem.Visible = false;
            }
            else
            {
                SaveDivideBetweenPlainAndRTF.Visible = true;
            }
        }
    }
}
