namespace OpenDespatch.WindowsApp
{
    partial class DespatchMain
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
            this.components = new System.ComponentModel.Container();
            this.SendButton = new System.Windows.Forms.Button();
            this.PreviewTextbox = new System.Windows.Forms.TextBox();
            this.downloadChecker = new System.Windows.Forms.Timer(this.components);
            this.appStatusStrip = new System.Windows.Forms.StatusStrip();
            this.CurrentProcessStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ConnectionStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.appMainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReloadPluginsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.RetrySaveTrackingNoButton = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AutoCheck = new System.Windows.Forms.CheckBox();
            this.CheckButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.LeftSplitContainer = new System.Windows.Forms.SplitContainer();
            this.FeedbackTextBox = new System.Windows.Forms.TextBox();
            this.LogRichText = new System.Windows.Forms.RichTextBox();
            this.skipButton = new System.Windows.Forms.Button();
            this.appStatusStrip.SuspendLayout();
            this.appMainMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftSplitContainer)).BeginInit();
            this.LeftSplitContainer.Panel1.SuspendLayout();
            this.LeftSplitContainer.Panel2.SuspendLayout();
            this.LeftSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // SendButton
            // 
            this.SendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.SendButton.Location = new System.Drawing.Point(602, 0);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(118, 30);
            this.SendButton.TabIndex = 1;
            this.SendButton.Text = "Send Now";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // PreviewTextbox
            // 
            this.PreviewTextbox.AcceptsTab = true;
            this.PreviewTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PreviewTextbox.Location = new System.Drawing.Point(0, 30);
            this.PreviewTextbox.Multiline = true;
            this.PreviewTextbox.Name = "PreviewTextbox";
            this.PreviewTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.PreviewTextbox.Size = new System.Drawing.Size(723, 252);
            this.PreviewTextbox.TabIndex = 1;
            this.PreviewTextbox.TextChanged += new System.EventHandler(this.PreviewTextbox_TextChanged);
            // 
            // downloadChecker
            // 
            this.downloadChecker.Enabled = true;
            this.downloadChecker.Interval = 10000;
            this.downloadChecker.Tick += new System.EventHandler(this.DownloadChecker_Tick);
            // 
            // appStatusStrip
            // 
            this.appStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CurrentProcessStatusLabel,
            this.ConnectionStatusLabel});
            this.appStatusStrip.Location = new System.Drawing.Point(0, 589);
            this.appStatusStrip.Name = "appStatusStrip";
            this.appStatusStrip.Size = new System.Drawing.Size(991, 22);
            this.appStatusStrip.TabIndex = 28;
            this.appStatusStrip.Text = "statusStrip1";
            // 
            // CurrentProcessStatusLabel
            // 
            this.CurrentProcessStatusLabel.Name = "CurrentProcessStatusLabel";
            this.CurrentProcessStatusLabel.Size = new System.Drawing.Size(866, 17);
            this.CurrentProcessStatusLabel.Spring = true;
            this.CurrentProcessStatusLabel.Text = "Waiting for download...";
            this.CurrentProcessStatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConnectionStatusLabel
            // 
            this.ConnectionStatusLabel.BackColor = System.Drawing.Color.Green;
            this.ConnectionStatusLabel.Name = "ConnectionStatusLabel";
            this.ConnectionStatusLabel.Size = new System.Drawing.Size(110, 17);
            this.ConnectionStatusLabel.Text = "PVX API:Connected";
            // 
            // appMainMenu
            // 
            this.appMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem});
            this.appMainMenu.Location = new System.Drawing.Point(0, 0);
            this.appMainMenu.Name = "appMainMenu";
            this.appMainMenu.Size = new System.Drawing.Size(991, 24);
            this.appMainMenu.TabIndex = 0;
            this.appMainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ReloadPluginsMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // ReloadPluginsMenuItem
            // 
            this.ReloadPluginsMenuItem.Name = "ReloadPluginsMenuItem";
            this.ReloadPluginsMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ReloadPluginsMenuItem.Text = "Reload plugins";
            this.ReloadPluginsMenuItem.Click += new System.EventHandler(this.ReloadPluginsMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.optionsToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(122, 6);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.optionsToolStripMenuItem.Text = "Options...";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.OptionsToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.skipButton);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.RetrySaveTrackingNoButton);
            this.panel1.Controls.Add(this.SendButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(723, 30);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Feedback";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RetrySaveTrackingNoButton
            // 
            this.RetrySaveTrackingNoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.RetrySaveTrackingNoButton.Location = new System.Drawing.Point(354, 0);
            this.RetrySaveTrackingNoButton.Name = "RetrySaveTrackingNoButton";
            this.RetrySaveTrackingNoButton.Size = new System.Drawing.Size(118, 30);
            this.RetrySaveTrackingNoButton.TabIndex = 0;
            this.RetrySaveTrackingNoButton.Text = "Retry Save";
            this.RetrySaveTrackingNoButton.UseVisualStyleBackColor = true;
            this.RetrySaveTrackingNoButton.Visible = false;
            this.RetrySaveTrackingNoButton.Click += new System.EventHandler(this.RetrySaveTrackingNoButton_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.AutoCheck);
            this.panel2.Controls.Add(this.CheckButton);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(723, 30);
            this.panel2.TabIndex = 0;
            // 
            // AutoCheck
            // 
            this.AutoCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AutoCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.AutoCheck.Location = new System.Drawing.Point(478, 0);
            this.AutoCheck.Name = "AutoCheck";
            this.AutoCheck.Size = new System.Drawing.Size(118, 30);
            this.AutoCheck.TabIndex = 0;
            this.AutoCheck.Text = "ON";
            this.AutoCheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AutoCheck.UseVisualStyleBackColor = true;
            this.AutoCheck.CheckedChanged += new System.EventHandler(this.AutoCheck_CheckedChanged);
            this.AutoCheck.Click += new System.EventHandler(this.AutoCheck_CheckedChanged);
            // 
            // CheckButton
            // 
            this.CheckButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckButton.Location = new System.Drawing.Point(602, 0);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(118, 30);
            this.CheckButton.TabIndex = 1;
            this.CheckButton.Text = "Check Now";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Preview";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 24);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.LeftSplitContainer);
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.LogRichText);
            this.MainSplitContainer.Size = new System.Drawing.Size(991, 565);
            this.MainSplitContainer.SplitterDistance = 723;
            this.MainSplitContainer.TabIndex = 30;
            // 
            // LeftSplitContainer
            // 
            this.LeftSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.LeftSplitContainer.Name = "LeftSplitContainer";
            this.LeftSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // LeftSplitContainer.Panel1
            // 
            this.LeftSplitContainer.Panel1.Controls.Add(this.PreviewTextbox);
            this.LeftSplitContainer.Panel1.Controls.Add(this.panel2);
            // 
            // LeftSplitContainer.Panel2
            // 
            this.LeftSplitContainer.Panel2.Controls.Add(this.FeedbackTextBox);
            this.LeftSplitContainer.Panel2.Controls.Add(this.panel1);
            this.LeftSplitContainer.Size = new System.Drawing.Size(723, 565);
            this.LeftSplitContainer.SplitterDistance = 282;
            this.LeftSplitContainer.TabIndex = 33;
            // 
            // FeedbackTextBox
            // 
            this.FeedbackTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FeedbackTextBox.Location = new System.Drawing.Point(0, 30);
            this.FeedbackTextBox.Multiline = true;
            this.FeedbackTextBox.Name = "FeedbackTextBox";
            this.FeedbackTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.FeedbackTextBox.Size = new System.Drawing.Size(723, 249);
            this.FeedbackTextBox.TabIndex = 1;
            // 
            // LogRichText
            // 
            this.LogRichText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogRichText.Location = new System.Drawing.Point(0, 0);
            this.LogRichText.Name = "LogRichText";
            this.LogRichText.Size = new System.Drawing.Size(264, 565);
            this.LogRichText.TabIndex = 0;
            this.LogRichText.Text = "";
            // 
            // skipButton
            // 
            this.skipButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.skipButton.Location = new System.Drawing.Point(478, 0);
            this.skipButton.Name = "skipButton";
            this.skipButton.Size = new System.Drawing.Size(118, 30);
            this.skipButton.TabIndex = 2;
            this.skipButton.Text = "Skip Current";
            this.skipButton.UseVisualStyleBackColor = true;
            this.skipButton.Click += new System.EventHandler(this.skipButton_Click);
            // 
            // DespatchMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 611);
            this.Controls.Add(this.MainSplitContainer);
            this.Controls.Add(this.appStatusStrip);
            this.Controls.Add(this.appMainMenu);
            this.MainMenuStrip = this.appMainMenu;
            this.Name = "DespatchMain";
            this.ShowIcon = false;
            this.Text = "Despatch Application";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DespatchMain_FormClosing);
            this.Load += new System.EventHandler(this.DespatchMain_Load);
            this.appStatusStrip.ResumeLayout(false);
            this.appStatusStrip.PerformLayout();
            this.appMainMenu.ResumeLayout(false);
            this.appMainMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.LeftSplitContainer.Panel1.ResumeLayout(false);
            this.LeftSplitContainer.Panel1.PerformLayout();
            this.LeftSplitContainer.Panel2.ResumeLayout(false);
            this.LeftSplitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftSplitContainer)).EndInit();
            this.LeftSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.TextBox PreviewTextbox;
        private System.Windows.Forms.Timer downloadChecker;
        private System.Windows.Forms.StatusStrip appStatusStrip;
        private System.Windows.Forms.MenuStrip appMainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button CheckButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripStatusLabel CurrentProcessStatusLabel;
        private System.Windows.Forms.ToolStripStatusLabel ConnectionStatusLabel;
        private System.Windows.Forms.CheckBox AutoCheck;
        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.SplitContainer LeftSplitContainer;
        private System.Windows.Forms.RichTextBox LogRichText;
        private System.Windows.Forms.ToolStripMenuItem ReloadPluginsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.TextBox FeedbackTextBox;
        private System.Windows.Forms.Button RetrySaveTrackingNoButton;
        private System.Windows.Forms.Button skipButton;
    }
}