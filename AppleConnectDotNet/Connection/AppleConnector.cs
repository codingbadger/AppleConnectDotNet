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

namespace AppleConnectDotNet.Connection
{
    internal class AppleConnector
    {

        public static AppleCredentials CreateAppleCredentials(string url, string userName, string password, string vendorNumber)
        {
            
            Uri uri;

            if (Uri.TryCreate(url, UriKind.Absolute, out uri) == false)
            {
                throw new ArgumentException("Invalid URL passed");
            }
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


            AppleCredentials _credentials = new AppleCredentials()
            {
                Url = uri,
                UserName = userName,
                Password = password,
                VendorNumber = vendorNumber
            };

            return _credentials;

        }

        public static List<SalesReport> GetSalesReport(AppleCredentials credentials, DateTypes dateType, ReportSubTypes reportSubType, string reportDate)
        {
            using (WebClient wc = new WebClient())
            {
                byte[] response = wc.UploadValues(credentials.Url, "POST", CreatePostParameters(credentials, ReportTypes.Sales, dateType, reportSubType, reportDate));
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

        public List<NewsstandReport> GetNewsstandReport(AppleCredentials credentials, DateTypes dateType, ReportSubTypes reportSubType, string reportDate)
        {
            throw new NotImplementedException();
        }

        private static NameValueCollection CreatePostParameters(AppleCredentials credentials, ReportTypes reportType, DateTypes dateTypes, ReportSubTypes reportSubTypes, string reportDate)
        {

            NameValueCollection postParams = new NameValueCollection();
            postParams.Add("USERNAME", credentials.UserName);
            postParams.Add("PASSWORD", credentials.Password);
            postParams.Add("VNDNUMBER", credentials.VendorNumber);
            postParams.Add("TYPEOFREPORT", reportType.ToString());
            postParams.Add("DATETYPE", dateTypes.ToString());
            postParams.Add("REPORTTYPE", reportSubTypes.ToString());
            postParams.Add("REPORTDATE", reportDate);

            return postParams;
        }
    }
}
