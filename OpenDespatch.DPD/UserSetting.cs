using OpenDespatch.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenDespatch.DPD
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
                    templetePath = Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), "DPDTemplate.txt");
                }
                return templetePath;
            }
            set
            {
                templetePath = value;
            }
        }

        private string delimiter;
        public string Delimiter
        {
            get
            {
                return string.IsNullOrEmpty(delimiter) ? "\t" : delimiter;
            }
            set
            {
                delimiter = value;
            }
        }

        public string InputFolderPath { get; set; }
        public string OutputFolderPath { get; set; }

        //public string InputFileName { get { return "Data.txt"; } }
        //public string OutputFileName { get { return "Result.txt"; } }

        public string GetInputFileName(string inputFile)
        {
            var filename = inputFile.ToUpper();
            if (filename.Length > 8)
                filename = filename.Substring(filename.Length - 8);
            return string.Format("{0}.TXT",filename);
        }

        public string GetOutputFileName(string outputFile)
        {
            var filename = outputFile.ToUpper();
            if (filename.Length > 8)
                filename = filename.Substring(filename.Length - 8);
            return string.Format("{0}.OUT", filename);
        }

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
