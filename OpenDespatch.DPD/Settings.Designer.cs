namespace OpenDespatch.DPD
{
    partial class Settings
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
            this.OutputFolderTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.InputFolderTextBox = new System.Windows.Forms.TextBox();
            this.ftpFolderLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.folderGroupBox = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.DelimiterTextbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TemplatePathTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.folderGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // OutputFolderTextbox
            // 
            this.OutputFolderTextbox.Location = new System.Drawing.Point(136, 50);
            this.OutputFolderTextbox.Name = "OutputFolderTextbox";
            this.OutputFolderTextbox.Size = new System.Drawing.Size(350, 20);
            this.OutputFolderTextbox.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Output folder path";
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(480, 157);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 25);
            this.button2.TabIndex = 22;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // InputFolderTextBox
            // 
            this.InputFolderTextBox.Location = new System.Drawing.Point(136, 24);
            this.InputFolderTextBox.Name = "InputFolderTextBox";
            this.InputFolderTextBox.Size = new System.Drawing.Size(350, 20);
            this.InputFolderTextBox.TabIndex = 20;
            // 
            // ftpFolderLabel
            // 
            this.ftpFolderLabel.AutoSize = true;
            this.ftpFolderLabel.Location = new System.Drawing.Point(22, 24);
            this.ftpFolderLabel.Name = "ftpFolderLabel";
            this.ftpFolderLabel.Size = new System.Drawing.Size(84, 13);
            this.ftpFolderLabel.TabIndex = 21;
            this.ftpFolderLabel.Text = "Input folder path";
            // 
            // SaveButton
            // 
            this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveButton.Location = new System.Drawing.Point(394, 157);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(80, 25);
            this.SaveButton.TabIndex = 28;
            this.SaveButton.Text = "OK";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // folderGroupBox
            // 
            this.folderGroupBox.Controls.Add(this.button3);
            this.folderGroupBox.Controls.Add(this.button1);
            this.folderGroupBox.Controls.Add(this.DelimiterTextbox);
            this.folderGroupBox.Controls.Add(this.label2);
            this.folderGroupBox.Controls.Add(this.TemplatePathTextBox);
            this.folderGroupBox.Controls.Add(this.label3);
            this.folderGroupBox.Controls.Add(this.OutputFolderTextbox);
            this.folderGroupBox.Controls.Add(this.ftpFolderLabel);
            this.folderGroupBox.Controls.Add(this.InputFolderTextBox);
            this.folderGroupBox.Controls.Add(this.label1);
            this.folderGroupBox.Location = new System.Drawing.Point(12, 12);
            this.folderGroupBox.Name = "folderGroupBox";
            this.folderGroupBox.Size = new System.Drawing.Size(548, 139);
            this.folderGroupBox.TabIndex = 29;
            this.folderGroupBox.TabStop = false;
            this.folderGroupBox.Text = "Folder settings";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(492, 49);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(36, 23);
            this.button3.TabIndex = 33;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(492, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 23);
            this.button1.TabIndex = 32;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DelimiterTextbox
            // 
            this.DelimiterTextbox.Location = new System.Drawing.Point(136, 102);
            this.DelimiterTextbox.Name = "DelimiterTextbox";
            this.DelimiterTextbox.Size = new System.Drawing.Size(390, 20);
            this.DelimiterTextbox.TabIndex = 30;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 31;
            this.label2.Text = "Delimiter used:";
            // 
            // TemplatePathTextBox
            // 
            this.TemplatePathTextBox.Location = new System.Drawing.Point(136, 76);
            this.TemplatePathTextBox.Name = "TemplatePathTextBox";
            this.TemplatePathTextBox.Size = new System.Drawing.Size(390, 20);
            this.TemplatePathTextBox.TabIndex = 28;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Template file:";
            // 
            // Settings
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(572, 193);
            this.Controls.Add(this.folderGroupBox);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "DPD settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.folderGroupBox.ResumeLayout(false);
            this.folderGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox OutputFolderTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox InputFolderTextBox;
        private System.Windows.Forms.Label ftpFolderLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox folderGroupBox;
        private System.Windows.Forms.TextBox TemplatePathTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DelimiterTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    }
}