using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace DatabricksInvoker.Jobs.Runs;

public class RunNowResource : Resource, IResource<HttpClient, Uri, RunNowResponse>
{
    public override string Path { get; } = "/api/2.1/jobs/run-now";

    public RunNowResource(RunOptions options)
    {
        if (options.Payload != null)
        {
            Payload = JsonSerializer.Deserialize<RunNowPayload>(options.Payload)!;
        }

        else if (options.JobId != null)
        {
            long jobId = options.JobId.Value;
            Payload = new RunNowPayload(jobId, options.Params, options.ParamType);
        }
        else
        {
            throw new ArgumentException("Must have either job-id or payload parameter.");
        }
    }

    public override RunNowPayload Payload { get; }
    public override RunNowResponse? Response { get; }

    public async Task<RunNowResponse> SendRequest(HttpClient client, Uri baseUri)
    {
        string jsonString = JsonSerializer.Serialize(Payload);

        var payload = new StringContent(
            jsonString, Encoding.UTF8, "application/json"
            );

        var endpoint = GetEndpoint(baseUri);

        HttpResponseMessage response = await client.PostAsync(endpoint, payload);
        response.EnsureSuccessStatusCode();

        var streamTask = response.Content.ReadAsStreamAsync();

        var runNowResponse = await JsonSerializer.DeserializeAsync<RunNowResponse>(await streamTask);
        return runNowResponse!;
    }
}