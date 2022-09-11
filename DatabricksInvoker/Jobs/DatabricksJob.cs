using System.Text.Json.Serialization;

namespace DatabricksInvoker.Jobs;

public class Job
{
    [JsonPropertyName("job_id")]
    public long JobId {get; set;}
    [JsonPropertyName("creator_user_name")]
    public string CreatorUserName { get; set; }
    [JsonPropertyName("run_as_user_name")]
    public string RunAsUserName { get; set; }
    [JsonPropertyName("settings")]
    public JobSettings Settings { get; set; }
    [JsonPropertyName("created_time")]
    public long CreatedTime { get; set; }
}