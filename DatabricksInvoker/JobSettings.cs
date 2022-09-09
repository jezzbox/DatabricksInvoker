using System.Text.Json.Serialization;

namespace DatabricksInvoker;

public class JobSettings
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("tags")]
    public Dictionary<string, string> Tags { get; set; }
    [JsonPropertyName("tasks")]
    public List<JobTask> Tasks { get; set;}
    [JsonPropertyName("job_clusters")]
    public JobClustersSetting JobClusters { get; set;}
    [JsonPropertyName("email_notifications")]
    public EmailNotificationsSetting EmailNotifications { get; set; }
    [JsonPropertyName("timeout_seconds")]
    public int TimeoutSeconds { get; set; }
    [JsonPropertyName("schedule")]
    public Dictionary<string, string> Schedule { get; set; }
    [JsonPropertyName("max_concurrent_runs")]
    public int MaxConcurrentRuns { get; set; }
    [JsonPropertyName("git_source")]
    public string GitSource { get; set; }
    [JsonPropertyName("format")]
    public string Format { get; set; }
}