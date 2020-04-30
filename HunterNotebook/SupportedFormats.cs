using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using Noteformat;

namespace HunterNotebook
{
    /// <summary>
    /// Each supported format is an inplementation of one of these
    /// </summary>
    interface IFormatHandler
    {
       void Save(RichTextBox Contents, ContextFile context);
       void Load(RichTextBox Contents, ContextFile context);
    }
    /// <summary>
    /// All formats the fileHandler class supports
    /// </summary>
    public enum SupportedFileHandleFormats
    {
        /// <summary>
        ///  GUI Only Var: Blanks for the format on the window title. Not supported for anything else
        /// </summary>
        Unknown = -1,

        /// <summary>
        /// Plain Jane ANSI text
        /// </summary>
        TextAnsiPlain = 0,
        /// <summary>
        /// Ansi TXT with RTF tags
        /// </summary>
        TextAnsiRTF = 1,
        /// <summary>
        /// Plain Jane UNICODE text
        /// </summary>
        TextUnicodePlain = 2,
        /// <summary>
        /// Uncide Text with RTF tags
        /// </summary>
        TextUnicodeRTF = 3,

        /// <summary>
        /// Unicode Plain Text compressed. See Noteformat.cs
        /// </summary>
        CompressedTextFile = 10,

        ZippedTrackPlain = 90,
        ZippedTrackRTF = 99
    }
    /// <summary>
    
    /// </summary>
     static class FileHandling
    {
        /// <summary>
        /// All formats this class can create handlers off
        /// </summary>

        [Flags]
        public enum IsTextUnicodeFlags : int
        {
            IS_TEXT_UNICODE_ASCII16 = 0x0001,
            IS_TEXT_UNICODE_REVERSE_ASCII16 = 0x0010,

            IS_TEXT_UNICODE_STATISTICS = 0x0002,
            IS_TEXT_UNICODE_REVERSE_STATISTICS = 0x0020,

            IS_TEXT_UNICODE_CONTROLS = 0x0004,
            IS_TEXT_UNICODE_REVERSE_CONTROLS = 0x0040,

            IS_TEXT_UNICODE_SIGNATURE = 0x0008,
            IS_TEXT_UNICODE_REVERSE_SIGNATURE = 0x0080,

            IS_TEXT_UNICODE_ILLEGAL_CHARS = 0x0100,
            IS_TEXT_UNICODE_ODD_LENGTH = 0x0200,
            IS_TEXT_UNICODE_DBCS_LEADBYTE = 0x0400,
            IS_TEXT_UNICODE_NULL_BYTES = 0x1000,

            IS_TEXT_UNICODE_UNICODE_MASK = 0x000F,
            IS_TEXT_UNICODE_REVERSE_MASK = 0x00F0,
            IS_TEXT_UNICODE_NOT_UNICODE_MASK = 0x0F00,
            IS_TEXT_UNICODE_NOT_ASCII_MASK = 0xF000
        }

        [DllImport("Advapi32", SetLastError = false)]
        static extern bool IsTextUnicode(byte[] buf, int len, ref IsTextUnicodeFlags opt);
        public static bool IsFileUnicode(string file)
        {
            byte[] Bytes = File.ReadAllBytes(file);
            IsTextUnicodeFlags Result =  IsTextUnicodeFlags.IS_TEXT_UNICODE_NOT_UNICODE_MASK;
            if (IsTextUnicode(Bytes, Bytes.Length, ref Result))
            {
                return false;
            }
            return true;
        }
        public static IFormatHandler GetHandlerClassInstance(SupportedFileHandleFormats format)
        {
            switch (format)
            {
                case SupportedFileHandleFormats.TextAnsiPlain:
                    return new AnsiPlainText();
                case SupportedFileHandleFormats.TextUnicodePlain:
                    return new UnicodePlainText();
                case SupportedFileHandleFormats.CompressedTextFile:
                    return new NoteformatLinker();

                case SupportedFileHandleFormats.ZippedTrackPlain:
                    return new ZippedChangeTracker();
                default:
                    throw new NotImplementedException(Enum.GetName(typeof(SupportedFileHandleFormats), format));
            }

        }

