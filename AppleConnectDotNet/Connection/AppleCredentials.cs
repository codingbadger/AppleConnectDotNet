using System;
using System.Collections.Generic;
using System.Linq;

namespace AppleConnectDotNet.Connection
{
    class AppleCredentials
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string VendorNumber { get; set; }
        public Uri Url { get; set; }
    }
}
