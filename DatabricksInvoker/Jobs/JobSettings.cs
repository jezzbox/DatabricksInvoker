using System.Text.Json.Serialization;
using DatabricksInvoker.Clusters;
using DatabricksInvoker.Tasks;

namespace DatabricksInvoker.Jobs;

public class JobSettings
{
    [JsonPropertyName("name")]
    public string Name { get; set; }
    
    [JsonPropertyName("tags")]
    public Dictionary<string, string> Tags { get; set; }
    [JsonPropertyName("tasks")]
    public List<JobTaskSettings> Tasks { get; set;}
    [JsonPropertyName("job_clusters")]
    public List<JobCluster> JobClusters { get; set;}
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