        /// <summary>
        /// the mainWindow this is instanced with. 
        /// </summary>
        public static mainWindow TargetWindow;


        /// <summary>
        /// Display a save dialog setup for the chosen format. Saves if the user presses ok
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static SaveFileDialog GetSaveDialogForHandler(SupportedFileHandleFormats format)
        {
            SaveFileDialog Ret = new SaveFileDialog();
            GenericDialogSetup(Ret);
            switch (format)
            {
                case SupportedFileHandleFormats.ZippedTrackPlain:
                    Ret.Title = "Save a Change Tracked Text File";
                    Ret.Filter = "Change Text File (*.TBD)| *.TBD";
                    Ret.FileOk += SaveTBD_FileOk;
                    break;
                case SupportedFileHandleFormats.TextUnicodeRTF:
                    Ret.Title = "Save a Plain Unicdode Rich Text File";
                    Ret.Filter = "Text Files (*.rtf)|*.rtf";
                    Ret.FileOk += SaveUnicodeRichText_FileOk;
                    break;
                case SupportedFileHandleFormats.TextUnicodePlain:
                    Ret.Title = "Save a Plain Unicode Text File";
                    Ret.Filter = "Text Files (*.txt)|*.txt";
                    Ret.FileOk += SaveUnicodePlainText_FileOK;
                    break;
                case SupportedFileHandleFormats.TextAnsiRTF:
                    Ret.Title = "Save a Plain Ansi Rich Text File";
                    Ret.Filter = "Text Files (*.rtf)|*.rtf";
                    Ret.FileOk += SaveAnsiRTF_FileOK;
                    break;
                case SupportedFileHandleFormats.TextAnsiPlain:
                    Ret.Title = "Save a Plain Ansi Text File";
                    Ret.Filter = "Text Files (*.txt)|*.txt| Log File (*.log)|*.log";
                    Ret.FileOk += SaveAniPlainText_FileOK;
                    break;
                case SupportedFileHandleFormats.CompressedTextFile:
                    Ret.Title = "Save Compressed Text";
                    Ret.Filter = "Compressed Text (*.tx_)|*.tx_";
                    Ret.FileOk += SaveCompressedText_FileOK;
                    break;
                default:
                    Ret.Title = "Save a file";
                    throw new NotImplementedException(Enum.GetName(typeof(SupportedFileHandleFormats), format));
            }

            Ret.Filter += "|All files (*.*)|*.*";

            return Ret;
        }

        private static void SaveCompressedText_FileOK(object sender, CancelEventArgs e)
        {
            TargetWindow.CurrentFile.Format = SupportedFileHandleFormats.CompressedTextFile;
            InternalFileOk_Write(GetHandlerClassInstance(SupportedFileHandleFormats.CompressedTextFile), sender, e);
        }



        /// <summary>
        /// The internal callback fo the GetSaveDialogForHandler. Plugged into FileOk Event
        /// </summary>
        /// <param name="Handler"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
#pragma warning disable IDE0060 // Remove unused parameter
        private static void InternalFileOk_Write(IFormatHandler Handler, object sender, CancelEventArgs e)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            if (Handler != null)
            {
                if (TargetWindow.CurrentFile == null)
                {
                    TargetWindow.CurrentFile = new ContextFile();
                }
                if (string.IsNullOrEmpty(TargetWindow.CurrentFile.CurrentFile))
                {
                    TargetWindow.CurrentFile.CurrentFile = ((FileDialog)sender).FileName;
                }
                Handler.Save(TargetWindow.mainWindowRichText, TargetWindow.CurrentFile);
                TargetWindow.CurrentFile.UpdateContextTitle(TargetWindow);

                return;
            }
            throw new Exception("Handler=null");
        }
        /// <summary>
        /// Saves the window contets as ANSI text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void SaveAniPlainText_FileOK(object sender, CancelEventArgs e)
        {
            TargetWindow.CurrentFile.Format = SupportedFileHandleFormats.TextAnsiPlain;
            InternalFileOk_Write(GetHandlerClassInstance(SupportedFileHandleFormats.TextAnsiPlain), sender, e);
        }

