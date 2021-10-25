using System;
using System.Collections.Generic;
using CrmIntractor.Modal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CrmIntractor
{
    public static class SBD365QueueTrigger
    {
      

        [FunctionName("SBD365QueueTrigger")]
        public static void Run([ServiceBusTrigger("leadsdump", Connection = "AzureSbConnection")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: ");
            LeadInfo lead = JsonConvert.DeserializeObject<LeadInfo>(myQueueItem);
            // log.LogInformation($"Name :{data?.FirstName} +{Environment.NewLine}+Topic:{data?.Topic}"); string name = data?.name ?? "DefaultName";
            var id = FunctionHelpers.Helper.createLead(lead, log);
            string responseMessage = id.Equals(Guid.Empty) ? "Lead not created. Check the tracelog" : $"lead created succesfully with Id {id}";
            log.LogInformation(responseMessage);
        }
    }

 
}
