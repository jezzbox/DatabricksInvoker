using System;
using System.Collections.Specialized;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
using CommandLine;
using DatabricksInvoker.Jobs.Runs.RunNow;

namespace DatabricksInvoker
{
    class Program
    {
        private static readonly HttpClient client = new();
        
        private static async Task Main(string[] args)
        {
            // string bearerToken = Environment.GetEnvironmentVariable("BEARER_TOKEN");
            // client.DefaultRequestHeaders.Accept.Clear();
            // client.DefaultRequestHeaders.Accept.Add(
            //     new MediaTypeWithQualityHeaderValue("application/json"));
            // client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            // client.DefaultRequestHeaders.Authorization =
            //     new AuthenticationHeaderValue("Bearer", bearerToken);

            Parser.Default.ParseArguments<RunOptions>(args)
                .WithParsed<RunOptions>(o =>
                {
                    Resource runNowResource = new Resource(o);
                    
                    string bearerToken = Environment.GetEnvironmentVariable("BEARER_TOKEN");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
                    client.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", bearerToken);
                    runNowResource.PrintPayload();
                    runNowResource.RunNow(client);
                    runNowResource.PrintResponse();
                });
            
            // DatabricksMessage databricksMessage = new DatabricksMessage(379702724573372, 16, "20220705", args[0]);
          
            // var queryString = await GetJobRun(384, true, runRequest);
            // Console.WriteLine(queryString);
            // var runJobResponse = await RunJob(379702724573372, clientId, date, baseUri, bearerToken);
            // Console.WriteLine(runJobResponse.RunId);
            // foreach (var job in jobs)
            //     Console.WriteLine(job.JobId);
        }

        private static async Task<List<Jobs.Job>> GetJobs(Uri baseUri, string bearerToken)
        {
            string endpoint = "list";
            Uri requestUri = new Uri(baseUri, endpoint);
            var streamTask = client.GetStreamAsync(requestUri);
            var response = await JsonSerializer.DeserializeAsync<Jobs.List.Response>(await streamTask);
            var jobs = response.Jobs;
            return jobs;
        }



        private static async Task<Jobs.Runs.Run> GetJobRun(long runId, bool includeHistory, DatabricksMessage runRequest)
        {
            var queryParameters = new NameValueCollection()
            {
                { "run_id", runId.ToString() },
                { "include_history", includeHistory.ToString().ToLower() },

            };
            
            string requestUri = runRequest.GetEndpoint("jobs/runs/get", queryParameters);
            Console.WriteLine(requestUri);
            var streamTask = client.GetStreamAsync(requestUri);
            var response = await JsonSerializer.DeserializeAsync<Jobs.Runs.Run>(await streamTask);
            return response;


        }
    }
}