        /// <summary>
        /// save the window contents as RTF Ansi contents
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void SaveAnsiRTF_FileOK(object sender, CancelEventArgs e)
        {
            TargetWindow.CurrentFile.Format = SupportedFileHandleFormats.TextAnsiRTF;
            InternalFileOk_Write(GetHandlerClassInstance(SupportedFileHandleFormats.TextAnsiRTF), sender, e);
        }

        /// <summary>
        /// save as unicode text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void SaveUnicodePlainText_FileOK(object sender, CancelEventArgs e)
        {
            TargetWindow.CurrentFile.Format = SupportedFileHandleFormats.TextUnicodePlain;
            InternalFileOk_Write(GetHandlerClassInstance(SupportedFileHandleFormats.TextUnicodePlain), sender, e);
        }


        /// <summary>
        /// save as unicode rich text
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void SaveUnicodeRichText_FileOk(object sender, CancelEventArgs e)
        {
            TargetWindow.CurrentFile.Format = SupportedFileHandleFormats.TextUnicodeRTF;
            InternalFileOk_Write(GetHandlerClassInstance(SupportedFileHandleFormats.TextUnicodeRTF), sender, e);
        }

        /// <summary>
        /// save as the custom format
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void SaveTBD_FileOk(object sender, CancelEventArgs e)
        {
            TargetWindow.CurrentFile.Format = SupportedFileHandleFormats.ZippedTrackPlain;
            InternalFileOk_Write(GetHandlerClassInstance(SupportedFileHandleFormats.ZippedTrackPlain), sender, e);
        }

        /// <summary>
        /// get a OpenDialogBox all setup for the chosen format
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public static OpenFileDialog GetOpenDialogForHandler(SupportedFileHandleFormats format)
        {
            OpenFileDialog Ret = new OpenFileDialog();

            GenericDialogSetup(Ret);
            switch (format)
            {
                case SupportedFileHandleFormats.ZippedTrackPlain:
                    Ret.Title = "Open a Change Tracked Text File";
                    Ret.Filter = "Change Text File (*.TBD)| *.TBD";
                    Ret.FileOk += OpenTBD_FileOk;
                    break;
                case SupportedFileHandleFormats.TextUnicodeRTF:
                    Ret.Title = "Open a Plain Unicdode Rich Text File";
                    Ret.Filter = "Text Files (*.rtf)|*.rtf";
                    Ret.FileOk += OpenUnicodeRichText_FileOk;
                    break;
                case SupportedFileHandleFormats.TextUnicodePlain:
                    Ret.Title = "Open a Plain Unicode Text File";
                    Ret.Filter = "Text Files (*.txt)|*.txt";
                    Ret.FileOk += OpenUnicodePlainText_FileOK ;
                    break;
                case SupportedFileHandleFormats.TextAnsiRTF:
                    Ret.Title = "Open a Plain Ansi Rich Text File";
                    Ret.Filter = "Text Files (*.rtf)|*.rtf";
                    Ret.FileOk += OpenAnsiRTF_FileOK;
                    break;
                case SupportedFileHandleFormats.TextAnsiPlain:
                    Ret.Title = "Open a Plain Ansi Text File";
                    Ret.Filter = "Text Files (*.txt)|*.txt| Log File (*.log)|*.log";
                    Ret.FileOk += OpenAniPlainText_FileOK;
                    break;
                default:
                    Ret.Title = "Open a file";
                    throw  new NotImplementedException(Enum.GetName(typeof(SupportedFileHandleFormats), format));
            }
            Ret.Filter += "|All files (*.*)|*.*";

            return Ret;
        }


