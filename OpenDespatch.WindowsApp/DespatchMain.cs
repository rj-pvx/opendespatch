using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Configuration;
using System.Windows.Forms;
using System.Configuration;
using System.Xml.Linq;
using System.Xml;
using OpenDespatch.Entities;

namespace OpenDespatch.WindowsApp
{
    public partial class DespatchMain : BaseForm
    {
        #region Private Fields
        string currentFile;
        bool isProcessing = false;
        DespatchBasePlugin currentPlugin;
        #endregion

        #region ctor

        public DespatchMain()
        {
            InitializeComponent();
            logRichy = LogRichText;
        }

        #endregion         

        #region Private Methods

        private bool ProcessData()
        {
            if (!string.IsNullOrEmpty(PreviewTextbox.Text))
                return false;

            CheckButton.Enabled = false;
            CurrentProcessStatusLabel.Text = "Checking download for despatch file";
            currentFile = FileOperations.GetFirstFileInFolder(Settings.DownloadPath, "*.pvx");
            if (!string.IsNullOrEmpty(currentFile))
            {
                WriteLog(string.Format("Reading file {0}", currentFile), Color.Black);
                //read file
                var content = FileOperations.ReadFile(currentFile);
                //Find the right plugin to process.
                currentPlugin = DespatchPluginFactory.GetPlugin(content);
                if (currentPlugin != null)
                {
                    PreviewTextbox.Text = "";
                    WriteLog(string.Format("Waiting to be processed by {0}", currentPlugin.PluginName), Color.Black);
                    UpdateTextBox(PreviewTextbox, currentPlugin.GetPreview());
                    CurrentProcessStatusLabel.Text = "Previewing despatch file for " + currentPlugin.SalesOrderNumber;
                }
            }
            else
            {
                PreviewTextbox.Text = "";
                CheckButton.Enabled = true;
                WriteLog("No file found.", Color.Black);
                CurrentProcessStatusLabel.Text = "No file found.";
            }
            if (!AutoCheck.Checked) CheckButton.Enabled = true;
            return false;
        }

        private bool SendData()
        {
            if (currentPlugin != null)
            {
                CurrentProcessStatusLabel.Text = string.Format("Sending file to {0} for {1}", currentPlugin.PluginName, currentPlugin.SalesOrderNumber);
                currentPlugin.Send(PreviewTextbox.Text);
                return true;
            }
            else
            {
                WriteLog("No matching carrier plugin found to process data.", Color.Red);
                CurrentProcessStatusLabel.Text = "No matching carrier plugin found to process data.";
                return false;
            }
        }

        void currentPlugin_OnResultReceived(object sender, EventArgs e)
        {
            UpdateTextBox(FeedbackTextBox, currentPlugin.Result);
            if (string.IsNullOrEmpty(currentPlugin.TrackingNumber))
            {
                WriteLog("No tracking number received.", Color.Red);
                CurrentProcessStatusLabel.Text = "No tracking number received.";
            }
            else
            {
                if (UpdateTrackingNumber())
                {
                    if (!String.IsNullOrEmpty(Settings.ArchivePath))
                        FileOperations.ArchiveFile(currentFile, Settings.ArchivePath);
                    else
                        FileOperations.DeleteFile(currentFile);

                    PreviewTextbox.Clear();
                    FeedbackTextBox.Clear();
                    CheckButton.Enabled = true;
                    currentPlugin = null;
                }
            }
        }

        private bool UpdateTrackingNumber()
        {
            if (currentPlugin != null && !string.IsNullOrEmpty(currentPlugin.TrackingNumber))
            {
                CurrentProcessStatusLabel.Text = "Updating Peoplevox system.";
                //Send tracking number via save request
                if (PeoplevoxProxy.SaveTrackingNumber(currentPlugin.SalesOrderNumber, currentPlugin.TrackingNumber))
                {
                    //Write log
                    WriteLog(String.Format("Tracking number {0} sent to PVX.", currentPlugin.TrackingNumber), Color.Green);
                    CurrentProcessStatusLabel.Text = "Tracking number sent to PVX.";
                    return true;
                }
                else
                {
                    WriteLog(String.Format("Error sending tracking number : {0}.", PeoplevoxProxy.LastError), Color.Red);
                    CurrentProcessStatusLabel.Text = "Error sending tracking number.";
                    return true; //If this is false it may repeatedly despatch in the carrier!
                }
            }
            CheckButton.Enabled = true;
            return false;
        }

        #endregion

        #region Private Utility Methods

        private void LoginToApi()
        {
            if (!PeoplevoxProxy.IsServiceAvailable)
            {
                ConnectionStatusLabel.Text = "PVX API:Disconnected";
                ConnectionStatusLabel.BackColor = Color.Red;
            }
            else
            {
                ConnectionStatusLabel.Text = "PVX API:Connected";
                ConnectionStatusLabel.BackColor = Color.Green;
            }
        }

