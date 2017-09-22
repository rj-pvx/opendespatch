using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenDespatch.WindowsApp
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        public static string DownloadPath
        {
            get
            {
                var downloadPath = Properties.Settings.Default.DownloadPath;
                if (string.IsNullOrEmpty(downloadPath))
                    return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");
                else
                    return downloadPath;
            }
        }

        public static string ArchivePath
        {
            get
            {
                var archivePath = Properties.Settings.Default.ArchivePath;
                if (string.IsNullOrEmpty(archivePath))
                    return Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads"), "Archive");
                else
                    return archivePath;
            }
        }

        public static string RulesSettings
        {
            get
            {
                //"OpenDespatch.CountryAttireRules.dll";
                var rulesSettings = Properties.Settings.Default.RulesSetting;
                return rulesSettings;
            }
        }

        string oldDownloadPath = DownloadPath;
        string oldArchivePath = ArchivePath;
        string oldRulesSettings = RulesSettings;
        string oldPluginPath = Properties.Settings.Default.PluginPath;
        string oldApiUrl = Properties.Settings.Default.PvxApiUrl;
        string oldClientId = Properties.Settings.Default.PvxClientId;
        string oldUsername = Properties.Settings.Default.PvxUsername;
        string oldPassword = Properties.Settings.Default.PvxPassword;

        private void Settings_Load(object sender, EventArgs e)
        {
            DownloadFolderTextBox.Text = DownloadPath;
            ArchiveTextBox.Text = ArchivePath;
            PluginPathTextBox.Text = Properties.Settings.Default.PluginPath;
            PvxApiUrlTextbox.Text = Properties.Settings.Default.PvxApiUrl;
            PvxApiClientIdTextbox.Text = Properties.Settings.Default.PvxClientId;
            PvxApiUsernameTextbox.Text = Properties.Settings.Default.PvxUsername;
            PvxApiPasswordTextbox.Text = Properties.Settings.Default.PvxPassword;
            RulesPluginPathText.Text = Properties.Settings.Default.RulesSetting;
        }

        private void TestConnectionButton_Click(object sender, EventArgs e)
        {
            UpdateSettingFromUIValues();
            if (!PeoplevoxProxy.IsTestServiceSuccessful)
                MessageBox.Show("Test Failed");
            else
                MessageBox.Show("Test Succeeded");
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            UpdateSettingFromUIValues();
            Properties.Settings.Default.Save();
        }

        private void UpdateSettingFromUIValues()
        {
            Properties.Settings.Default.PluginPath = PluginPathTextBox.Text;
            Properties.Settings.Default.DownloadPath = DownloadFolderTextBox.Text;
            Properties.Settings.Default.ArchivePath = ArchiveTextBox.Text;
            Properties.Settings.Default.PvxApiUrl = PvxApiUrlTextbox.Text;
            Properties.Settings.Default.PvxClientId = PvxApiClientIdTextbox.Text;
            Properties.Settings.Default.PvxUsername = PvxApiUsernameTextbox.Text;
            Properties.Settings.Default.PvxPassword = PvxApiPasswordTextbox.Text;
            Properties.Settings.Default.RulesSetting = RulesPluginPathText.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.DownloadPath = oldDownloadPath;
            Properties.Settings.Default.ArchivePath = oldArchivePath;
            Properties.Settings.Default.PluginPath = oldPluginPath;
            Properties.Settings.Default.PvxApiUrl = oldApiUrl;
            Properties.Settings.Default.PvxClientId = oldClientId;
            Properties.Settings.Default.PvxUsername = oldUsername;
            Properties.Settings.Default.PvxPassword = oldPassword;
            Properties.Settings.Default.RulesSetting = oldRulesSettings;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChooseFolder(DownloadFolderTextBox);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ChooseFolder(ArchiveTextBox);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChooseFolder(PluginPathTextBox);
        }

        private void ChooseFolder(TextBox tb)
        {
            folderBrowserDialog1.SelectedPath = string.IsNullOrEmpty(tb.Text) ? "" : tb.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                tb.Text = folderBrowserDialog1.SelectedPath;
        }
       
    }
}
