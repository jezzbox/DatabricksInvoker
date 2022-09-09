using System.Text.Json.Serialization;

namespace DatabricksInvoker;

public class JobTask
{
    [JsonPropertyName("task_key")]
    public string TaskKey { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("depends_on")]
    public List<Dictionary<string, string>> DependsOn { get; set; }
    [JsonPropertyName("existing_cluster_id")]
    public string ExistingClusterId { get; set; }
    [JsonPropertyName("job_cluster_key")]
    public string JobClusterKey { get; set; }
    [JsonPropertyName("new_cluster")]
    public Cluster NewCluster { get; set; }
    [JsonPropertyName("spark_jar_task")]
    public SparkJarTask SparkJarTask { get; set; }
    [JsonPropertyName("libraries")]
    public List<Dictionary<string, string>> Libraries { get; set; }
    [JsonPropertyName("notebook_task")]
    public NotebookTask NotebookTask { get; set; }
    [JsonPropertyName("timeout_seconds")]
    public int TimeoutSeconds { get; set; }
    [JsonPropertyName("max_retries")]
    public int MaxRetries { get; set; }
    [JsonPropertyName("min_retry_interval_millis")]
    public int MinRetryIntervalMillis { get; set; }
    [JsonPropertyName("retry_on_timeout")]
    public bool RetryOnTimeout { get; set; }
}