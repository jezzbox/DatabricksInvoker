using System.Text.Json.Serialization;

namespace DatabricksInvoker;

public class ListJobsResponse
{
    [JsonPropertyName("jobs")]
    public List<Job> Jobs { get; set; }
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
}