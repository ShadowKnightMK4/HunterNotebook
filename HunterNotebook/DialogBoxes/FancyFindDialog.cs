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
    public partial class FancyFindDialog : Form
    {
        public FancyFindDialog()
        {
            InitializeComponent();
        }

        public RichTextBox TargetWindow = null;
        int LastFindResult = -1;

        private int Find(string text, int StartAt, RichTextBoxFinds op)
        {
            int result = TargetWindow.Find(text, StartAt, op);
            return result;
        }

        private void SanityCheck()
        {
            if (TargetWindow != null)
            {

            }
            else
            {

            }
        }
        private void FancyFindDialog_Load(object sender, EventArgs e)
        {
            SanityCheck();
        }

        private void ReplaceTextWithSelection(string text, int here, int length)
        {
            int ostart, olen;
            ostart = TargetWindow.SelectionStart;
            olen = TargetWindow.SelectionLength;


            TargetWindow.SelectionLength = length;
            TargetWindow.SelectionStart = here;


            TargetWindow.SelectedText = text;


            TargetWindow.SelectionLength = olen;
            TargetWindow.SelectionStart = ostart;

        }
        private RichTextBoxFinds FlagsFromCheckbox()
        {
            RichTextBoxFinds ret = RichTextBoxFinds.None;
            if (CheckBoxMatchCase.Checked)
            {
                ret |= RichTextBoxFinds.MatchCase;
            }
            if (CheckBoxMatchWholeWord.Checked)
            {
                ret |= RichTextBoxFinds.WholeWord;
            }
            return ret;
        }

        private void NoThingFound()
        {
            MessageBox.Show("Could not find another reference to \"" + TextBoxFindText.Text + ".\"", "No More Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LastFindResult = 0;
        }
        private void ButtonFind_Click(object sender, EventArgs e)
        {
            SanityCheck();
            if (TargetWindow != null)
            {
                LastFindResult = Find(TextBoxFindText.Text, 0, FlagsFromCheckbox());
                if (LastFindResult <= -1)
                {
                    NoThingFound();
                }
            }
            
        }

        private void ButtonFindNext_Click(object sender, EventArgs e)
        {
            SanityCheck();
            if (TargetWindow != null)
            {
                LastFindResult = Find(TextBoxFindText.Text, LastFindResult+1, FlagsFromCheckbox());
                if (LastFindResult <= -1)
                {
                    NoThingFound();
                }
            }
        }

        private void ButtonReplaceText_Click(object sender, EventArgs e)
        {
            SanityCheck();
             if (TargetWindow != null)
            {
                if (CheckboxReplaceTextAutoGo.Checked)
                {
                    LastFindResult = Find(TextBoxFindText.Text, LastFindResult + 1, FlagsFromCheckbox());
                    if (LastFindResult > -1)
                    {
                        ReplaceTextWithSelection(TextBoxReplaceText.Text, LastFindResult, TextBoxFindText.Text.Length);
                    }
                    else
                    {
                        if (LastFindResult <= -1)
                        {
                            NoThingFound();
                        }
                    }
                }
                else
                {

                }
            }
        }
    }
}