        public static void FileSave(IFormatHandler Handler, string filename)
        {
            if (TargetWindow == null)
            {
                throw new ArgumentNullException("Forgot to set TargetWindow befor call");
            }
            if (Handler != null)
            {
                var NewContext = new ContextFile();
                try
                {
                    NewContext.CurrentFile = filename;
                         
                    Handler.Save(TargetWindow.mainWindowRichText, NewContext);
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.Message, "Error saving file");
                    NewContext = null;
                }

                if (NewContext != null)
                {
                    TargetWindow.CurrentFile = NewContext;
                }
                return;
            }
            throw new ArgumentNullException("handler=null");
        }


        /// <summary>
        /// Load a file via the chosen handler without invoking the dialog to choose
        /// </summary>
        /// <param name="Handler">handler to user (format)</param>
        /// <param name="filename">target file</param>
        /// <param name="ContextId">Set the title bar to this format</param>
        public static void FileLoad(IFormatHandler Handler, string filename, SupportedFileHandleFormats ContextId)
        {
            if (TargetWindow == null)
            {
                throw new ArgumentNullException("Forgot to set TargetWindow befor call");
            }
            if (Handler != null)
            {
                var NewContext = new ContextFile
                {
                    CurrentFile = filename
                };
                try
                {
                    Handler.Load(TargetWindow.mainWindowRichText, NewContext);
                }
                catch (IOException e)
                {
                    MessageBox.Show(e.Message, "Error loading file. Message is " + e.Message);
                    NewContext = null;
                }

                if (NewContext != null)
                {
                    TargetWindow.CurrentFile = NewContext;
                    NewContext.Format = ContextId;
                    TargetWindow.mainWindowRichText.Modified = false;
                    NewContext.UpdateContextTitle(TargetWindow);
                }
                return;
            }
            throw new ArgumentNullException("handler=null");
        }

        /// <summary>
        /// The event that loads the file from a OpenDialog
        /// </summary>
        /// <param name="Handler"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
