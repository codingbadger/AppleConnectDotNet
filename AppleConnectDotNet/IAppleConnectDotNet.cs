using System;
using System.Collections.Generic;
using System.Linq;
using AppleConnectDotNet.Enums;
using AppleConnectDotNet.Entities;

namespace AppleConnectDotNet
{
    public interface IAppleConnectDotNet
    {
        List<SalesReport> GetSalesReport( string userName, string password, string vendorNumber, string dateType, string reportSubType, string reportDate);
        List<NewsstandReport> GetNewsstandReport(string userName, string password, string vendorNumber, string dateType, string reportSubType, string reportDate);      
        
    }
}
