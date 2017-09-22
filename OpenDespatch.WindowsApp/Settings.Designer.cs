namespace OpenDespatch.WindowsApp
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
            this.button2 = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TestConnectionButton = new System.Windows.Forms.Button();
            this.PvxApiUsernameTextbox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.PvxApiPasswordTextbox = new System.Windows.Forms.TextBox();
            this.PvxApiClientIdTextbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.PvxApiUrlTextbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.folderGroupBox = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.ArchiveTextBox = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ftpFolderLabel = new System.Windows.Forms.Label();
            this.RulesPluginPathText = new System.Windows.Forms.TextBox();
            this.PluginPathTextBox = new System.Windows.Forms.TextBox();
            this.DownloadFolderTextBox = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox2.SuspendLayout();
            this.folderGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(480, 334);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 25);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.SaveButton.Location = new System.Drawing.Point(394, 334);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(80, 25);
            this.SaveButton.TabIndex = 2;
            this.SaveButton.Text = "OK";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TestConnectionButton);
            this.groupBox2.Controls.Add(this.PvxApiUsernameTextbox);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.PvxApiPasswordTextbox);
            this.groupBox2.Controls.Add(this.PvxApiClientIdTextbox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.PvxApiUrlTextbox);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(12, 159);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(548, 169);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "API settings";
            // 
            // TestConnectionButton
            // 
            this.TestConnectionButton.Location = new System.Drawing.Point(409, 130);
            this.TestConnectionButton.Name = "TestConnectionButton";
            this.TestConnectionButton.Size = new System.Drawing.Size(117, 24);
            this.TestConnectionButton.TabIndex = 4;
            this.TestConnectionButton.Text = "Test connection";
            this.TestConnectionButton.UseVisualStyleBackColor = true;
            this.TestConnectionButton.Click += new System.EventHandler(this.TestConnectionButton_Click);
            // 
            // PvxApiUsernameTextbox
            // 
            this.PvxApiUsernameTextbox.Location = new System.Drawing.Point(136, 78);
            this.PvxApiUsernameTextbox.Name = "PvxApiUsernameTextbox";
            this.PvxApiUsernameTextbox.Size = new System.Drawing.Size(390, 20);
            this.PvxApiUsernameTextbox.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "ClientId";
            // 
            // PvxApiPasswordTextbox
            // 
            this.PvxApiPasswordTextbox.Location = new System.Drawing.Point(136, 104);
            this.PvxApiPasswordTextbox.Name = "PvxApiPasswordTextbox";
            this.PvxApiPasswordTextbox.Size = new System.Drawing.Size(390, 20);
            this.PvxApiPasswordTextbox.TabIndex = 3;
            this.PvxApiPasswordTextbox.UseSystemPasswordChar = true;
            // 
            // PvxApiClientIdTextbox
            // 
            this.PvxApiClientIdTextbox.Location = new System.Drawing.Point(136, 52);
            this.PvxApiClientIdTextbox.Name = "PvxApiClientIdTextbox";
            this.PvxApiClientIdTextbox.Size = new System.Drawing.Size(390, 20);
            this.PvxApiClientIdTextbox.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 13);
            this.label8.TabIndex = 27;
            this.label8.Text = "Username";
            // 
            // PvxApiUrlTextbox
            // 
            this.PvxApiUrlTextbox.Location = new System.Drawing.Point(136, 26);
            this.PvxApiUrlTextbox.Name = "PvxApiUrlTextbox";
            this.PvxApiUrlTextbox.Size = new System.Drawing.Size(390, 20);
            this.PvxApiUrlTextbox.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(22, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "PeopleVox API Url";
            // 
            // folderGroupBox
            // 
            this.folderGroupBox.Controls.Add(this.button4);
            this.folderGroupBox.Controls.Add(this.label2);
            this.folderGroupBox.Controls.Add(this.ArchiveTextBox);
            this.folderGroupBox.Controls.Add(this.button3);
            this.folderGroupBox.Controls.Add(this.button1);
            this.folderGroupBox.Controls.Add(this.label3);
            this.folderGroupBox.Controls.Add(this.label1);
            this.folderGroupBox.Controls.Add(this.ftpFolderLabel);
            this.folderGroupBox.Controls.Add(this.RulesPluginPathText);
            this.folderGroupBox.Controls.Add(this.PluginPathTextBox);
            this.folderGroupBox.Controls.Add(this.DownloadFolderTextBox);
            this.folderGroupBox.Location = new System.Drawing.Point(12, 12);
            this.folderGroupBox.Name = "folderGroupBox";
            this.folderGroupBox.Size = new System.Drawing.Size(548, 137);
            this.folderGroupBox.TabIndex = 0;
            this.folderGroupBox.TabStop = false;
            this.folderGroupBox.Text = "Folder settings";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(490, 48);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(36, 23);
            this.button4.TabIndex = 23;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Archive folder";
            // 
            // ArchiveTextBox
            // 
            this.ArchiveTextBox.Location = new System.Drawing.Point(136, 50);
            this.ArchiveTextBox.Name = "ArchiveTextBox";
            this.ArchiveTextBox.Size = new System.Drawing.Size(348, 20);
            this.ArchiveTextBox.TabIndex = 22;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(490, 74);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(36, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(490, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Rules plugin";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Plugins folder";
            // 
            // ftpFolderLabel
            // 
            this.ftpFolderLabel.AutoSize = true;
            this.ftpFolderLabel.Location = new System.Drawing.Point(22, 24);
            this.ftpFolderLabel.Name = "ftpFolderLabel";
            this.ftpFolderLabel.Size = new System.Drawing.Size(89, 13);
            this.ftpFolderLabel.TabIndex = 21;
            this.ftpFolderLabel.Text = "Downloads folder";
            // 
            // RulesPluginPathText
            // 
            this.RulesPluginPathText.Location = new System.Drawing.Point(136, 101);
            this.RulesPluginPathText.Name = "RulesPluginPathText";
            this.RulesPluginPathText.Size = new System.Drawing.Size(348, 20);
            this.RulesPluginPathText.TabIndex = 0;
            // 
            // PluginPathTextBox
            // 
            this.PluginPathTextBox.Location = new System.Drawing.Point(136, 76);
            this.PluginPathTextBox.Name = "PluginPathTextBox";
            this.PluginPathTextBox.Size = new System.Drawing.Size(348, 20);
            this.PluginPathTextBox.TabIndex = 0;
            // 
            // DownloadFolderTextBox
            // 
            this.DownloadFolderTextBox.Location = new System.Drawing.Point(136, 24);
            this.DownloadFolderTextBox.Name = "DownloadFolderTextBox";
            this.DownloadFolderTextBox.Size = new System.Drawing.Size(348, 20);
            this.DownloadFolderTextBox.TabIndex = 0;
            // 
            // Settings
            // 
            this.AcceptButton = this.SaveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(572, 367);
            this.Controls.Add(this.folderGroupBox);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.button2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.folderGroupBox.ResumeLayout(false);
            this.folderGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button TestConnectionButton;
        private System.Windows.Forms.TextBox PvxApiUsernameTextbox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox PvxApiPasswordTextbox;
        private System.Windows.Forms.TextBox PvxApiClientIdTextbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox PvxApiUrlTextbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox folderGroupBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ftpFolderLabel;
        private System.Windows.Forms.TextBox DownloadFolderTextBox;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PluginPathTextBox;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ArchiveTextBox;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RulesPluginPathText;
    }
}