using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
namespace HunterNotebook
{
    public partial class AboutApp : Form
    {
        public AboutApp()
        {
            InitializeComponent();
        }

        private void ButtonOk_onClick(object sender, EventArgs e)
        {
            Close();
        }

        private void AboutApp_Load(object sender, EventArgs e)
        {
#if DEBUG
            var debug = Assembly.GetExecutingAssembly().GetManifestResourceNames();
#endif
            using (var filedata = Assembly.GetExecutingAssembly().GetManifestResourceStream("HunterNotebook.DialogBoxes.AboutApp.txt"))
            {
                filedata.Seek(0, System.IO.SeekOrigin.Begin);
                byte[] Input = new byte[filedata.Length];
                // note: we assume unicode
                filedata.Read(Input, 0, (int)filedata.Length);
                textBoxAboutAppContain.Text = Encoding.UTF8.GetString(Input);
                
                textBoxAboutAppContain.SelectionLength = 0;
                textBoxAboutAppContain.ReadOnly = true;
            }
        }
    }
}
