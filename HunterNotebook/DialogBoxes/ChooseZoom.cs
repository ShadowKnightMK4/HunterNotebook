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

        /// <summary>
        /// the zoom the user chose
        /// </summary>
        public float ZoomFactor = 1.0f;

        private void ButtonOk_Click(object sender, EventArgs e)
        {
            float val;

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
                    //                    Target.ZoomFactor = val;
                    ZoomFactor = val;
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
  
                ButtonOk.Enabled =
                ComboBoxChooseZoom.Enabled =
                VScrollBarTick.Enabled =
                CheckBoxRememberZoom.Enabled = true;

        }

        private void VScrollBarTick_Scroll(object sender, ScrollEventArgs e)
        {
            ComboBoxChooseZoom.Text = (((float)e.NewValue) / 10) .ToString();
        }

        private void ComboBoxChooseZoom_Validating(object sender, CancelEventArgs e)
        {
            float text = 0;
            try 
            {
                text = float.Parse(ComboBoxChooseZoom.Text);
            }
            catch (FormatException)
            {
                e.Cancel = true;
                MessageBox.Show("Please Specified a number and not \"" + ComboBoxChooseZoom.Text + "\"");
            }
            if ((text <= 0.0125) || (text >= 64))
            {
                e.Cancel = true;
                MessageBox.Show("Please Specified a number between 0.0125 and 64");
            }
        }

        private void ChooseZoom_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (ModifierKeys.HasFlag(Keys.Control))
            if (true)
            {
                if (((int)(Keys.Escape) == e.KeyChar))
                {
                    DialogResult = DialogResult.Cancel;
                    Close();
                }
            }
        }
    }
}
