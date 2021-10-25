
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
            string connectionString = "Url=https://orgdc76b2ea.crm.dynamics.com;AuthType=ClientSecret;ClientId=057fe772-bf0b-48ae-8a0c-fd731ff43e8d;ClientSecret=ct~FMeFwbZ9h_F.yUUjtO1_-5y1120e3~8;RequireNewInstance=true";
            return new ServiceClient(connectionString);
        }
        

    }
}
