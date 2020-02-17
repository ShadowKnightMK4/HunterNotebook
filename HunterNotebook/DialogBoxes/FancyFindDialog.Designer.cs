namespace HunterNotebook
{
    partial class FancyFindDialog
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
            this.TextBoxFindText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TextBoxReplaceText = new System.Windows.Forms.TextBox();
            this.ButtonFind = new System.Windows.Forms.Button();
            this.ButtonFindNext = new System.Windows.Forms.Button();
            this.ButtonReplaceText = new System.Windows.Forms.Button();
            this.CheckBoxMatchWholeWord = new System.Windows.Forms.CheckBox();
            this.CheckBoxMatchCase = new System.Windows.Forms.CheckBox();
            this.CheckboxReplaceTextAutoGo = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxFindText
            // 
            this.TextBoxFindText.Location = new System.Drawing.Point(6, 22);
            this.TextBoxFindText.Name = "TextBoxFindText";
            this.TextBoxFindText.Size = new System.Drawing.Size(384, 26);
            this.TextBoxFindText.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TextBoxFindText);
            this.groupBox1.Location = new System.Drawing.Point(44, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(417, 54);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Find Text";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TextBoxReplaceText);
            this.groupBox2.Location = new System.Drawing.Point(44, 85);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(417, 54);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Replacement Text";
            // 
            // TextBoxReplaceText
            // 
            this.TextBoxReplaceText.Location = new System.Drawing.Point(6, 22);
            this.TextBoxReplaceText.Name = "TextBoxReplaceText";
            this.TextBoxReplaceText.Size = new System.Drawing.Size(384, 26);
            this.TextBoxReplaceText.TabIndex = 0;
            // 
            // ButtonFind
            // 
            this.ButtonFind.Location = new System.Drawing.Point(746, 13);
            this.ButtonFind.Name = "ButtonFind";
            this.ButtonFind.Size = new System.Drawing.Size(147, 39);
            this.ButtonFind.TabIndex = 4;
            this.ButtonFind.Text = "Find";
            this.ButtonFind.UseVisualStyleBackColor = true;
            this.ButtonFind.Click += new System.EventHandler(this.ButtonFind_Click);
            // 
            // ButtonFindNext
            // 
            this.ButtonFindNext.Location = new System.Drawing.Point(746, 58);
            this.ButtonFindNext.Name = "ButtonFindNext";
            this.ButtonFindNext.Size = new System.Drawing.Size(147, 39);
            this.ButtonFindNext.TabIndex = 5;
            this.ButtonFindNext.Text = "Find Next";
            this.ButtonFindNext.UseVisualStyleBackColor = true;
            this.ButtonFindNext.Click += new System.EventHandler(this.ButtonFindNext_Click);
            // 
            // ButtonReplaceText
            // 
            this.ButtonReplaceText.Location = new System.Drawing.Point(746, 107);
            this.ButtonReplaceText.Name = "ButtonReplaceText";
            this.ButtonReplaceText.Size = new System.Drawing.Size(147, 39);
            this.ButtonReplaceText.TabIndex = 6;
            this.ButtonReplaceText.Text = "Replace";
            this.ButtonReplaceText.UseVisualStyleBackColor = true;
            this.ButtonReplaceText.Click += new System.EventHandler(this.ButtonReplaceText_Click);
            // 
            // CheckBoxMatchWholeWord
            // 
            this.CheckBoxMatchWholeWord.AutoSize = true;
            this.CheckBoxMatchWholeWord.Location = new System.Drawing.Point(44, 163);
            this.CheckBoxMatchWholeWord.Name = "CheckBoxMatchWholeWord";
            this.CheckBoxMatchWholeWord.Size = new System.Drawing.Size(170, 24);
            this.CheckBoxMatchWholeWord.TabIndex = 7;
            this.CheckBoxMatchWholeWord.Text = "Match Whole Word";
            this.CheckBoxMatchWholeWord.UseVisualStyleBackColor = true;
            // 
            // CheckBoxMatchCase
            // 
            this.CheckBoxMatchCase.AutoSize = true;
            this.CheckBoxMatchCase.Location = new System.Drawing.Point(44, 193);
            this.CheckBoxMatchCase.Name = "CheckBoxMatchCase";
            this.CheckBoxMatchCase.Size = new System.Drawing.Size(120, 24);
            this.CheckBoxMatchCase.TabIndex = 8;
            this.CheckBoxMatchCase.Text = "Match Case";
            this.CheckBoxMatchCase.UseVisualStyleBackColor = true;
            // 
            // CheckboxReplaceTextAutoGo
            // 
            this.CheckboxReplaceTextAutoGo.AutoSize = true;
            this.CheckboxReplaceTextAutoGo.Location = new System.Drawing.Point(230, 163);
            this.CheckboxReplaceTextAutoGo.Name = "CheckboxReplaceTextAutoGo";
            this.CheckboxReplaceTextAutoGo.Size = new System.Drawing.Size(202, 24);
            this.CheckboxReplaceTextAutoGo.TabIndex = 9;
            this.CheckboxReplaceTextAutoGo.Text = "Replace Text Advances";
            this.CheckboxReplaceTextAutoGo.UseVisualStyleBackColor = true;
            // 
            // FancyFindDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 256);
            this.Controls.Add(this.CheckboxReplaceTextAutoGo);
            this.Controls.Add(this.CheckBoxMatchCase);
            this.Controls.Add(this.CheckBoxMatchWholeWord);
            this.Controls.Add(this.ButtonReplaceText);
            this.Controls.Add(this.ButtonFindNext);
            this.Controls.Add(this.ButtonFind);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FancyFindDialog";
            this.Text = "FancyFindDialog";
            this.Load += new System.EventHandler(this.FancyFindDialog_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxFindText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TextBoxReplaceText;
        private System.Windows.Forms.Button ButtonFind;
        private System.Windows.Forms.Button ButtonFindNext;
        private System.Windows.Forms.Button ButtonReplaceText;
        private System.Windows.Forms.CheckBox CheckBoxMatchWholeWord;
        private System.Windows.Forms.CheckBox CheckBoxMatchCase;
        private System.Windows.Forms.CheckBox CheckboxReplaceTextAutoGo;
    }
}