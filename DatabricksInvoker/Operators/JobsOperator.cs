using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabricksInvoker.Models;
using DatabricksInvoker;
using System.Text.Json;
using DatabricksInvoker.CmdLineOptions;

namespace DatabricksInvoker.Operators
{
    public abstract class JobsOperator
    {
        public JobsOperator(RunOptions runOptions)
        {
            BaseUri = new(runOptions.Url);
        }

        public Uri BaseUri { get; }

        public abstract Options Options { get; }

        //public static async Task<List<Jobs.Job>> GetJob(BaseUri, )
        //{

        //}

        public async Task<RunNowResponse> RunJob(HttpClient client)
        {
            const string Path = "/api/2.1/jobs/run-now";
            RunNowPayload payload;

            if (RunOptions.Payload != null)
            {
                payload = JsonSerializer.Deserialize<RunNowPayload>(RunOptions.Payload)!;
            }

            else if (RunOptions.JobId != null)
            {
                long jobId = RunOptions.JobId.Value;
                payload = new(jobId, RunOptions.Params, RunOptions.ParamType);
            }
            else
            {
                throw new ArgumentException("Must have either job-id or payload parameter.");
            }

            string jsonString = Utils.ToJSONString(payload);

            var stringContent = new StringContent(
                jsonString, Encoding.UTF8, "application/json"
                );

            var endpoint = new Uri(BaseUri, Path);

            HttpResponseMessage response = await client.PostAsync(endpoint, stringContent);
            response.EnsureSuccessStatusCode();

            var streamTask = response.Content.ReadAsStreamAsync();

            var runNowResponse = await JsonSerializer.DeserializeAsync<RunNowResponse>(await streamTask);
            return runNowResponse!;
        }

        //public static async Task<List<Jobs.Job>> GetRunStatus(BaseUri, string bearerToken)
        //{

        //}

        //public static async Task<List<Jobs.Job>> GetRunOutput(BaseUri, string bearerToken)
        //{

        //}
    }
}
