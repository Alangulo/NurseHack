using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data.SqlClient;

namespace ICUHelperFunctions
{
    public static class AddPatient
    {
        [FunctionName("AddPatient")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            Patient auxObj = new Patient();

            log.LogInformation("C# HTTP trigger function processed a request.");
            string test = req.Query["userId"];
            auxObj.userID = Int32.Parse(test);
            auxObj.patientId= Int32.Parse(req.Query["patientId"]);
           
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            //auxObj.userID = auxObj.userID ?? data?.email;
          //  fever = fever ?? data?.fever;
           // cough = cough ?? data?.cough;

            string responseMessage = "";

            if (string.IsNullOrEmpty(req.Query["userId"]))
            {
                responseMessage = "{\"result\":\"email parameter missing in your request\"}";
                return new OkObjectResult(responseMessage);

            }
            else
            {


                int writeResult = WriteToDB(auxObj);

                if (writeResult >= 0)
                {
                    responseMessage = "{\"result\":\"wrote " + writeResult + " record(s) to db\"}";
                    return new OkObjectResult(responseMessage);
                }
                else
                {
                    responseMessage = "{\"result\":\"error # " + writeResult + " when uploading data\"}";
                    return new OkObjectResult(responseMessage);
                }

                // return new OkObjectResult(responseMessage);
            }
        }




        public static int WriteToDB( Patient objPatient)
        {

            string cnnString = Environment.GetEnvironmentVariable("DB_CONNECTION");

          //  Console.WriteLine(cnnString);

            using (SqlConnection connection = new SqlConnection("st Security Info=False;User ID=alerico;Password=;=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
            {
                String query = "insert into [dbo].[patient] (user_id,condition_id) values (@userId,@conditionId)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userId", objPatient.userID);
                    command.Parameters.AddWithValue("@conditionId", objPatient.conditionId);
                   // command.Parameters.AddWithValue("@cough", cough);

                    connection.Open();
                    int result = command.ExecuteNonQuery();

                    // Check Error
                    if (result < 0)
                        Console.WriteLine("Error inserting data into Database!");

                    return result;

                }
            }

        }
    }



}
