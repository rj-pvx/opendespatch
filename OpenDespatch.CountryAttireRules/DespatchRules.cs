using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenDespatch.Entities;

namespace OpenDespatch.CountryAttireRules
{
    public class DespatchRules : IDespatchRules
    {
        //New Version 
        #region IDespatchRules Members
        public double parseDouble(string val)
        {
            double res = 0.0;
            try
            {
                res = double.Parse(val);
            }
            catch
            {
                //eat it
            }
            return res;
        }

        public string MapToANSI127(string val)
        {
            string res = "";
            StringBuilder work = new StringBuilder();
            foreach (Char C in val)
            {
                if ((C >= '!') && (C <= 'z'))
                {
                    work.Append(C);
                }
                else
                {
                    string a = C.ToString();
                    byte i = Encoding.Default.GetBytes(a)[0];
                    work.Append(i);
                }
            }
            res = work.ToString();
            return res;
        }

        public DespatchDespatchPackage[] createPackageCollection(string packageName)
        {
            var package = new DespatchDespatchPackage();
            package.PackageName = packageName;
            package.Weight = "0";
            var arr = new DespatchDespatchPackage[] { package };
            return arr;
        }

        public void ProcessRules(ref Despatch despatch)
        {
            double shippingcost = parseDouble(despatch.ShippingCost);
            int isUk = 0;

            if ((despatch.ShippingAddressCountry.Equals("GB")) ||
                (despatch.ShippingAddressCountry.Equals("UK")) ||
                (despatch.ShippingAddressCountry.Equals("United Kingdom")))
            {
                isUk = 1;
            }

            if (despatch.ServiceTypeCode.Equals("CA-101")) //First Class Mail
            {
                despatch.CarrierName = "Royal Mail";
                despatch.ServiceTypeCode = "CRL01";
                if (despatch.Packages.Length > 0)
                    despatch.Packages[0].PackageName = "NA";
                else
                    despatch.Packages = createPackageCollection("NA");
            }

            if (despatch.ServiceTypeCode.Equals("CA-102")) //First Class Recorded
            {
                despatch.CarrierName = "Royal Mail";
                despatch.ServiceTypeCode = "CRL01;11";
                if (despatch.Packages.Length > 0)
                    despatch.Packages[0].PackageName = "NA";
                else
                    despatch.Packages = createPackageCollection("NA");
            }
            if (despatch.ServiceTypeCode.Equals("CA-103")) //Special Delivery 1pm
            {
                despatch.CarrierName = "Royal Mail";
                despatch.ServiceTypeCode = "SD101";
                if (despatch.Packages.Length > 0)
                    despatch.Packages[0].PackageName = "NA";
                else
                    despatch.Packages = createPackageCollection("NA");
            }
            if (despatch.ServiceTypeCode.Equals("CA-104")) //OLA 250gm
            {
                despatch.CarrierName = "Royal Mail";
                despatch.ServiceTypeCode = "IE101";
                if (despatch.Packages.Length > 0)
                    despatch.Packages[0].PackageName = "NA";
                else
                    despatch.Packages = createPackageCollection("NA");
            }
            if (despatch.ServiceTypeCode.Equals("CA-105")) //International Signed for
            {
                despatch.CarrierName = "Royal Mail";
                despatch.ServiceTypeCode = "IE101;32";
                despatch.CarrierName = "Royal Mail";
                despatch.ServiceTypeCode = "INT";
                if (despatch.Packages.Length > 0)
                    despatch.Packages[0].PackageName = "IP";
                else
                    despatch.Packages = createPackageCollection("IP");

            }
            if (despatch.ServiceTypeCode.Equals("CA-106")) //Airsure
            {
                despatch.CarrierName = "Royal Mail";
                despatch.ServiceTypeCode = "IE101;22";
            }
            if (despatch.ServiceTypeCode.Equals("CA-107")) //Not Used
            {
                despatch.CarrierName = "Royal Mail";
                despatch.ServiceTypeCode = "TP201";
                if (despatch.Packages.Length > 0)
                    despatch.Packages[0].PackageName = "NA";
                else
                    despatch.Packages = createPackageCollection("NA");

            }
            if (despatch.ServiceTypeCode.Equals("CA-108")) //OLA 611gm
            {
                despatch.CarrierName = "Royal Mail";
                despatch.ServiceTypeCode = "IE101";
                if (despatch.Packages.Length > 0)
                    despatch.Packages[0].PackageName = "NA";
                else
                    despatch.Packages = createPackageCollection("NA");
            }
            if ((despatch.ServiceTypeCode.StartsWith("CA-13")) && (isUk==1) &&           
                ((despatch.ShippingAddressPostCode.StartsWith("AB")) ||
                 (despatch.ShippingAddressPostCode.StartsWith("EI")) ||
                 (despatch.ShippingAddressPostCode.StartsWith("ZZ")) ||
                 (despatch.ShippingAddressPostCode.StartsWith("FK")) ||
                 (despatch.ShippingAddressPostCode.StartsWith("G")) ||
                 (despatch.ShippingAddressPostCode.StartsWith("GY")) ||
                 (despatch.ShippingAddressPostCode.StartsWith("HS")) ||
                 (despatch.ShippingAddressPostCode.StartsWith("IM")) ||
                 (despatch.ShippingAddressPostCode.StartsWith("IV")) ||
                 (despatch.ShippingAddressPostCode.StartsWith("KA")) ||
                 (despatch.ShippingAddressPostCode.StartsWith("KW")) ||
                 (despatch.ShippingAddressPostCode.StartsWith("PA")) ||
                 (despatch.ShippingAddressPostCode.StartsWith("PH")) ||
                 (despatch.ShippingAddressPostCode.StartsWith("TR")) ||
                 (despatch.ShippingAddressPostCode.StartsWith("ZE")) ||
                 (despatch.ShippingAddressPostCode.StartsWith("BT")) ||
                 (despatch.ShippingAddressPostCode.StartsWith("JE"))
                )
               )
            {
                if ((despatch.ShippingAddressPostCode.StartsWith("EI")) ||
                 (despatch.ShippingAddressPostCode.StartsWith("ZZ")) )
                {
                    despatch.CarrierName = "DPD";
                    despatch.ServiceTypeCode = "11";
                }
                else
                {
                    despatch.CarrierName = "Royal Mail";
                    despatch.ServiceTypeCode = "SD101";
                    despatch.ServiceTypeCode = "TP201";
                    if (despatch.Packages.Length > 0)
                        despatch.Packages[0].PackageName = "NA";
                    else
                        despatch.Packages = createPackageCollection("NA");
                }
            }
            else
            {
                if (despatch.ServiceTypeCode.Equals("CA-131")) //DPD Parcel Next Day
                {
                    despatch.CarrierName = "DPD";
                    despatch.ServiceTypeCode = "12";
                }
                else
                {
                    if (despatch.ServiceTypeCode.Equals("CA-132")) //DPD Parcel - 2 day
                    {
                        despatch.CarrierName = "DPD";
                        despatch.ServiceTypeCode = "11";
                    }
                    else
                    {
                        if (despatch.ServiceTypeCode.Equals("CA-133")) //DPD Express Pak - Next day
                        {
                            despatch.CarrierName = "DPD";
                            despatch.ServiceTypeCode = "32";
                            /*
                                despatch.CarrierName = "Royal Mail";
                                despatch.ServiceTypeCode = "INT";
                                if (despatch.Packages.Length > 0)
                                    despatch.Packages[0].PackageName = "IP";
                                else
                                    despatch.Packages = createPackageCollection("IP");
                            */
                        }
                        else
                        {
                            if (despatch.ServiceTypeCode.Equals("CA-134")) //DPD Express Pak - before 10am
                            {
                                despatch.CarrierName = "DPD";
                                despatch.ServiceTypeCode = "34";
                                /*
                                despatch.CarrierName = "Royal Mail";
                                despatch.ServiceTypeCode = "MP601";
                                if (despatch.Packages.Length > 0)
                                    despatch.Packages[0].PackageName = "IP";
                                else
                                    despatch.Packages = createPackageCollection("IP");
                                */
                            }
                            else
                            {
                                if (despatch.ServiceTypeCode.Equals("CA-136")) //Parcel Swapit
                                {
                                    despatch.CarrierName = "DPD";
                                    despatch.ServiceTypeCode = "42";
                                }
                                else
                                {
                                    if (despatch.ServiceTypeCode.Equals("CA-135")) //DPD International
                                    {
                                        if (isUk == 1)
                                        {
                                            despatch.CarrierName = "DPD";
                                            despatch.ServiceTypeCode = "11";
                                        }
                                        else
                                        {
                                            despatch.CarrierName = "DPD";
                                            despatch.ServiceTypeCode = "19";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            if (despatch.CarrierName.Equals("Royal Mail"))
            {
                despatch.CustomerName = MapToANSI127(despatch.CustomerName);
                if (despatch.CustomerName.Equals(""))
                {
                    string[] w = despatch.CustomerEmail.Split('@');
                    if (w.Count() > 0)
                    {
                        despatch.CustomerName = w[0];
                    }
                }
                despatch.ShippingAddressLine1 = MapToANSI127(despatch.ShippingAddressLine1);
                despatch.ShippingAddressLine2 = MapToANSI127(despatch.ShippingAddressLine2);
                despatch.ShippingAddressTownCity = MapToANSI127(despatch.ShippingAddressTownCity);
                despatch.ShippingAddressRegion = MapToANSI127(despatch.ShippingAddressRegion);
                despatch.ShippingAddressCountry = MapToANSI127(despatch.ShippingAddressCountry);
                despatch.ShippingAddressPostCode = MapToANSI127(despatch.ShippingAddressPostCode);
            }
        }

        #endregion
    }
}
