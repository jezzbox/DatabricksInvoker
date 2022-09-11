using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace DatabricksInvoker.Jobs.Runs.RunNow;

public class Resource
{
    private const string Path = "/api/2.1/jobs/run-now";

    public Resource(RunOptions options)
    {
        Uri baseUri = new Uri(options.Url);
        Endpoint = new Uri(baseUri, Path);
        if (options.Payload != null)
        {
            Payload = JsonSerializer.Deserialize<Payload>(options.Payload)!;

        }
        else if (options.JobId != null)
        {
            long jobId = options.JobId.Value;
            Payload = new Payload(jobId, options.Params, options.ParamType);
        }
        else
        {
            throw new ArgumentException("Must have either job-id or payload parameter.");
        }
    }

    // public Resource(string payload)
    // {
    //     Payload = JsonSerializer.Deserialize<Payload>(payload)!;
    // }
    //
    // public Resource(long jobId, string requestParams, string paramType)
    // {
    //     Payload = new Payload(jobId, requestParams, paramType);
    // }
    
    public Uri Endpoint { get; }
    public Payload Payload { get;}
    public Response? Response { get; set; }
    
    public async Task<Response> RunNow(HttpClient client)
    {
        var payload = new StringContent(
            JsonSerializer.Serialize(Payload), Encoding.UTF8, "application/json"
            );
        
        var response = await client.PostAsync(Endpoint, payload);
        Console.Write(response.StatusCode);
        var streamTask = response.Content.ReadAsStreamAsync();
        Console.Write(streamTask);
        var runNowResponse = await JsonSerializer.DeserializeAsync<Response>(await streamTask);
        Console.WriteLine(runNowResponse);
        // Response = runNowResponse!;
        return runNowResponse;
    }
    
    public void PrintPayload()
    {
        Console.WriteLine(Endpoint);
        Console.WriteLine(JsonSerializer.Serialize(Payload));
    }
    
    public void PrintResponse()
    {
        Console.WriteLine(JsonSerializer.Serialize(Response));
    }
}