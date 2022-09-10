using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace DatabricksInvoker
{
    class Program
    {
        private static readonly HttpClient client = new();
        
        
        
        private static async Task Main(string[] args)
        {
            string bearerToken = Environment.GetEnvironmentVariable("BEARER_TOKEN");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", bearerToken);
            
            long jobId = 379702724573372;
            int clientId = 16;
            string date = "20220705";
            Uri baseUri = new Uri(args[0] + "/api/2.1/");
            var queryString = await GetJobRun(1234, true, baseUri);
            Console.WriteLine(queryString);
            // var runJobResponse = await RunJob(379702724573372, clientId, date, baseUri, bearerToken);
            // Console.WriteLine(runJobResponse.RunId);
            // foreach (var job in jobs)
            //     Console.WriteLine(job.JobId);
        }

        private static async Task<List<Jobs.Job>> GetJobs(Uri baseUri, string bearerToken)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", bearerToken);
            
            string endpoint = "jobs/list";
            Uri requestUri = new Uri(baseUri, endpoint);
            var streamTask = client.GetStreamAsync(requestUri);
            var response = await JsonSerializer.DeserializeAsync<Jobs.List.Response>(await streamTask);
            var jobs = response.Jobs;
            return jobs;
        }

        private static async Task<Runs.RunNow.Response> RunJob(long jobId, int clientId, string date, Uri baseUri, string bearerToken)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", bearerToken);

            var requestBody = new Runs.RunNow.requestBody(jobId, clientId, date);
            Console.WriteLine(requestBody.JobId);
            var json = JsonSerializer.Serialize(requestBody);
            Console.WriteLine(json);
            var jsonBody = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
            Console.WriteLine(jsonBody);
            
            const string endpoint = "jobs/run-now";
            Uri requestUri = new Uri(baseUri, endpoint);
            Console.WriteLine(requestUri);
            var response = await client.PostAsync(requestUri, jsonBody);
            var streamTask = response.Content.ReadAsStreamAsync();
            var runJobResponse = await JsonSerializer.DeserializeAsync<Runs.RunNow.Response>(await streamTask);
            return runJobResponse;

        }

        private static async Task<Runs.Run> GetJobRun(long runId, bool includeHistory, Uri baseUri)
        {
            var queryParameters = HttpUtility.ParseQueryString("");
            queryParameters["run_id"] = runId.ToString();
            queryParameters["include_history"] = includeHistory.ToString().ToLower();
            
            const string endpoint = "jobs/runs/get";
            Uri requestUri = new Uri(baseUri, endpoint);
            UriBuilder requestUriBuilder = new UriBuilder(requestUri);
            requestUriBuilder.Query = queryParameters.ToString();
            
            var streamTask = client.GetStreamAsync(requestUriBuilder.ToString());
            var response = await JsonSerializer.DeserializeAsync<Runs.Run>(await streamTask);
            return response;


        }
    }
}