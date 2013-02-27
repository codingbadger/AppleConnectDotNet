using System;
using System.Collections.Generic;
using System.Linq;
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


        public List<SalesReport> GetSalesReport(string url, string userName, string password, string vendorNumber, DateTypes dateType, ReportSubTypes reportSubType, string reportDate)
        {
            try
            {

                return AppleConnector.GetSalesReport(AppleConnector.CreateAppleCredentials(url, userName, password, vendorNumber), dateType, reportSubType, reportDate);

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public List<NewsstandReport> GetNewsstandReport(string url, string userName, string password, string vendorNumber, DateTypes dateType, ReportSubTypes reportSubType, string reportDate)
        {
            try
            {

                return _appleConnector.GetNewsstandReport(AppleConnector.CreateAppleCredentials(url, userName, password, vendorNumber), dateType, reportSubType, reportDate);
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
