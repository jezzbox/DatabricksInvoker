using System.Text.Json.Serialization;

namespace DatabricksInvoker.Models.Jobs.HttpMessages;

public class ListJobsResponse
{
    public ListJobsResponse(List<Job> jobs, bool hasMore)
    {
        Jobs = jobs;
        HasMore = hasMore;
    }

    [JsonPropertyName("jobs")]
    public List<Job> Jobs { get; set; }
    [JsonPropertyName("has_more")]
    public bool HasMore { get; set; }
}