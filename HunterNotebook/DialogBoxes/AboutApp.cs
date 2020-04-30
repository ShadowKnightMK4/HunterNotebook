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
using System.Diagnostics;

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

        private void SetAboutAppText(string text)
        {
            textBoxAboutAppContain.Clear();
            textBoxAboutAppContain.Text = text;
            textBoxAboutAppContain.SelectionLength = 0;
            textBoxAboutAppContain.ReadOnly = true;
        }

        private string GetBuildInfo()
        {
            StringBuilder ret = new StringBuilder();
            ret.AppendFormat("Assembly Version: {0}\r\n\r\n", FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location));
            ret.AppendFormat("Internal Build Options: {0}\r\n\r\n", InternalConfig.ToString() ) ;
            return ret.ToString();
        }
        private string GetAboutAppTextFile()
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
                return Encoding.UTF8.GetString(Input);
            }
        }
        private void AboutApp_Load(object sender, EventArgs e)
        {
            SetAboutAppText(GetAboutAppTextFile());
        }

        private void ButtonViewBuild_Click(object sender, EventArgs e)
        {
            SetAboutAppText(GetBuildInfo());
        }

        private void ButtonViewCurrentLicense_Click(object sender, EventArgs e)
        {

        }
    }
}
