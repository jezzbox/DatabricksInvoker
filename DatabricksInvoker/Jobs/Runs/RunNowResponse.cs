using System.Text.Json.Serialization;

namespace DatabricksInvoker.Jobs.Runs;

public class RunNowResponse : JSONSchema
{
    [JsonPropertyName("run_id")]
    public long RunId { get; set; }
    [JsonPropertyName("number_in_job")]
    public long NumberInJob { get; set; }
}