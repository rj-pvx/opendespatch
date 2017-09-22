using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace OpenDespatch.Entities
{
    public abstract class UserSettingBase
    {
        public static T LoadUserSetting<T>() where T: UserSettingBase
        {
            var settingFilePath = string.Format("{0}.Settings.xml", typeof(T).Assembly.Location);

            if (!File.Exists(settingFilePath)) return null;

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StreamReader reader = new StreamReader(settingFilePath))
            {
                return ((T)serializer.Deserialize(reader));
            }
        }

        protected bool SaveUserSetting<T>() where T: UserSettingBase
        {
            var settingFilePath = string.Format("{0}.Settings.xml", typeof(T).Assembly.Location);

            XmlSerializer serializer = new XmlSerializer(this.GetType());
            using (StreamWriter writer = new StreamWriter(settingFilePath))
            {
                serializer.Serialize(writer, this);
            }
            return true;
        }
    }
}
