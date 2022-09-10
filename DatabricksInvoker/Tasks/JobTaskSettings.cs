using System.Text.Json.Serialization;

namespace DatabricksInvoker.Tasks;

public class JobTaskSettings : Task
{
    [JsonPropertyName("timeout_seconds")]
    public int TimeoutSeconds { get; set; }
    [JsonPropertyName("max_retries")]
    public int MaxRetries { get; set; }
    [JsonPropertyName("min_retry_interval_millis")]
    public int MinRetryIntervalMillis { get; set; }
    [JsonPropertyName("retry_on_timeout")]
    public bool RetryOnTimeout { get; set; }
}