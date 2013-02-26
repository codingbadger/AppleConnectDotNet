using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppleConnectDotNet.Enums;
using AppleConnectDotNet.Entities;

namespace AppleConnectDotNet
{
    public interface IAppleConnectDotNet
    {
        SalesReport GetSalesReport(Uri url, string userName, string password, string vendorNumber, DateTypes dateType, ReportSubTypes reportSubType, string reportDate);
        NewsstandReport GetNewsstandReport(Uri url, string userName, string password, string vendorNumber, DateTypes dateType, ReportSubTypes reportSubType, string reportDate);      
        
    }
}
