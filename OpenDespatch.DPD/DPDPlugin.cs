using OpenDespatch.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenDespatch.DPD
{
    public class DPDPlugin : DespatchBasePlugin
    {
        DespatchExt currentDespatch;

        public DPDPlugin(BaseForm logger)
            : base("DPD", logger)
        {

        }

        #region Private methods

        private void ExtractTrackingNumber(string resultText)
        {
            trackingNumber = null;
            string[] result = Regex.Split(resultText, "\r\n");

            //For DPD Result is on appended to the end of the line.
            if (result[0] != null && result[0] != "")
                trackingNumber = Regex.Split(result[0], Settings.Delimiter).Last();

            if (string.IsNullOrEmpty(trackingNumber))
                WriteLog("Tracking number not found.", Color.Red);
            else
                WriteLog(string.Format("Received tracking number: {0}", trackingNumber), Color.Green);
        }

        private string ReadResultFile()
        {
            try
            {
                var resultText = FileOperations.ReadFile(Settings.OutputFolderPath, Settings.GetOutputFileName(currentDespatch.DespatchNumber));
                if (resultText != null)
                {
                    FileOperations.DeleteFile(Settings.OutputFolderPath, Settings.GetOutputFileName(currentDespatch.DespatchNumber));
                    WriteLog(string.Format("Response received: {0}", resultText), Color.Green);
                    return resultText;
                }
            }
            catch (Exception ex)
            {
                WriteLog(string.Format("Exception in ReadResultFile: {0}", ex.Message), Color.Red);
            }
            return null;
        }

        #endregion

        protected override Despatch CheckPlugin(string xmlData)
        {
            currentDespatch = DespatchPluginFactory.DeserializeStandardXml<DespatchExt>(xmlData);
            if (currentDespatch.CarrierName != "DPD")
            {
                currentDespatch = null;
            }

            return currentDespatch;
        }

        public override string GetPreview()
        {
            string template = File.ReadAllText(Settings.TemplatePath);
            return ReplacePropertyValues(template, currentDespatch);
        }

        public override void Send(string overrideValue)
        {
            if (IsAsyncWaiting) return;
            string dataToSend = overrideValue;
            try
            {
                if (String.IsNullOrEmpty(dataToSend))
                {
                    //Write log
                    WriteLog("No data to send", Color.Red);
                }

                //Delete old result files
                FileOperations.DeleteFile(Settings.OutputFolderPath, Settings.GetOutputFileName(currentDespatch.DespatchNumber));
                //Write the new file
                FileOperations.WriteFile(Settings.InputFolderPath, Settings.GetInputFileName(currentDespatch.DespatchNumber), dataToSend);

                //Debug only: Write a test result file.
                //FileOperations.WriteFile(Settings.OutputFolderPath, Settings.GetOutputFileName(currentDespatch.DespatchNumber),
                //                         string.Format("{0}{1}TESTTRACKINGNO",dataToSend.TrimEnd("\r\n".ToArray()), Settings.Delimiter));

                //Write log
                WriteLog(string.Format("Sent {1} to {0}  and waiting for response...",
                    PluginName, dataToSend), Color.Black);

                StartAsycWaitFunction(ThreadedWait);
            }
            catch (Exception ex)
            {
                WriteLog(string.Format("Exception in Send: {0}", ex.Message), Color.Red);
            }
        }

        private void ThreadedWait()
        {
            int elapsed = 0;
            while ((!FileOperations.CheckFileExists(Settings.OutputFolderPath, Settings.GetOutputFileName(currentDespatch.DespatchNumber))) &&
                (elapsed < 15)) //30 seconds
            {
                Thread.Sleep(2000); //wait 2 seconds before checking for result again.
                elapsed++;
            }

            if (!FileOperations.CheckFileExists(Settings.OutputFolderPath, Settings.GetOutputFileName(currentDespatch.DespatchNumber)))
            {
                //Write log
                if (!FileOperations.CheckFileExists(Settings.InputFolderPath, Settings.GetInputFileName(currentDespatch.DespatchNumber)))
                    WriteLog(string.Format("Input file processed by carrier but no result file produced, this suggests invalid data."), Color.Red);
                else
                    WriteLog("Wait timeout. Output file not generated", Color.Red);
                return;
            }

            //Read the result file
            var resultToProcess = ReadResultFile();
            if (!string.IsNullOrEmpty(resultToProcess))
                ExtractTrackingNumber(resultToProcess);
            Result = resultToProcess;
        }

        public override bool ShowSettingsWindow()
        {
            using (Settings frm = new Settings())
            {
                frm.ShowDialog();
            }
            return true;
        }

        public UserSetting Settings
        {
            get
            {
                return UserSetting.GetUserSettings();
            }
        }
    }
}
