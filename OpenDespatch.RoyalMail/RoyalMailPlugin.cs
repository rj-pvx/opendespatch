using OpenDespatch.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenDespatch.RoyalMail
{
    public class RoyalMailPlugin : DespatchBasePlugin
    {
        DespatchExt currentDespatch;

        public RoyalMailPlugin(BaseForm logger)
            : base("Royal mail", logger)
        {

        }

        #region Private methods

        private void ExtractTrackingNumber(string resultText)
        {
            trackingNumber = null;
            string[] result = Regex.Split(resultText, "\r\n");

            //For RM Result is on second line.
            if (result.Length > 2 && result[0] == "0")
                trackingNumber = result[1];

            if (string.IsNullOrEmpty(trackingNumber))
                WriteLog("Tracking number not found.", Color.Red);
            else
                WriteLog(string.Format("Received tracking number: {0}", trackingNumber), Color.Green);
        }

        private string ReadResultFile()
        {
            try
            {
                var resultText = FileOperations.ReadFile(Settings.OutputFolderPath, Settings.OutputFileName);
                if (resultText != null)
                {
                    FileOperations.DeleteFile(Settings.OutputFolderPath, Settings.OutputFileName);
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
            if (currentDespatch.CarrierName != "Royal Mail")
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
                FileOperations.DeleteFile(Settings.OutputFolderPath, Settings.OutputFileName);
                //Write the new file
                FileOperations.WriteFile(Settings.InputFolderPath, Settings.InputFileName, dataToSend);
                //Create Lock file
                FileOperations.WriteFile(Settings.InputFolderPath, "Lock.txt", "");

                //Debug only: Write a test result file.
                //FileOperations.WriteFile(Settings.OutputFolderPath, Settings.OutputFileName, string.Format("0{0}TESTTRACKINGNO{0}", "\r\n"));

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
            while ((!FileOperations.CheckFileExists(Settings.OutputFolderPath, Settings.OutputFileName)) &&
                (elapsed < 15)) //30 seconds
            {
                Thread.Sleep(2000); //wait 2 seconds before checking for result again.
                elapsed++;
            }

            if (!FileOperations.CheckFileExists(Settings.OutputFolderPath, Settings.OutputFileName))
            {
                //Write log
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