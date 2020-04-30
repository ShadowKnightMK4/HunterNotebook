namespace HunterNotebook
{
    partial class Printmaker
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
            this.PrintButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ShowStandardPrintDialog = new System.Windows.Forms.Button();
            this.ComboBoxTargetPrinter = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.ForceSingleFontCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ChooseFontCheckBox = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ComboBoxPageSize = new System.Windows.Forms.ComboBox();
            this.TextBoxNumberOfCopies = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // PrintButton
            // 
            this.PrintButton.Location = new System.Drawing.Point(581, 23);
            this.PrintButton.Name = "PrintButton";
            this.PrintButton.Size = new System.Drawing.Size(178, 39);
            this.PrintButton.TabIndex = 0;
            this.PrintButton.Text = "Print";
            this.PrintButton.UseVisualStyleBackColor = true;
            this.PrintButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(581, 68);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(178, 39);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // ShowStandardPrintDialog
            // 
            this.ShowStandardPrintDialog.Location = new System.Drawing.Point(581, 113);
            this.ShowStandardPrintDialog.Name = "ShowStandardPrintDialog";
            this.ShowStandardPrintDialog.Size = new System.Drawing.Size(178, 39);
            this.ShowStandardPrintDialog.TabIndex = 2;
            this.ShowStandardPrintDialog.Text = "Show System Dialog";
            this.ShowStandardPrintDialog.UseVisualStyleBackColor = true;
            this.ShowStandardPrintDialog.Click += new System.EventHandler(this.button3_Click);
            // 
            // ComboBoxTargetPrinter
            // 
            this.ComboBoxTargetPrinter.FormattingEnabled = true;
            this.ComboBoxTargetPrinter.Location = new System.Drawing.Point(31, 34);
            this.ComboBoxTargetPrinter.Name = "ComboBoxTargetPrinter";
            this.ComboBoxTargetPrinter.Size = new System.Drawing.Size(302, 28);
            this.ComboBoxTargetPrinter.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Location = new System.Drawing.Point(355, 191);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(168, 107);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Print Selection";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(15, 55);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(131, 24);
            this.radioButton2.TabIndex = 5;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Selected Text";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 25);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(85, 24);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "All Text";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // ForceSingleFontCheckBox
            // 
            this.ForceSingleFontCheckBox.AutoSize = true;
            this.ForceSingleFontCheckBox.Location = new System.Drawing.Point(6, 26);
            this.ForceSingleFontCheckBox.Name = "ForceSingleFontCheckBox";
            this.ForceSingleFontCheckBox.Size = new System.Drawing.Size(113, 24);
            this.ForceSingleFontCheckBox.TabIndex = 5;
            this.ForceSingleFontCheckBox.Text = "Force Font";
            this.ForceSingleFontCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ChooseFontCheckBox);
            this.groupBox2.Controls.Add(this.ForceSingleFontCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(355, 304);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Stylings";
            // 
            // ChooseFontCheckBox
            // 
            this.ChooseFontCheckBox.Location = new System.Drawing.Point(125, 25);
            this.ChooseFontCheckBox.Name = "ChooseFontCheckBox";
            this.ChooseFontCheckBox.Size = new System.Drawing.Size(46, 24);
            this.ChooseFontCheckBox.TabIndex = 7;
            this.ChooseFontCheckBox.Text = "...";
            this.ChooseFontCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TextBoxNumberOfCopies);
            this.groupBox3.Location = new System.Drawing.Point(356, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(167, 137);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Copies";
            // 
            // ComboBoxPageSize
            // 
            this.ComboBoxPageSize.FormattingEnabled = true;
            this.ComboBoxPageSize.Location = new System.Drawing.Point(31, 79);
            this.ComboBoxPageSize.Name = "ComboBoxPageSize";
            this.ComboBoxPageSize.Size = new System.Drawing.Size(302, 28);
            this.ComboBoxPageSize.TabIndex = 0;
            // 
            // TextBoxNumberOfCopies
            // 
            this.TextBoxNumberOfCopies.Location = new System.Drawing.Point(6, 34);
            this.TextBoxNumberOfCopies.Name = "TextBoxNumberOfCopies";
            this.TextBoxNumberOfCopies.Size = new System.Drawing.Size(37, 26);
            this.TextBoxNumberOfCopies.TabIndex = 0;
            this.TextBoxNumberOfCopies.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
            // 
            // Printmaker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ComboBoxPageSize);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.ComboBoxTargetPrinter);
            this.Controls.Add(this.ShowStandardPrintDialog);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.PrintButton);
            this.Name = "Printmaker";
            this.Text = "Printmaker";
            this.Load += new System.EventHandler(this.Printmaker_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PrintButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ShowStandardPrintDialog;
        private System.Windows.Forms.ComboBox ComboBoxTargetPrinter;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox ForceSingleFontCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button ChooseFontCheckBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox ComboBoxPageSize;
        private System.Windows.Forms.TextBox TextBoxNumberOfCopies;
    }
}