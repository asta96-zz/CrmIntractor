using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace SBD365Listner
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static void Run([QueueTrigger("leadsdump", Connection = 
            "Endpoint=sb://sbd365.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=I8OJDfZ5VQTA73kqVTQCZxvYLuCf/du2knDP+EoCLYQ=")]
        string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}
