using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SBQueueTrigger
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([ServiceBusTrigger("SBd365", Connection = "Endpoint=sb://sbd365.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=I8OJDfZ5VQTA73kqVTQCZxvYLuCf/du2knDP+EoCLYQ=")]string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
            dynamic data = JsonConvert.DeserializeObject(myQueueItem);
        }
    }
}
