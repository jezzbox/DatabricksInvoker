using DatabricksInvoker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DatabricksInvoker.Operators
{
    internal class GetRunOperator : JobsOperator, IOperator<HttpClient, JobRun>
    {
        public override string Path { get; } = "/api/2.1/jobs/runs/get";

        public async Task<JobRun> SendRequest(HttpClient client)
        {
            var endpoint = GetEndpoint(BaseUri);
            var streamTask = client.GetStreamAsync(endpoint);
            var response = await JsonSerializer.DeserializeAsync<JobRun>(await streamTask);
            return response!;
        }
    }
}
