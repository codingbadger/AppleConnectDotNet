using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppleConnectDotNet.Entities
{
    public class NewsstandReport
    {

        public string Provider { get; set; }
        public string ProviderCountry { get; set; }
        public string SKU { get; set; }
        public string Developer { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
        public string ProductTypeIdentifier { get; set; }
        public decimal Units { get; set; }
        public decimal DeveloperProceeds { get; set; }
        public string CustomerCurrency { get; set; }
        public string CountryCode { get; set; }
        public string CurrencyOfProceeds { get; set; }
        public decimal AppleIdentifier { get; set; }
        public decimal CustomerPrice { get; set; }
        public string PromoCode { get; set; }
        public string ParentIdentifier { get; set; }
        public string Subscription { get; set; }
        public string Period { get; set; }
        public DateTime DownloadDate { get; set; }
        public decimal CustomerIdentifier { get; set; }
        public DateTime ReportDate { get; set; }
        public string Sales_Return { get; set; }
    }
}
