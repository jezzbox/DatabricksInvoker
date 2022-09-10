using System.Text.Json.Serialization;
using DatabricksInvoker.Clusters;

namespace DatabricksInvoker.Runs;

public class Run
{
    [JsonPropertyName("job_id")]
    public long JobId {get; set;}
    
    [JsonPropertyName("run_id")]
    public long RunId {get; set;}
    
    [JsonPropertyName("number_in_job")]
    public long NumberInJob {get; set;}
    
    [JsonPropertyName("creator_user_name")]
    public string CreatorUserName { get; set; }
    
    [JsonPropertyName("original_attempt_run_id")]
    public long OriginalAttemptRunId { get; set; }
    
    [JsonPropertyName("state")]
    public RunState State { get; set; }
    
    [JsonPropertyName("tasks")]
    public List<Tasks.Task> Tasks { get; set;}
    
    [JsonPropertyName("job_clusters")]
    public List<JobCluster> JobClusters { get; set;}
    
    [JsonPropertyName("cluster_spec")]
    public ClusterSpec ClusterSpec { get; set;}
    
    [JsonPropertyName("cluster_instance")]
    public Dictionary<string, string> ClusterInstance { get; set;}
    
    [JsonPropertyName("git_source")]
    public string GitSource { get; set; }
    
    [JsonPropertyName("overriding_parameters")]
    public RunParameters OverridingParameters { get; set; }
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
    
    [JsonPropertyName("trigger")]
    public string Trigger { get; set; }
    
    [JsonPropertyName("run_name")]
    public string RunName { get; set; }
    
    [JsonPropertyName("run_page_url")]
    public string RunPageUrl { get; set; }
    
    [JsonPropertyName("run_type")]
    public string RunType { get; set; }
    
    [JsonPropertyName("attempt_number")]
    public int AttemptNumber { get; set; }

    [JsonPropertyName("repair_history")]
    public List<RepairHistoryItem> RepairHistory { get; set; }
    
}