        private void LoadPlugins()
        {
            for (int i = settingsToolStripMenuItem.DropDownItems.Count-1; i >= 0; i--)
            {
                ToolStripItem menuItem = settingsToolStripMenuItem.DropDownItems[i];
                if (menuItem.Tag != null)
                {
                    settingsToolStripMenuItem.DropDownItems.RemoveAt(i);
                }
            }

            if (Directory.Exists(Properties.Settings.Default.PluginPath))
            {
                if (!String.IsNullOrEmpty(Properties.Settings.Default.RulesSetting))
                {
                    DespatchRulesFactory.LoadDespatchRulesPlugin(Properties.Settings.Default.PluginPath, Properties.Settings.Default.RulesSetting);
                    WriteLog("Logic rules loaded.", Color.Black);
                }
                else
                {
                    WriteLog("No extra logic rules loaded.", Color.Black);
                }

                var plugins = DespatchPluginFactory.LoadPlugins(Properties.Settings.Default.PluginPath, 
                    this, new EventHandler(currentPlugin_OnResultReceived));
                if (plugins.Count <= 0)
                {
                    CurrentProcessStatusLabel.Text = "No plugins found";
                }
                else
                {
                    foreach (var plugin in plugins)
                    {
                        ToolStripMenuItem pluginSetting = new ToolStripMenuItem(string.Format("{0} settings...", plugin.PluginName));
                        pluginSetting.Tag = plugin;
                        pluginSetting.Click += pluginSetting_Click;
                        settingsToolStripMenuItem.DropDownItems.Insert(0, pluginSetting);
                    }
                    CurrentProcessStatusLabel.Text = "Ready";
                }
            }
            else
            {
                CurrentProcessStatusLabel.Text = "Unable to find plugin folder";
            }
        }

        private void UpdateTextBox(TextBox txt, string data)
        {
            if (data == null) return;
            txt.AppendText(data);
            txt.SelectionStart = txt.TextLength;
            txt.ScrollToCaret();
            txt.Invalidate();
            Application.DoEvents();
        }

        #endregion

        #region Form Events

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var frm = new Settings())
            {
                frm.ShowDialog();
            }
        }

        private void DownloadChecker_Tick(object sender, EventArgs e)
        {
            //TODO: Check Session state instead of Login
            LoginToApi();
            if (AutoCheck.Checked)
            {
                //Generate carrier file from template
                ProcessData();
                //Send the data straight to Carrier if auto send is on.
                SendData();
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            SendData();
        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            ProcessData();
        }

        private void AutoCheck_CheckedChanged(object sender, EventArgs e)
        {

            if (AutoCheck.Checked)
            {
                AutoCheck.Text = "OFF";
            }
            else
            {
                AutoCheck.Text = "ON";
                StopAsyncTasks();
            }
            SendButton.Enabled = !AutoCheck.Checked;
            CheckButton.Enabled = !AutoCheck.Checked;
        }
        
        private void ReloadPluginsMenuItem_Click(object sender, EventArgs e)
        {
            LoadPlugins();
        }

        private void StopAsyncTasks()
        {
            if (currentPlugin != null)
                currentPlugin.AbortAsycWaitThread();
        }

        void pluginSetting_Click(object sender, EventArgs e)
        {
            var plugin = (sender as ToolStripItem).Tag as DespatchBasePlugin;
            if (plugin != null)
            {
                plugin.ShowSettingsWindow();
            }
        }

        private void DespatchMain_Load(object sender, EventArgs e)
        {
            LoadPlugins();
        }

        private void RetrySaveTrackingNoButton_Click(object sender, EventArgs e)
        {
            UpdateTrackingNumber();
        }

        private void PreviewTextbox_TextChanged(object sender, EventArgs e)
        {
            //enable check button when user deletes the text in the preview box
            if (string.IsNullOrEmpty(PreviewTextbox.Text)) CheckButton.Enabled = true;
        }

        private void DespatchMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopAsyncTasks();
        }

        #endregion

        private void skipButton_Click(object sender, EventArgs e)
        {
            StopAsyncTasks();
            //Archive File.
            if (!String.IsNullOrEmpty(Settings.ArchivePath) && !String.IsNullOrEmpty(currentFile))
                FileOperations.ArchiveFile(currentFile, Settings.ArchivePath);
            else
                FileOperations.DeleteFile(currentFile);

            PreviewTextbox.Clear();
            FeedbackTextBox.Clear();
            CheckButton.Enabled = true;
            currentPlugin = null;
        }
    }
}
