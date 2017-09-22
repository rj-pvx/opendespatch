using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenDespatch.RoyalMail
{
    public partial class Settings : Form
    {
        UserSetting userSetting;

        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            userSetting = UserSetting.GetUserSettings();

            InputFolderTextBox.Text = userSetting.InputFolderPath;
            OutputFolderTextbox.Text = userSetting.OutputFolderPath;
            TemplatePathTextBox.Text = userSetting.TemplatePath;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            UserSetting.SaveUserSettings(CreateUserSettingFromUIValues());
        }

        private UserSetting CreateUserSettingFromUIValues()
        {
            userSetting.InputFolderPath = InputFolderTextBox.Text;
            userSetting.OutputFolderPath = OutputFolderTextbox.Text;
            userSetting.TemplatePath = TemplatePathTextBox.Text;
            return userSetting;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChooseFolder(InputFolderTextBox);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChooseFolder(OutputFolderTextbox);
        }

        private void ChooseFolder(TextBox tb)
        {
            folderBrowserDialog1.SelectedPath = string.IsNullOrEmpty(tb.Text) ? "" : tb.Text;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                tb.Text = folderBrowserDialog1.SelectedPath;
        }

    }
}
