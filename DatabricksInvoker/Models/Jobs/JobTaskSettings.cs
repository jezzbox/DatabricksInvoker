using System.Text.Json.Serialization;

namespace DatabricksInvoker.Models.Jobs;

public class JobTaskSettings : JobTaskSettingsBase
{
    [JsonConstructor]
    public JobTaskSettings(string taskKey, string? description,
        List<Dictionary<string, string>>? dependsOn, string? existingClusterId,
        Cluster? newCluster, SparkJarTask sparkJarTask,
        List<Dictionary<string, string>>? libraries,
        JobEmailNotifications emailNotifications,
        int? timeoutSeconds,
        string jobClusterKey,
        int maxRetries,
        int minRetryIntervalMillis,
        bool retryOnTimeout,
        NotebookTask? notebookTask):base(taskKey,
            description, dependsOn, existingClusterId, newCluster, 
            sparkJarTask, libraries, notebookTask)
    {
        TimeoutSeconds = timeoutSeconds;
        JobClusterKey = jobClusterKey;
        EmailNotifications = emailNotifications;
        MaxRetries = maxRetries;
        MinRetryIntervalMillis = minRetryIntervalMillis;
        RetryOnTimeout = retryOnTimeout;
    }
    public JobEmailNotifications EmailNotifications { get; set; } = new();
    [JsonPropertyName("timeout_seconds")]
    public int? TimeoutSeconds { get; set; }
    [JsonPropertyName("max_retries")]
    public string? JobClusterKey { get; set; }
    [JsonPropertyName("new_cluster")]
    public int? MaxRetries { get; set; }
    [JsonPropertyName("min_retry_interval_millis")]
    public int? MinRetryIntervalMillis { get; set; }
    [JsonPropertyName("retry_on_timeout")]
    public bool? RetryOnTimeout { get; set; }
}