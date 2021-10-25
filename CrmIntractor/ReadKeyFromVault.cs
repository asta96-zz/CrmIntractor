using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Service;
namespace CrmIntractor
{
    public static class ReadKeyFromVault
    {
        [FunctionName("ReadKeyFromVault")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];
            KeyVaultService _service = new KeyVaultService();
           // string secretValue= await _service.GetSecretValue("D365ConnectionString");
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string secret2 = Environment.GetEnvironmentVariable("keyvault");
            //log.LogInformation(secret2);
            log.LogWarning("logging warning");
            log.LogError("logging error");
            log.LogCritical("logging critical");
            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. retrieve value from vault {secret2}";

            return new OkObjectResult(responseMessage);
        }
    }
}
