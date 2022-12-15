
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Azure_Funtion
{
    public static class Function
    {
        #region Commented
        //[FunctionName("Function")]
        //public static async Task<IActionResult> Hello(
        //    [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
        //    ILogger log)
        //{
        //    log.LogInformation("C# HTTP trigger function processed a request.");

        //    string name = req.Query["name"];

        //    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        //    dynamic data = JsonConvert.DeserializeObject(requestBody);
        //    name = name ?? data?.name;

        //    string responseMessage = string.IsNullOrEmpty(name)
        //        ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
        //        : $"Hello, {name}. This HTTP triggered function executed successfully.";

        //    return new OkObjectResult(responseMessage);
        //}

        #endregion


        [FunctionName("Functionagain")]
        public static async Task<IActionResult> Again(
           [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
           ILogger log)
        {
            log.LogInformation("C# HTTP trigger 'Functionagain' function processed a request.");

            string name = req.Query["name"];
            string email = req.Query["email"];
            string age = req.Query["age"];

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

           

            string Message = string.Format(@"<table>
                                                    <thead>
                                                        <tr>
                                                            <th>
                                                                Name
                                                            </th>
                                                            <th>
                                                                Age
                                                            </th>
                                                            <th>
                                                                Email
                                                            </th>
                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <tr>
                                                          <td>
                                                            {0}
                                                          </td>
                                                          <td>
                                                            {1}
                                                          </td>
                                                          <td>
                                                            {2}
                                                          </td>
                                                          <tr>

</tbody>

                                                </table>
                                    
                                    ",name,age,email);
            string responseMessage = string.IsNullOrEmpty(name)
               ? "<div>Function triggred successfully </div>"
               : Message;

            return new ContentResult
            {
                Content = responseMessage,
                ContentType = "text/html"
            };
            
        }

    }
}

