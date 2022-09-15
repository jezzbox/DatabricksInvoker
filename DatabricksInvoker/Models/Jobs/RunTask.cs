using Newtonsoft.Json;

namespace DatabricksInvoker.Models.Jobs;
public class RunTask : JobTaskSettingsBase, IRunSettings
{
    public RunTask(string taskKey, string? description,
        List<Dictionary<string, string>>? dependsOn, string? existingClusterId,
        Cluster? newCluster, SparkJarTask sparkJarTask,
        List<Dictionary<string, string>>? libraries,
        NotebookTask? notebookTask,
        long runId, RunState state, string runPageUrl, long startTime,
        long setupDuration, long executionDuration, long cleanupDuration,
        long endTime, Dictionary<string, string> clusterInstance,
        int attemptNumber) : base(taskKey, description, dependsOn, existingClusterId, newCluster, sparkJarTask, libraries, notebookTask)
    {
        RunId = runId;
        State = state;
        RunPageUrl = runPageUrl;
        StartTime = startTime;
        SetupDuration = setupDuration;
        ExecutionDuration = executionDuration;
        CleanupDuration = cleanupDuration;
        EndTime = endTime;
        ClusterInstance = clusterInstance;
        AttemptNumber = attemptNumber;
    }

    [JsonProperty("run_id")]
    public long RunId { get; set; }

    [JsonProperty("state")]
    public RunState State { get; set; }

    [JsonProperty("run_page_url")]
    public string RunPageUrl { get; set; }

    [JsonProperty("start_time")]
    public long StartTime { get; set; }

    [JsonProperty("setup_duration")]
    public long SetupDuration { get; set; }

    [JsonProperty("execution_duration")]
    public long ExecutionDuration { get; set; }

    [JsonProperty("cleanup_duration")]
    public long CleanupDuration { get; set; }

    [JsonProperty("end_time")]
    public long EndTime { get; set; }

    [JsonProperty("cluster_instance")]
    public Dictionary<string, string>? ClusterInstance { get; set; }

    [JsonProperty("attempt_number")]
    public int AttemptNumber { get; set; }

    [JsonProperty("git_source")]
    public string? GitSource { get; set; }
}