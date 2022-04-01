
using Microsoft.Extensions.Logging;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tester
{
    public  class Helper
    {
        public static ServiceClient Service()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            string connectionString = "Url=https://dev-davinci.crm8.dynamics.com;AuthType=ClientSecret;ClientId=882b4b59-952c-462b-af18-79a33017fa5b;ClientSecret=hkD7Q~UHvbrB712MwF0qglKA.uUXkuWCOI1oB;RequireNewInstance=true";
            return new ServiceClient(connectionString);
        }
        

    }
}
