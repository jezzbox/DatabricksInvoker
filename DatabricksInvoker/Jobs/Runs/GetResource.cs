using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DatabricksInvoker.Jobs.Runs
{
    internal class GetResource : Resource, IResource<HttpClient, Uri, Run>
    {

        public GetResource(List<KeyValuePair<string, string>> queryParams)
        {
            QueryParams = queryParams;
        }
        public override string Path { get; } = "/api/2.1/jobs/runs/get";

        public override JSONSchema? Payload => throw new NotImplementedException();

        public override Run? Response { get;}

        public async Task<Run> SendRequest(HttpClient client, Uri baseUri)
        {
            var endpoint = GetEndpoint(baseUri);
            var streamTask = client.GetStreamAsync(endpoint);
            var response = await JsonSerializer.DeserializeAsync<Run>(await streamTask);
            return response!;
        }
    }
}
