using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenDespatch.Entities
{
    public abstract class DespatchBasePlugin
    {
        private static readonly List<string> PRIMITIVE_PROPTERY_LIST = new List<string> { "string", "byte[]", "datetime", "nullable`1", "decimal" };
        private BaseForm statusLogger;
        private string pluginName;

        //caches - to be cleared
        protected string trackingNumber;
        private Despatch despatch;
        private Thread asyncWaitThread;

        public DespatchBasePlugin(string name, BaseForm logger)
        {
            statusLogger = logger;
            pluginName = name;
        }

        public abstract string GetPreview();
        public abstract void Send(string overrideValue);
        protected abstract Despatch CheckPlugin(string xmlData);

        public event EventHandler OnResultReceived;
        private string result;
        public string Result {
            get
            {
                return result;
            }
            protected set
            {
                result = value;
                if (OnResultReceived != null)
                {
                    statusLogger.Invoke(OnResultReceived, new object[] { this, EventArgs.Empty });
                    ClearCache();
                }
            }
        }

        public void ClearCache()
        {
            trackingNumber = null;
            asyncWaitThread = null;
        }

        public string PluginName
        {
            get { return pluginName; }
        }

        public string TrackingNumber
        {
            get { return trackingNumber; }
        }

        public string SalesOrderNumber
        {
            get
            {
                    return despatch.SalesOrderNumber;
            }
        }

        public bool CanUsePlugin(string xmlData)
        {
            despatch = CheckPlugin(xmlData);
            return despatch != null;
        }

        public abstract bool ShowSettingsWindow();

        public delegate void EmptyDelegate();
        protected void StartAsycWaitFunction(EmptyDelegate function)
        {
            asyncWaitThread = new Thread(new ThreadStart(function));
            asyncWaitThread.Start();
        }

        protected bool IsAsyncWaiting
        {
            get
            {
                //if(asyncWaitThread != null)
                //    System.Diagnostics.Debug.WriteLine(asyncWaitThread.ThreadState.ToString());
                //else
                //    System.Diagnostics.Debug.WriteLine("asyncWaitThread is null");

                return asyncWaitThread != null && 
                    asyncWaitThread.ThreadState != ThreadState.Stopped &&
                    asyncWaitThread.ThreadState != ThreadState.Aborted;
            }
        }

        public void AbortAsycWaitThread()
        {
            try
            {
                if (IsAsyncWaiting)
                    asyncWaitThread.Abort();
            }
            catch { }
        }

        protected string ReplacePropertyValues(string templateData, object data, string propertyPath = "", string propertyName = "")
        {
            if (data != null)
            {
                string lastPropertyName = propertyName.Substring(propertyName.LastIndexOf('.') + 1);
                string lastPropertyPath = propertyPath.Substring(propertyPath.LastIndexOf('.') + 1);

                Type dataType = data.GetType();
                if (!dataType.IsPrimitive &&
                    !PRIMITIVE_PROPTERY_LIST.Contains(dataType.Name.ToLower()))
                {
                    string tmpPropName = string.IsNullOrEmpty(propertyName) ? "" : propertyName + ".";
                    string tmpPropPath = string.IsNullOrEmpty(propertyPath) ? "" : propertyPath + ".";

                    bool isList = dataType.GetInterfaces().Any(i => i.IsGenericType &&
                        i.GetGenericTypeDefinition() == typeof(IEnumerable<>));

                    if (!isList)
                    {
                        dataType.GetProperties().ToList().ForEach(p =>
                        {
                            if (!p.PropertyType.IsPrimitive &&
                                !PRIMITIVE_PROPTERY_LIST.Contains(p.PropertyType.Name.ToLower()) &&
                                !p.PropertyType.IsEnum)
                            {
                                object value = p.GetValue(data, null);
                                templateData = ReplacePropertyValues(templateData, value, tmpPropName + p.Name, tmpPropPath + p.Name);
                            }
                            else
                            {
                                object value = p.GetValue(data, null);
                                templateData = templateData.Replace("{" + tmpPropName + p.Name + "}", value != null ? value.ToString() : "");
                            }
                        });
                    }
                    else
                    {
                        int index = 0;
                        foreach (object item in data as IEnumerable)
                        {
                            if (item != null)
                            {
                                templateData = ReplacePropertyValues(templateData, item,
                                    string.Format("{0}[{1}]", tmpPropName.Remove(tmpPropName.Length - 1), index), propertyPath);
                                index++;
                            }
                        }
                    }
                }
                else
                {
                    templateData = templateData.Replace("{" + propertyName + "}", data.ToString());
                }
            }
            return templateData;
        }

        protected void WriteLog(string message, Color textColor)
        {
            if (statusLogger != null && statusLogger.InvokeRequired)
            {
                statusLogger.Invoke(statusLogger.WriteLogMethod, new object[] { message, textColor });
            }
            else
            {
                statusLogger.WriteLog(message, textColor);
            }
        }
    }

}
