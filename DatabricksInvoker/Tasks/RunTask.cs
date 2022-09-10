using System.Text.Json.Serialization;
using DatabricksInvoker.Runs;

namespace DatabricksInvoker.Tasks;

public class RunTask : Task
{
    [JsonPropertyName("run_id")]
    public long RunId { get; set; }
    
    [JsonPropertyName("state")]
    public RunState State { get; set; }
    
    [JsonPropertyName("run_page_url")]
    public string RunPageUrl { get; set; }
    
    [JsonPropertyName("start_time")]
    public long StartTime { get; set; }
    
    [JsonPropertyName("setup_duration")]
    public long SetupDuration { get; set; }
    
    [JsonPropertyName("execution_duration")]
    public long ExecutionDuration { get; set; }
    
    [JsonPropertyName("cleanup_duration")]
    public long CleanupDuration { get; set; }
    
    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }
    
    [JsonPropertyName("cluster_instance")]
    public Dictionary<string, string> ClusterInstance { get; set;}
    
    [JsonPropertyName("attempt_number")]
    public int AttemptNumber { get; set; }
}