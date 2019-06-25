using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace DesignDoc_FunctionApp
{
    public static class DesignDocFunction
    {
        private static object lockobject = new object();
        [FunctionName("DesignDocFunction")]
        public static void Run([QueueTrigger("designdocqueue", Connection = "designdocqueueconnectionstring")]string myQueueItem, ILogger log)
        {

            string[] inputData = myQueueItem.Split(":",4);

            

            if (inputData[1].Contains(".md"))
            {
                lock (lockobject)
                {
                    string markdown = inputData[3];
                    DesignDocParser parser = new DesignDocParser(markdown);
                    ScaffoldCreator c = new ScaffoldCreator(parser.DesignDocument,inputData[2]);
                    c.SendEmail(inputData[0]);
                }
            }
        }
        
    }
}
