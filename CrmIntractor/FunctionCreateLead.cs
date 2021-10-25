using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CrmIntractor.Modal;

namespace CrmIntractor
{
    public static class FunctionCreateLead
    {
        #region Create Lead
        [FunctionName("FnCreateLead")]
        public static async Task<IActionResult> FnCreateLead(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            LeadInfo Lead = JsonConvert.DeserializeObject<LeadInfo>(requestBody);
            //string name = data?.name ?? "DefaultName";
            var id = FunctionHelpers.Helper.createLead(Lead, log);
            string responseMessage = id.Equals(Guid.Empty) ? "Lead not created. Check the tracelog" : $"lead created succesfully with Id {id}";
            if (id.Equals(Guid.Empty))
            {
                return new BadRequestObjectResult(responseMessage);
            }
            return new OkObjectResult(responseMessage);
        }
        #endregion
        #region Update Lead
        [FunctionName("FnUpdateLead")]
        public static async Task<IActionResult> FnUpdateLead(
           [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
           ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            string leadId = data?.id;
            string title = data?.title;
            if (string.IsNullOrEmpty(leadId))
            {
                return new BadRequestObjectResult("id is not found or empty in the content body");
            }
            bool isUpdated = FunctionHelpers.Helper.updateLead(leadId, log, title);
            return new OkObjectResult($"Id {leadId} updated successfully with the Jobtitle {title}");
        }
        #endregion
        #region Delete Lead
        [FunctionName("FnDeleteLead")]
        public static async Task<IActionResult> FnDeleteLead(
        [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
        ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            string leadId = data?.id;
            if (string.IsNullOrEmpty(leadId))
            {
                return new BadRequestObjectResult("id is not found or empty in the content body");
            }
            bool isUpdated = FunctionHelpers.Helper.deleteLead(leadId, log);
            return new OkObjectResult($"Lead {leadId} deleted successfully.....");
        }
        #endregion
     

    }
}
