using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OpenDespatch.Entities
{
    public interface IDespatchRules
    {
        void ProcessRules(ref Despatch despatch);
    }

    public static class DespatchRulesFactory
    {
        public static IDespatchRules DespatchRuleHandler
        {
            get;
            private set;
        }

        public static bool LoadDespatchRulesPlugin(string filePath, string dllName)
        {
            filePath = Path.Combine(filePath, dllName);

            if (Path.GetFileName(filePath).ToUpper() != Path.GetFileName(Assembly.GetAssembly(typeof(DespatchBasePlugin)).CodeBase).ToUpper())
            {
                var type = Assembly.LoadFrom(filePath).GetTypes()
                    .FirstOrDefault(t =>
                        t.IsClass && typeof(IDespatchRules).IsAssignableFrom(t));
                
                if (type != null)
                {
                    DespatchRuleHandler = Activator.CreateInstance(type) as IDespatchRules;
                }
            }

            return DespatchRuleHandler != null;
        }
    }
}
