using Microsoft.Extensions.Logging;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM_Helper
{
    public class Helper
    {
        public static ServiceClient Service()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            string connectionString = Environment.GetEnvironmentVariable("D365ConnectionString");
            return new ServiceClient(connectionString);
        }
        public static Guid createLead(string LeadName, ILogger log)
        {
            using (var service = Helper.Service())
            {
                Entity lead = new Entity("lead");
                lead["subject"] = "Lead created via Azure Function";
                lead["lastname"] = LeadName;
                lead["telephone1"] = "12355456";
                var leadid = Guid.Empty;
                try
                {
                    leadid = service.Create(lead);

                }
                catch (Exception ex)
                {
                    log.LogError($"Error while creating lead:{ex.Message}", ex);
                    //throw;
                }
                return leadid;
            }
        }

        internal static bool updateLead(string leadId, ILogger log, string jobTitle = null)
        {
            bool isUpdated = false;
            using (var service = Helper.Service())
            {
                try
                {
                    Entity lead = new Entity("lead", Guid.Parse(leadId));
                    if (!string.IsNullOrEmpty(jobTitle))
                        lead["jobtitle"] = jobTitle;
                    service.Update(lead);
                    isUpdated = true;
                }
                catch (Exception ex)
                {
                    log.LogError($"Error while creating lead:{ex.Message}", ex);
                    // throw;
                }
                return isUpdated;
            }
        }

        internal static bool deleteLead(string leadId, ILogger log)
        {

            bool isDeleted = false;
            using (var service = Helper.Service())
            {
                try
                {
                    Entity lead = new Entity("lead", Guid.Parse(leadId));
                    service.Delete(lead.LogicalName, lead.Id);
                    isDeleted = true;
                }
                catch (Exception ex)
                {
                    log.LogError($"Error while creating lead:{ex.Message}", ex);
                    // throw;
                }
                return isDeleted;
            }
        }
    }
}