#pragma warning disable IDE0060 // Remove unused parameter
        private static  void InternalFileOk_Read(IFormatHandler Handler, object sender, CancelEventArgs e)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            if (Handler != null)
            {
                if (TargetWindow.CurrentFile == null)
                {
                    TargetWindow.CurrentFile = new ContextFile();
                }
                if (string.IsNullOrEmpty(TargetWindow.CurrentFile.CurrentFile))
                { 
                    TargetWindow.CurrentFile.CurrentFile = ((FileDialog)sender).FileName;
                }
                Handler.Load(TargetWindow.mainWindowRichText, TargetWindow.CurrentFile);
                TargetWindow.CurrentFile.UpdateContextTitle(TargetWindow);
                
                return;
            }
            throw new ArgumentNullException("handler=null");
        }
        private static void OpenAniPlainText_FileOK(object sender, CancelEventArgs e)
        {
            TargetWindow.CurrentFile.Format = SupportedFileHandleFormats.TextAnsiPlain;
            InternalFileOk_Read(GetHandlerClassInstance(SupportedFileHandleFormats.TextAnsiPlain), sender, e);
        }

        private static void OpenAnsiRTF_FileOK(object sender, CancelEventArgs e)
        {
            InternalFileOk_Read(GetHandlerClassInstance(SupportedFileHandleFormats.TextAnsiRTF), sender, e);
        }

        private static void OpenUnicodePlainText_FileOK(object sender, CancelEventArgs e)
        {
            TargetWindow.CurrentFile.Format = SupportedFileHandleFormats.TextUnicodePlain;
            InternalFileOk_Read(GetHandlerClassInstance(SupportedFileHandleFormats.TextUnicodePlain), sender, e);
        }

        

        private static void OpenUnicodeRichText_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            InternalFileOk_Read(GetHandlerClassInstance(SupportedFileHandleFormats.TextUnicodeRTF), sender, e);
        }

        private static void OpenTBD_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            InternalFileOk_Read(GetHandlerClassInstance(SupportedFileHandleFormats.ZippedTrackPlain), sender, e);
        }

        /// <summary>
        /// Do the generic setup stuff for both the OpenDialog() and SaveDialog() boxs made by this class
        /// </summary>
        /// <param name="dlg"></param>
        private static void GenericDialogSetup(FileDialog dlg)
        {
            dlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            dlg.FileName = "";
        }

        public static void DeleteAutoShortcut()
        {
            var thing = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "DesktopSave.txt.lnk");
            if (File.Exists
                (thing))
            {
                File.Delete(thing);
            }
        }
    }

    /// <summary>
    /// Ansi text with no RTF flags
    /// </summary>
    class AnsiPlainText : GenericTextFormat
    {
        public AnsiPlainText()
        {
            SetFormat(EncodingFormat.ANSI, false);
        }
    }


    /// <summary>
    /// Ansi text with encoded RTF formatted
    /// </summary>
    class AnsiRTF : GenericTextFormat
    {
        public AnsiRTF()
        {
            SetFormat(EncodingFormat.ANSI, true);
        }
    }

    /// <summary>
    /// Unicodfe text with no RTF format
    /// </summary>
    class UnicodePlainText : GenericTextFormat
    {
        public UnicodePlainText()
        {
            SetFormat(EncodingFormat.UNCODE, false);
        }
    }

    /// <summary>
    /// Unicode Text with RTF formatted
    /// </summary>
    class UnicodeRTF : GenericTextFormat
    {
        public UnicodeRTF()
        {
            SetFormat(EncodingFormat.UNCODE, true);
        }
    }


    /// <summary>
    /// communicate between this app and Noteformat Class implimenation
    /// </summary>
    class NoteformatLinker : IFormatHandler
    {
        public void Load(RichTextBox Contents, ContextFile context)
        {
            bool stringIsUnicode = false;
            bool rtf = false;
            using (var input = File.OpenRead(context.CurrentFile))
            {
                NoteDocument Data = new NoteDocument(input);
                
                if (Data.EncodingData.HasFlag(StringEncodingData.ANSI_STRING) ||
                    (Data.EncodingData.HasFlag(StringEncodingData.UNICODE_STRING) == false))
                {
                    stringIsUnicode = false;
                }
                else
                {
                    stringIsUnicode = true;
                }
                    
                if (Data.EncodingData.HasFlag(StringEncodingData.PLAINTEXT) ||
                    (Data.EncodingData.HasFlag(StringEncodingData.RICHTEXT) == false))
                {
                    rtf = false;
                }
                else
                {
                    rtf = true;
                }

                if (rtf)
                {
                    Contents.Rtf = Data.CoreString;
                }
                else
                {
                    Contents.Text = Data.CoreString;
                }
            }
        }

        public void Save(System.Windows.Forms.RichTextBox Contents, ContextFile context)
        {
            using (var FileOut = File.OpenWrite(context.CurrentFile))
            {
                NoteDocument prep = new NoteDocument();
                prep.EncodingData = StringEncodingData.PLAINTEXT | StringEncodingData.UNICODE_STRING;
                prep.CoreString = Contents.Text;
                prep.SaveToStream(FileOut);
            }
        }

        
    }


    /// <summary>
    /// the generic container for the supported pure text encodings.
    /// ANSI and UNicode
    /// </summary>
    class GenericTextFormat: IFormatHandler
    {
        public enum EncodingFormat
        { 
            /// <summary>
            /// use the 1 byte encoding
            /// </summary>
            ANSI = 0,
            /// <summary>
            /// use the 2 byte encoding
            /// </summary>
            UNCODE = 1,
        }

        private EncodingFormat TargetFormat = EncodingFormat.ANSI;
        /// <summary>
        /// choose between RTF and text only
        /// </summary>
        protected bool RTF = false;

        protected void SetFormat(EncodingFormat TargetFormat, bool UseRTF)
        {
            RTF = UseRTF;
            this.TargetFormat = TargetFormat;
        }

        protected string GetStringFromFile(Stream Target)
        {
            Target.Position = 0;
            byte[] data= new byte[Target.Length];
            int step = 0;
            while (step < Target.Length)
            {
                data[step++] = (byte)Target.ReadByte();
            }

            switch (TargetFormat)
            {
                case EncodingFormat.ANSI:
                    return Encoding.ASCII.GetString(data);
                case EncodingFormat.UNCODE:
                       return Encoding.Unicode.GetString(data);
                default: throw new NotImplementedException(Enum.GetName(typeof(EncodingFormat), TargetFormat));
            }

        }

        /// <summary>
        /// get the bytes to write to the target
        /// </summary>
        /// <param name="contents"></param>
        /// <returns>returns the text from the RTF control in the right encoding</returns>
        protected byte[] GetBytesForSave(System.Windows.Forms.RichTextBox contents)
        {
            switch (TargetFormat)
            {
                case EncodingFormat.ANSI:
                    if (RTF)
                    {
                        return Encoding.ASCII.GetBytes(contents.Rtf);
                    }
                    else
                    {
                        return Encoding.ASCII.GetBytes(contents.Text);
                    }
                case EncodingFormat.UNCODE:
                    if (RTF)
                    {
                        return Encoding.Unicode.GetBytes(contents.Rtf);
                    }
                    else
                    {
                        return Encoding.Unicode.GetBytes(contents.Text);
                    }
                default: throw  new NotImplementedException(Enum.GetName(typeof(EncodingFormat), TargetFormat));
            }
        }

        /// <summary>
        /// save the file specified by the RTF window contents to the Context
        /// </summary>
        /// <param name="Contents">the RTF window to read text from</param>
        /// <param name="context">contains where to save</param>
        public void Save(System.Windows.Forms.RichTextBox Contents, ContextFile context)
        {
                using (var WriteTo = File.OpenWrite(context.CurrentFile))
                {
                    var bytes = GetBytesForSave(Contents);
                    WriteTo.Write(bytes, 0, bytes.Length);
                }

        }

        /// <summary>
        /// load the specified file into the RTF window
        /// </summary>
        /// <param name="Contents">load the file into this</param>
        /// <param name="context">the context to load from</param>
        public void Load(System.Windows.Forms.RichTextBox Contents, ContextFile context)
        {
            using (var ReadFrom = File.OpenRead(context.CurrentFile))
            {
                var load = GetStringFromFile(ReadFrom);
               if (this.RTF)
                {
                    Contents.Rtf = load;
                }
               else
                {
                    Contents.Text = load;
                }
            }
        }
    }


    

    /*
     * core format is a zip file named whatever.TRK (ext TBD)
     * 
     * in the root of the zip is a XML version of the ZIPTRACK class saves as unicode text
     * there is a subfolder names documents that contains the text file.
     * 
     * The encoding of txt files themself is Unicode text
     * 
     * Theory is each textfile is saved into this subfolder and when the subfolder reaches
     * the cap, older ones are deleted.
     */
    public class ZippedChangeTracker : IFormatHandler
    {
        private string NameFromDoc(string basename)
        {
            var now = DateTime.Now;
            /* basename-- month -- day -- year -- hour -- min -- sec.txt */
            return string.Format("{0}-{1}-{2}-{3}-{4}--{5}--{6}.txt",
                Path.GetFileNameWithoutExtension(basename), now.Month.ToString(), now.Day.ToString(), now.Year.ToString(), now.Hour.ToString(), now.Minute.ToString(), now.Second.ToString());
        }
        public void Save(System.Windows.Forms.RichTextBox Contents, ContextFile context)
        {
            using (var Target = ZipFile.Open(context.CurrentFile,  ZipArchiveMode.Update))
            {
                ZipArchiveEntry SubTarget = Target.CreateEntry("text\\document\\" + NameFromDoc(context.CurrentFile));
                {
                    var data = Encoding.UTF8.GetBytes(Contents.Text);
                    using (var SubStream = SubTarget.Open())
                    {
                        SubStream.Write(data, 0, data.Length);
                    }
                }
                
            }
        }
        public void Load(System.Windows.Forms.RichTextBox Contents, ContextFile context)
        {

        }
    }



}
