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
    public partial class ChooseZoom : Form
    {
        public ChooseZoom()
        {
            InitializeComponent();
        }

        public RichTextBox Target = null;
        private void ButtonOk_Click(object sender, EventArgs e)
        {
            float val = 0;

            if (Target != null)
            {
                try
                {
                    val =float.Parse(ComboBoxChooseZoom.Text);
                }
                catch (FormatException)
                {
                    val = 0;
                    MessageBox.Show("Error: Invalid zoom factor. Please choose a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (val != 0)
                {
                    Target.ZoomFactor = val;
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }



        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void ChooseZoom_Shown(object sender, EventArgs e)
        {
            if (Target == null)
            {
#if DEBUG
                ButtonOk.Enabled =
                ComboBoxChooseZoom.Enabled =
                VScrollBarTick.Enabled =
                CheckBoxRememberZoom.Enabled = false;
#else
                MessageBox.Show("Warning: No Target Specified to affect zoom with", "Program Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
#endif
            }
            else
            {
                ButtonOk.Enabled =
                ComboBoxChooseZoom.Enabled =
                VScrollBarTick.Enabled =
                CheckBoxRememberZoom.Enabled = true;
            }
        }

        private void vScrollBarTick_Scroll(object sender, ScrollEventArgs e)
        {
            ComboBoxChooseZoom.Text = (((float)e.NewValue) / 10) .ToString();
        }
    }
}
