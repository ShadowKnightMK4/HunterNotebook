namespace HunterNotebook
{
    partial class AboutApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxAboutAppContain = new System.Windows.Forms.TextBox();
            this.ButtonOk = new System.Windows.Forms.Button();
            this.ButtonViewCurrentLicense = new System.Windows.Forms.Button();
            this.ButtonViewBuild = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxAboutAppContain
            // 
            this.textBoxAboutAppContain.Location = new System.Drawing.Point(25, 26);
            this.textBoxAboutAppContain.Multiline = true;
            this.textBoxAboutAppContain.Name = "textBoxAboutAppContain";
            this.textBoxAboutAppContain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxAboutAppContain.Size = new System.Drawing.Size(581, 145);
            this.textBoxAboutAppContain.TabIndex = 0;
            // 
            // ButtonOk
            // 
            this.ButtonOk.Location = new System.Drawing.Point(648, 26);
            this.ButtonOk.Name = "ButtonOk";
            this.ButtonOk.Size = new System.Drawing.Size(159, 32);
            this.ButtonOk.TabIndex = 1;
            this.ButtonOk.Text = "Ok";
            this.ButtonOk.UseVisualStyleBackColor = true;
            this.ButtonOk.Click += new System.EventHandler(this.ButtonOk_onClick);
            // 
            // ButtonViewCurrentLicense
            // 
            this.ButtonViewCurrentLicense.Location = new System.Drawing.Point(648, 73);
            this.ButtonViewCurrentLicense.Name = "ButtonViewCurrentLicense";
            this.ButtonViewCurrentLicense.Size = new System.Drawing.Size(159, 32);
            this.ButtonViewCurrentLicense.TabIndex = 2;
            this.ButtonViewCurrentLicense.Text = "View License Info";
            this.ButtonViewCurrentLicense.UseVisualStyleBackColor = true;
            this.ButtonViewCurrentLicense.Click += new System.EventHandler(this.ButtonViewCurrentLicense_Click);
            // 
            // ButtonViewBuild
            // 
            this.ButtonViewBuild.Location = new System.Drawing.Point(648, 122);
            this.ButtonViewBuild.Name = "ButtonViewBuild";
            this.ButtonViewBuild.Size = new System.Drawing.Size(159, 34);
            this.ButtonViewBuild.TabIndex = 3;
            this.ButtonViewBuild.Text = "View Build Information";
            this.ButtonViewBuild.UseVisualStyleBackColor = true;
            this.ButtonViewBuild.Click += new System.EventHandler(this.ButtonViewBuild_Click);
            // 
            // AboutApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(919, 220);
            this.Controls.Add(this.ButtonViewBuild);
            this.Controls.Add(this.ButtonViewCurrentLicense);
            this.Controls.Add(this.ButtonOk);
            this.Controls.Add(this.textBoxAboutAppContain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutApp";
            this.Text = "About This Program";
            this.Load += new System.EventHandler(this.AboutApp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAboutAppContain;
        private System.Windows.Forms.Button ButtonOk;
        private System.Windows.Forms.Button ButtonViewCurrentLicense;
        private System.Windows.Forms.Button ButtonViewBuild;
    }
}