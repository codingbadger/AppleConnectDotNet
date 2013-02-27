using System;
using System.Collections.Generic;
using System.Linq;

namespace AppleConnectDotNet.Entities
{
    public class NewsstandReport: Report
    {

        
        public DateTime DownloadDate { get; set; }
        public decimal CustomerIdentifier { get; set; }
        public DateTime ReportDate { get; set; }
        public string Sales_Return { get; set; }
    }
}
