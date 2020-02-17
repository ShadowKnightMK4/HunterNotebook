using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HunterNotebook
{
    public partial class FormatPasteDialog : Form
    {
        public FormatPasteDialog()
        {
            InitializeComponent();
        }


        public RichTextBox TargetBox = null;

        private void FancyPaste()
        {
            string text;
            if (TargetBox == null)
            {
                throw new Exception("Target RTF box not set by app");
            }

            string PasteFormat = ComboBoxSuportedFormatList.SelectedItem.ToString();


            TextDataFormat TargetFormat = (TextDataFormat) Enum.Parse(typeof(TextDataFormat), PasteFormat);

            switch (TargetFormat)
            {
                case TextDataFormat.Text:
                    text = Clipboard.GetText(TargetFormat);
                    TargetBox.SelectedText = text;
                    break;
                case TextDataFormat.UnicodeText:
                    text = Clipboard.GetText(TargetFormat);
                    TargetBox.SelectedText = text;
                    break;
                case TextDataFormat.Html:
                    text = Clipboard.GetText(TargetFormat);
                    TargetBox.SelectedText = text;
                    break;
                case TextDataFormat.Rtf:
                    text = Clipboard.GetText(TargetFormat);
                    TargetBox.SelectedRtf = text;
                    break;
                default:
                    throw new Exception("Unimplemneted Targetformat in paste dialog");
            }

        }
        private List<TextDataFormat> GetFormats()
        {
            List<TextDataFormat> Ret = new List<TextDataFormat>();

            if (Clipboard.ContainsText(TextDataFormat.Html))
                Ret.Add(TextDataFormat.Html);

            if (Clipboard.ContainsText(TextDataFormat.Rtf))
                Ret.Add(TextDataFormat.Rtf);

            if (Clipboard.ContainsText(TextDataFormat.UnicodeText))
                Ret.Add(TextDataFormat.UnicodeText);

            if (Clipboard.ContainsText(TextDataFormat.Text))
                Ret.Add(TextDataFormat.Text);

            return Ret;
        }
        private void FormatPasteDialog_Load(object sender, EventArgs e)
        {
            var textformat = GetFormats();
            if (textformat.Count == 0)
             {
                ComboBoxSuportedFormatList.Enabled = false;
                PasteIntoWindowButton.Enabled = false;
                ComboBoxSuportedFormatList.Text = "No Supported Formats";
            }
            else
            {
                foreach (TextDataFormat f in textformat)
                {
                    ComboBoxSuportedFormatList.Items.Add(Enum.GetName(typeof(TextFormatFlags), f));
                }
                ComboBoxSuportedFormatList.Enabled = PasteIntoWindowButton.Enabled = true;
            }
        }

        private void PasteIntoWindowButton_Click(object sender, EventArgs e)
        {
            FancyPaste();
        }
    }
}
