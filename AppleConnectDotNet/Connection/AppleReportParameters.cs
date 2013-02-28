using System;
using System.Collections.Generic;
using System.Linq;
using AppleConnectDotNet.Enums;
namespace AppleConnectDotNet.Connection
{
    class AppleReportParameters
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string VendorNumber { get; set; }
        public Uri Url { get; set; }
        public ReportTypes ReportType { get; set; }
        public DateTypes DateType { get; set; }
        public ReportSubTypes ReportSubType { get; set; }
        public DateTime DateOfReport { get; set; }
    }
}
