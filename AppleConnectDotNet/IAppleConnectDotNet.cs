using System;
using System.Collections.Generic;
using System.Linq;
using AppleConnectDotNet.Enums;
using AppleConnectDotNet.Entities;

namespace AppleConnectDotNet
{
    public interface IAppleConnectDotNet
    {
        List<SalesReport> GetSalesReport(string url, string userName, string password, string vendorNumber, DateTypes dateType, ReportSubTypes reportSubType, string reportDate);
        List<NewsstandReport> GetNewsstandReport(string url, string userName, string password, string vendorNumber, DateTypes dateType, ReportSubTypes reportSubType, string reportDate);      
        
    }
}
