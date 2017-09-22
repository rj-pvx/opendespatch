using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OpenDespatch.WindowsApp
{
    public static class PeoplevoxProxy
    {
        public static string LastError { get; private set; }
        private static PvxApi.IntegrationServiceV4 serviceProxy;

        private static bool LoginToApi()
        {
            serviceProxy = new PvxApi.IntegrationServiceV4();
            try 
	        {	        
                //Connect to PVX API
                serviceProxy.Url = Properties.Settings.Default.PvxApiUrl;
                var response = serviceProxy.Authenticate(
                    Properties.Settings.Default.PvxClientId,
                    Properties.Settings.Default.PvxUsername,
                    Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(Properties.Settings.Default.PvxPassword)));

                //Set SessionId
                if (response.ResponseId != 0)
                {
                    serviceProxy = null;
                }
                else
                {
                    //Split the response and get ClientId and Session string
                    var csvValues = response.Detail.Split(",".ToCharArray());
                    serviceProxy.UserSessionCredentialsValue = new PvxApi.UserSessionCredentials()
                    {
                        ClientId = csvValues[0], //Client Id
                        SessionId = csvValues[1] //Session
                    };
                }
	        }
	        catch (Exception)
	        {
		        serviceProxy = null;
	        }
            return serviceProxy != null;
        }

        private static bool IsSessionValid
        {
            get
            {
                try
                {
                    var result = serviceProxy.GetSaveTemplate("Sales orders");
                    if ((result.ResponseId == 0))
                    {
                        return true;
                    }
                    else
                    {
                        return LoginToApi();
                    }                    
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool IsServiceAvailable
        {
            get
            {
                if (serviceProxy == null)
                    LoginToApi();
                return (serviceProxy != null && IsSessionValid);
            }
        }

        public static bool IsTestServiceSuccessful
        {
            get
            {
                LoginToApi();
                return (serviceProxy != null && IsSessionValid);
            }
        }

        public static bool SaveTrackingNumber(string salesOrderNumber, string trackingNumber)
        {
            //Send tracking number via save request
            var savReq = new PvxApi.SaveRequest();
            string dataLine = String.Format("{0},{1}\r\n{2},{3}",
                Properties.Settings.Default.SalesOrderTemplateHeader,
                Properties.Settings.Default.TrackingNumberTemplateHeader,
                salesOrderNumber, trackingNumber);
            savReq.CsvData = String.Format("\r\n{0}", dataLine);
            savReq.TemplateName = "Sales orders";

            if (IsServiceAvailable)
            {
                var res = serviceProxy.SaveData(savReq);
                LastError = res.Detail;
                return (res.ResponseId == 0);
            }
            return false;
        }
    }
}
