namespace HunterNotebook
{
    partial class FormatPasteDialog
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
            this.ComboBoxSuportedFormatList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PasteIntoWindowButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ComboBoxSuportedFormatList
            // 
            this.ComboBoxSuportedFormatList.FormattingEnabled = true;
            this.ComboBoxSuportedFormatList.Location = new System.Drawing.Point(43, 53);
            this.ComboBoxSuportedFormatList.Name = "ComboBoxSuportedFormatList";
            this.ComboBoxSuportedFormatList.Size = new System.Drawing.Size(289, 28);
            this.ComboBoxSuportedFormatList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Detected Formats";
            // 
            // PasteIntoWindowButton
            // 
            this.PasteIntoWindowButton.Location = new System.Drawing.Point(640, 26);
            this.PasteIntoWindowButton.Name = "PasteIntoWindowButton";
            this.PasteIntoWindowButton.Size = new System.Drawing.Size(106, 36);
            this.PasteIntoWindowButton.TabIndex = 2;
            this.PasteIntoWindowButton.Text = "Paste";
            this.PasteIntoWindowButton.UseVisualStyleBackColor = true;
            this.PasteIntoWindowButton.Click += new System.EventHandler(this.PasteIntoWindowButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(640, 69);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(106, 33);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // FormatPasteDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.PasteIntoWindowButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ComboBoxSuportedFormatList);
            this.Name = "FormatPasteDialog";
            this.Text = "FormatPasteDialog";
            this.Load += new System.EventHandler(this.FormatPasteDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ComboBoxSuportedFormatList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PasteIntoWindowButton;
        private System.Windows.Forms.Button CloseButton;
    }
}