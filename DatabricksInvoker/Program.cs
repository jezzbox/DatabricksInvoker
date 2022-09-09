using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
namespace DatabricksInvoker
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();
        private static async Task Main(string[] args)
        {
            await ProcessRepositories();
        }

        private static async Task ProcessRepositories()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
            client.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", Environment.GetEnvironmentVariable("BEARER_TOKEN"));
            var stringTask = client.GetStringAsync("https://adb-1487230804890814.14.azuredatabricks.net/api/2.1/jobs/list");
            var msg = await stringTask;
            Console.Write(msg);
            var streamTask = client.GetStreamAsync("https://adb-1487230804890814.14.azuredatabricks.net/api/2.1/jobs/list");
            var response = await JsonSerializer.DeserializeAsync<ListJobsResponse>(await streamTask);
            var jobs = response.Jobs;
            foreach (var job in jobs)
                Console.WriteLine(job.JobId);
        }
    }
}