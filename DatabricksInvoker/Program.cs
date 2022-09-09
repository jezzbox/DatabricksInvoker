using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
namespace DatabricksInvoker
{
    class Program
    {
        private static readonly HttpClient client = new();
        
        private static async Task Main(string[] args)
        {
            long jobId = 379702724573372;
            int clientId = 16;
            string date = "20220705";
            Uri baseUri = new Uri(args[0] + "/api/2.1/");
            string bearerToken = Environment.GetEnvironmentVariable("BEARER_TOKEN");
            var runJobResponse = await RunJob(379702724573372, clientId, date, baseUri, bearerToken);
            Console.WriteLine(runJobResponse.RunId);
            // foreach (var job in jobs)
            //     Console.WriteLine(job.JobId);
        }

        private static async Task<List<Job>> GetJobs(Uri baseUri, string bearerToken)
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
            var response = await JsonSerializer.DeserializeAsync<ListJobsResponse>(await streamTask);
            var jobs = response.Jobs;
            return jobs;
        }

        private static async Task<RunJobResponse> RunJob(long jobId, int clientId, string date, Uri baseUri, string bearerToken)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", bearerToken);

            var requestBody = new RunJobRequestBody(jobId, clientId, date);
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
            var runJobResponse = await JsonSerializer.DeserializeAsync<RunJobResponse>(await streamTask);
            return runJobResponse;

        }
    }
}