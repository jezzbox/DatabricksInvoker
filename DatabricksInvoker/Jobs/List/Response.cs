using System.Text.Json.Serialization;

namespace DatabricksInvoker.Jobs.List;

public class Response
{
    [JsonPropertyName("jobs")]
    public List<Job> Jobs { get; set; }
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
}