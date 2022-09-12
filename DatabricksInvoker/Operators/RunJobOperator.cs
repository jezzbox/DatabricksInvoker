using DatabricksInvoker.CmdLineOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabricksInvoker.Models;
using System.Text.Json;

namespace DatabricksInvoker.Operators
{
    internal class RunJobOperator : JobsOperator, IOperator<HttpClient, RunNowResponse>
    {
        public RunJobOperator(RunOptions options)
        {
            if (options.Payload != null)
            {
                Payload = JsonSerializer.Deserialize<RunNowPayload>(options.Payload)!;
            }

            else if (options.JobId != null)
            {
                long jobId = options.JobId.Value;
                Payload = new(jobId, options.Params, options.ParamType);
            }
            else
            {
                throw new ArgumentException("Must have either job-id or payload parameter.");
            }
        }

        public override string Path { get; } = "/api/2.1/jobs/run-now";

        public RunNowPayload Payload { get; }

        public RunNowResponse? Response { get; }

        public async Task<RunNowResponse> SendRequest(HttpClient client)
        {
            string jsonString = Utils.ToJSONString(Payload);

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
    }
}
