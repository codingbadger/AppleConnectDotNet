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


        public List<SalesReport> GetSalesReport(string userName, string password, string vendorNumber, string dateType, string reportSubType, string reportDate)
        {
            try
            {
                
                return AppleConnector.GetSalesReport(AppleConnector.CreateReportParameters( userName, password, vendorNumber, ReportTypes.Sales, dateType, reportSubType, reportDate));

            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public List<NewsstandReport> GetNewsstandReport( string userName, string password, string vendorNumber, string dateType, string reportSubType, string reportDate)
        {
            try
            {

                return _appleConnector.GetNewsstandReport(AppleConnector.CreateReportParameters( userName, password, vendorNumber, ReportTypes.Newsstand, dateType, reportSubType, reportDate));
                
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
