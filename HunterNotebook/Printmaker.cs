using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.IO;
namespace HunterNotebook
{
    /// <summary>
    /// For the mainWindow dialog
    /// </summary>
    public partial class Printmaker : Form
    {
        public Printmaker()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Is the form ready to display. If not call Setup()
        /// </summary>
        public bool Ready { get; private set; }

        private ContextFile CFile;
        private ContextSetting CSettings;
        private RichTextBox TextSource;

        private PrinterSettings PrinterSets = new PrinterSettings();

        public void Setup(ContextFile CurrentFile, ContextSetting Settings, RichTextBox Target)
        {
            CFile = CurrentFile;
            CSettings = Settings;
            TextSource = Target;
            Ready = true;
            PrinterSets = new PrinterSettings();
        }
        private void Printmaker_Load(object sender, EventArgs e)
        {
           
            foreach (string s in PrinterSettings.InstalledPrinters)
            {
                ComboBoxTargetPrinter.Items.Add(s);
            }

            
        }



        private void button1_Click(object sender, EventArgs e)
        {

                if (!Ready)
                {
                    if (LicenseManager.UsageMode != LicenseUsageMode.Designtime)
                        throw new Exception("Forgot to call");
                    else
                    {
                        return;
                    }
                }
  
            using (PrintDocument TargetPrinter = new PrintDocument())
            {
                TargetPrinter.DocumentName = Path.GetFileName(CFile.CurrentFile);
                TargetPrinter.PrinterSettings = PrinterSets;
                TargetPrinter.Print();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (PrintDialog dlg = new PrintDialog())
            {
                dlg.PrinterSettings = PrinterSets;
                switch (dlg.ShowDialog())
                {
                    case DialogResult.Cancel:
                        break;
                    case DialogResult.OK:
                        break;

                }

                
            }

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (int.TryParse(TextBoxNumberOfCopies.Text, out int CopyCount))
            {
                if (CopyCount <= 0)
                {
                    e.Cancel = true;
                    TextBoxNumberOfCopies.Text = "1";
                }
                else
                {

                }
            }
            else
            {
                e.Cancel = true;
                TextBoxNumberOfCopies.Text = "1";
            }
        }
    }
}
