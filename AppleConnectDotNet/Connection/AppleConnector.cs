using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppleConnectDotNet.Enums;
using AppleConnectDotNet.Entities;
using System.Collections.Specialized;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Globalization;

namespace AppleConnectDotNet.Connection
{
    internal class AppleConnector
    {

        private static readonly Uri AppleUrl = new Uri("https://reportingitc.apple.com/autoingestion.tft");

        public static AppleReportParameters CreateReportParameters(string userName, string password, string vendorNumber, ReportTypes reportType, string dateType, string reportSubType, string dateOfReport)
        {

            if (String.IsNullOrEmpty(userName) == true)
            {
                throw new ArgumentNullException("Username cannot be blank");
            }
            if (String.IsNullOrEmpty(password) == true)
            {
                throw new ArgumentNullException("Password cannot be blank");

            }
            if (String.IsNullOrEmpty(vendorNumber) == true)
            {
                throw new ArgumentNullException("Vendor Number cannot be blank");

            }

            AppleReportParameters reportParameters = new AppleReportParameters()
            {
                Url = AppleUrl,
                UserName = userName,
                Password = password,
                VendorNumber = vendorNumber,
                ReportType = reportType,
                DateType = ConvertToEnum<DateTypes>(dateType),
                ReportSubType = ConvertToEnum<ReportSubTypes>(reportSubType),
                DateOfReport = DateTime.ParseExact(dateOfReport, "yyyyMMdd", CultureInfo.InvariantCulture)
            };

            return reportParameters;
        }

        

    

        private static T ConvertToEnum<T>(object input) where T: struct
        {
                T result2;
                if (Enum.TryParse<T>(input.ToString(), out result2) == false)
                {
                    throw new ArgumentException(String.Format("Invalid {0} provided", typeof(T)));
                }
                //T result = (T)Enum.Parse(typeof(T), input.ToString(), true);
                return result2;
                //Enum.TryParse<T>(input, out result);
           
        }

        public static List<SalesReport> GetSalesReport(AppleReportParameters reportParameters)
        {
            using (WebClient wc = new WebClient())
            {
                byte[] response = wc.UploadValues(reportParameters.Url, "POST", CreatePostParameters(reportParameters));
                string errorMsg = wc.ResponseHeaders["ERRORMSG"];

                if (String.IsNullOrEmpty(errorMsg))
                {
                    string filename = wc.ResponseHeaders["filename"];

                    using (MemoryStream responseStream = new MemoryStream(response))
                    {

                        using (MemoryStream output = new MemoryStream())
                        {

                            using (GZipStream incomingZip = new GZipStream(responseStream, CompressionMode.Decompress))
                            {
                                incomingZip.CopyTo(output);

                            }

                            string fileContents = Encoding.Default.GetString(output.ToArray());

                            // TODO: Actually return the Report :)
                            return new List<SalesReport>();

                        }
                    }


                }
                else
                {
                    throw new Exception(String.Format("An Error has occurred: {0}", wc.ResponseHeaders["ERRORMSG"]));

                }
            }
        }

        public List<NewsstandReport> GetNewsstandReport(AppleReportParameters reportParameters)
        {
            throw new NotImplementedException();
        }


        private static NameValueCollection CreatePostParameters(AppleReportParameters reportParamters)
        {

            NameValueCollection postParams = new NameValueCollection();
            postParams.Add("USERNAME", reportParamters.UserName);
            postParams.Add("PASSWORD", reportParamters.Password);
            postParams.Add("VNDNUMBER", reportParamters.VendorNumber);
            postParams.Add("TYPEOFREPORT", reportParamters.ReportType.ToString());
            postParams.Add("DATETYPE", reportParamters.DateType.ToString());
            postParams.Add("REPORTTYPE", reportParamters.ReportSubType.ToString());
            postParams.Add("REPORTDATE", reportParamters.DateOfReport.ToString("yyyyMMdd"));

            return postParams;
        }
    }
}
