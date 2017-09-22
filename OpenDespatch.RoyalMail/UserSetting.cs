using OpenDespatch.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDespatch.RoyalMail
{
    public class UserSetting : UserSettingBase
    {
        private string templetePath;
        public string TemplatePath
        {
            get
            {
                if (string.IsNullOrEmpty(templetePath))
                {
                    templetePath = Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), "RMTemplate.txt");
                }
                return templetePath;
            }
            set
            {
                templetePath = value;
            }
        }

        public string InputFolderPath { get; set; }
        public string OutputFolderPath { get; set; }

        public string InputFileName { get { return "Data.txt"; } }
        public string OutputFileName { get { return "Result.txt"; } }


        public static UserSetting GetUserSettings()
        {
            var value = LoadUserSetting<UserSetting>();
            if (value == null)
                value = new UserSetting();
            return value;
        }

        public static void SaveUserSettings(UserSetting userSetting)
        {
            userSetting.SaveUserSetting<UserSetting>();
        }
    }
}
