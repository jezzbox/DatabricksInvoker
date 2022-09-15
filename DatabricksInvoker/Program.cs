using CommandLine;
using DatabricksInvoker.CmdLineOptions;
using DatabricksInvoker.Http;
using DatabricksInvoker.Models.Common;
using DatabricksInvoker.Models.Jobs.HttpMessages;

namespace DatabricksInvoker
{
    class Program
    {
        private static readonly Uri baseUri = new(Environment.GetEnvironmentVariable("URL") ?? "");
        private static readonly string bearerToken = Environment.GetEnvironmentVariable("BEARER_TOKEN") ?? "";
        private static readonly DatabricksClient client = new(baseUri, bearerToken);
        
        static async Task Main(string[] args)
        {
            await Parser.Default.ParseArguments<RunOptions>(args).WithParsedAsync(o =>
                RunJob(o));
        }

        static async Task RunJob(RunOptions options)
        {
            int? sleepInterval = options.SleepInterval;
            RunNowPayload payload = options.ParsePayload();
            RunNowResponse response = await client.JobsAPI.RunNow(payload);
            var jobRun = await client.JobsAPI.AwaitRunResult(response.RunId, sleepInterval: sleepInterval ?? 60);
            Console.WriteLine(jobRun.ToJsonString());
            Console.WriteLine("SUCCESS for job run");
        }
    }
}