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
using DatabricksInvoker.CmdLineOptions;
using DatabricksInvoker.Operators;

namespace DatabricksInvoker
{
    class Program
    {
        private static readonly HttpClient client = new();
        
        static async Task Main(string[] args)
        {
            string bearerToken = Environment.GetEnvironmentVariable("BEARER_TOKEN");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", bearerToken);


            await Parser.Default.ParseArguments<RunOptions>(args).WithParsedAsync(
                RunJob);
        }

        static async Task RunJob(RunOptions options)
        {
            JobsOperator jobsOperator = new(options);

            var response = await resource.SendRequest(client, baseUri);
            Console.WriteLine(response.RunId);

            var queryParams = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("run_id", response.RunId.ToString()),
                new KeyValuePair<string, string>("include_history", "false")
            };

            Run runMetaData = new();
            GetResource runResource = new(queryParams);
            bool isRunning = true;


            while (isRunning)
            {
                runMetaData = await runResource.SendRequest(client, baseUri);
                var runState = runMetaData.State;

                Console.WriteLine(Utils.ToJSONString(runState));

                switch (runState.LifeCycleState)
                {
                    case "PENDING":
                    case "RUNNING":
                        {
                            await Task.Delay(60 * 1000);
                            break;
                        }
                    case "TERMINATING":
                        {
                            await Task.Delay(60 * 1000);
                            break;
                        }
                    case "TERMINATED":
                        {
                            isRunning = false;
                            break;
                        }
                    case "SKIPPED":
                        {
                            isRunning = false;
                            break;
                        }
                    case "INTERNAL_ERROR":
                        {
                            throw new Exception("Job failed.");
                        }
                }

            }
            Console.WriteLine(Utils.ToJSONString(runMetaData));





        }

        //private static async Task RunNow(RunOptions options)
        //{
        //    Console.WriteLine("do we reach here?");

        //    var response = await resource.SendRequest(client, baseUri);
        //    Console.WriteLine(response);
        //}

        static void HandleParseError(IEnumerable<Error> errs)
        {
            throw new ArgumentException("incorrect arguments.");
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