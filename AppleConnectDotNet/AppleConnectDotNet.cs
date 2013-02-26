using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppleConnectDotNet.Enums;
using AppleConnectDotNet.Connection;
using AppleConnectDotNet.Entities;

namespace AppleConnectDotNet
{
    public class AppleConnectDotNet : IAppleConnectDotNet
    {

        private readonly AppleConnector _appleConnector;


        public AppleConnectDotNet()
        {
            _appleConnector = new AppleConnector();
        }


        public SalesReport GetSalesReport(Uri url, string userName, string password, string vendorNumber, DateTypes dateType, ReportSubTypes reportSubType, string reportDate)
        {
            throw new NotImplementedException();
        }

        public NewsstandReport GetNewsstandReport(Uri url, string userName, string password, string vendorNumber, DateTypes dateType, ReportSubTypes reportSubType, string reportDate)
        {
            throw new NotImplementedException();
        }
    }
}
