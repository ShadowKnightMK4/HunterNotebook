namespace HunterNotebook
{
    partial class NotebookFormatBookBuddy
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TextBoxListEdit = new System.Windows.Forms.TextBox();
            this.ListBoxBookMarks = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(318, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 37);
            this.button1.TabIndex = 1;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(318, 55);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 31);
            this.button2.TabIndex = 2;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TextBoxListEdit
            // 
            this.TextBoxListEdit.Location = new System.Drawing.Point(12, -6);
            this.TextBoxListEdit.Name = "TextBoxListEdit";
            this.TextBoxListEdit.Size = new System.Drawing.Size(100, 26);
            this.TextBoxListEdit.TabIndex = 3;
            // 
            // ListBoxBookMarks
            // 
            this.ListBoxBookMarks.FormattingEnabled = true;
            this.ListBoxBookMarks.ItemHeight = 20;
            this.ListBoxBookMarks.Location = new System.Drawing.Point(12, 38);
            this.ListBoxBookMarks.Name = "ListBoxBookMarks";
            this.ListBoxBookMarks.Size = new System.Drawing.Size(268, 384);
            this.ListBoxBookMarks.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(318, 92);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 40);
            this.button3.TabIndex = 5;
            this.button3.Text = "Follow";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // NotebookFormatBookBuddy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 450);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.ListBoxBookMarks);
            this.Controls.Add(this.TextBoxListEdit);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "NotebookFormatBookBuddy";
            this.Text = "NotebookFormatBookBuddy";
            this.Load += new System.EventHandler(this.NotebookFormatBookBuddy_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TextBoxListEdit;
        private System.Windows.Forms.ListBox ListBoxBookMarks;
        private System.Windows.Forms.Button button3;
    }
}