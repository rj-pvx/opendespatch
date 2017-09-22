using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace OpenDespatch.Entities
{
    public static class DespatchPluginFactory
    {
        private static Dictionary<string, DespatchBasePlugin> pluginsCache = new Dictionary<string, DespatchBasePlugin>();

        public static List<DespatchBasePlugin> LoadPlugins(string pluginPath, BaseForm logger, EventHandler resultCallBack)
        {
            //1. Get all assemblies in the folder
            foreach (var filePath in Directory.GetFiles(pluginPath, "*.dll"))
            {
                if (!pluginsCache.ContainsKey(filePath) &&
                    Path.GetFileName(filePath).ToUpper() != Path.GetFileName(Assembly.GetAssembly(typeof(DespatchBasePlugin)).CodeBase).ToUpper())
                {
                    var type = Assembly.LoadFrom(filePath).GetTypes()
                        .FirstOrDefault(t =>
                            t.IsClass && t.IsSubclassOf(typeof(DespatchBasePlugin)));

                    if (type != null)
                    {
                        DespatchBasePlugin obj = Activator.CreateInstance(type, new object[] { logger }) as DespatchBasePlugin;
                        obj.OnResultReceived += resultCallBack;
                        pluginsCache.Add(filePath, obj);
                    }
                }
            }
            return pluginsCache.Values.ToList();
        }

        public static DespatchBasePlugin GetPlugin(string xmlData)
        {
            ProcessBusinessRules(ref xmlData);
            //Load the assembly and send the Despatch object
            foreach (var plugin in pluginsCache.Values)
            {
                if (plugin.CanUsePlugin(xmlData))
                    return plugin;
            }
            return null;
        }

        private static void ProcessBusinessRules(ref string xmlData)
        {
            var despatch = DespatchPluginFactory.DeserializeStandardXml<Despatch>(xmlData);
            if (DespatchRulesFactory.DespatchRuleHandler != null)
            {
                DespatchRulesFactory.DespatchRuleHandler.ProcessRules(ref despatch);
            }
            xmlData = DespatchPluginFactory.SerializeStandardObject<Despatch>(despatch);
        }

        public static T DeserializeStandardXml<T>(string xmlValue)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (System.Xml.XmlTextReader reader = new System.Xml.XmlTextReader(new StringReader(xmlValue)))
            {
                return ((T)serializer.Deserialize(reader));
            }
        }

        public static string SerializeStandardObject<T>(T obj)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringWriter sw = new StringWriter())
            {
                using (System.Xml.XmlTextWriter writer = new System.Xml.XmlTextWriter(sw))
                {
                    serializer.Serialize(writer, obj);
                }
                return sw.ToString();
            }
        }
    }
}
