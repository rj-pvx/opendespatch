using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OpenDespatch.RoyalMail
{
    [XmlRoot(ElementName="Despatch")]
    public class DespatchExt : Despatch
    {
        public double TotalWeight
        {
            get
            {
                var totalWeight = Packages.Sum(t => double.Parse(t.Weight));
                return totalWeight > 0 ? (totalWeight * 1000) : 15; //Convert from kg to grams and add a default of 15g to replace weights of zero.
            }
        }

        public string PackageName
        {
            get
            {
                return (Packages.Length > 0) ? Packages[0].PackageName : "P"; //Can add default here.
            }
        }

        public override string NumberOfPackages
        {
            get
            {
                return int.Parse(base.NumberOfPackages) > 0 ? base.NumberOfPackages : "1";
            }
        }

        public string ShippingAddressCode
        {
            get
            {
                if (string.IsNullOrEmpty(base.ShippingAddressCountry))
                    base.ShippingAddressCountry = "United Kingdom";
                return GetCountryCode(base.ShippingAddressCountry);
            }
        }

        public string ShippingAddressCodeNumber
        {
            get
            {
                //Set up the county mappings
                if (string.IsNullOrEmpty(base.ShippingAddressCountry))
                    return "1";

                switch (base.ShippingAddressCountry.ToLower())
                {
                    case "united kingdom":
                        return "1";
                    case "great britain":
                        return "1";
                    case "ireland":
                        return "1";
                    default:
                        return "5";
                }
            }
        }

        public override string ShippingAddressCountry
        {
            get
            {
                if (String.IsNullOrEmpty(base.ShippingAddressCountry))
                    base.ShippingAddressCountry = "United Kingdom";
                return base.ShippingAddressCountry;
            }
        }

        public string GetCountryCode(string shipAddress)
        {
            var us = new UserSetting();
            var path = Path.GetDirectoryName(us.TemplatePath);
            var resultsString = File.ReadAllLines(Path.Combine(path, "DPDCountry.csv"));
            foreach (var item in resultsString)
            {
                if (item.Split(',')[0].ToLower() == shipAddress.ToLower().Replace(',', '^'))
                    return item.Split(',')[1];
            }
            return String.Empty;
        }

    }
}
