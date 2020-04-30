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
  

    public partial class NotebookFormatBookBuddy : Form
    {
        public RichTextBox TargetWindow;
        public Dictionary<string, BookMark> CurrentSavedBooks = new Dictionary<string, BookMark>();
        public int bookmark_c = 0;
        public NotebookFormatBookBuddy()
        {
            InitializeComponent();
        }

        private void NotebookFormatBookBuddy_Load(object sender, EventArgs e)
        {
            TextBoxListEdit.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (TargetWindow != null)
            {
                CurrentSavedBooks.Add("bookmark" + bookmark_c.ToString(), new BookMark(TargetWindow));
                ListBoxBookMarks.Items.Add("bookmark" + bookmark_c.ToString());
                bookmark_c++;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (TargetWindow != null)
            {
                if (ListBoxBookMarks.SelectedItem != null)
                {
                    var thismark = CurrentSavedBooks[ListBoxBookMarks.SelectedItem.ToString()];
                    thismark.GotoBookmark(TargetWindow);
                }
                else
                {
                    MessageBox.Show("Select a bookmark to goto");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ListBoxBookMarks.SelectedItem != null) 
             {
                CurrentSavedBooks.Remove(ListBoxBookMarks.SelectedItem.ToString());
                ListBoxBookMarks.Items.RemoveAt(ListBoxBookMarks.SelectedIndex);
            }
        }
    }

    public class BookMark
    {
        public int CursorLine;
        public int CursorColum;
        public int TargetLine;
        public int TargetColumn;

        public string Name;

        public BookMark(RichTextBox Target)
        {
            CursorLine = Target.SelectionStart;
        }
        public void GotoBookmark(RichTextBox Target)
        {
            Target.SelectionStart = CursorLine;
        }
    }
}
