using Newtonsoft.Json;

namespace DatabricksInvoker.Models.Jobs
{

    public class JobRun : JobSettingsBase<RunTask>, IRunSettings
    {
        [JsonConstructor]
        public JobRun(
            long jobId, long runId, RunState state, List<RunTask> tasks,
            long startTime, long setupDuration, long executionDuration, long cleanupDuration,
            long endTime, string trigger, string runPageUrl, string runType, string format,
            string? creatorUserName = null, long? originalAttemptRunId = null,
            CronSchedule? schedule = null, List<JobCluster>? jobClusters = null,
            ClusterSpec? clusterSpec = null, Dictionary<string, string>? clusterInstance = null,
            string? gitSource = null, RunParameters? overridingParameters = null, string? runName = null):base(
                tasks,jobClusters, schedule,gitSource,format)
        {
            JobId = jobId;
            RunId = runId;
            State = state;
            Tasks = tasks;
            StartTime = startTime;
            SetupDuration = setupDuration;
            ExecutionDuration = executionDuration;
            CleanupDuration = cleanupDuration;
            EndTime = endTime;
            Trigger = trigger;
            RunPageUrl = runPageUrl;
            RunType = runType;
            Format = format;

            CreatorUserName = creatorUserName;
            NumberInJob = jobId;
            OriginalAttemptRunId = originalAttemptRunId ?? runId;
            Schedule = schedule;
            JobClusters = jobClusters;
            ClusterSpec = clusterSpec;
            ClusterInstance = clusterInstance;
            GitSource = gitSource;
            OverridingParameters = overridingParameters ?? new RunParameters();
            RunName = runName;

        }

        [JsonProperty("job_id")]
        public long JobId { get; }

        [JsonProperty("run_id")]
        public long RunId { get; set; }

        [JsonProperty("creator_user_name")]
        public string? CreatorUserName { get; set; }

        [JsonProperty("number_in_job")]
        public long? NumberInJob { get; set; }

        [JsonProperty("original_attempt_run_id")]
        public long OriginalAttemptRunId { get; set; }

        [JsonProperty("state")]
        public RunState State { get; set; } = new();

        [JsonProperty("cluster_spec")]
        public ClusterSpec? ClusterSpec { get; set; }

        [JsonProperty("cluster_instance")]
        public Dictionary<string, string>? ClusterInstance { get; set; }

        [JsonProperty("overriding_parameters")]
        public RunParameters OverridingParameters { get; set; }

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

        [JsonProperty("trigger")]
        public string Trigger { get; set; }

        [JsonProperty("run_name")]
        public string? RunName { get; set; }

        [JsonProperty("run_page_url")]
        public string RunPageUrl { get; set; }

        [JsonProperty("run_type")]
        public string RunType { get; set; }

        [JsonProperty("attempt_number")]
        public int AttemptNumber { get; set; }

        [JsonProperty("repair_history")]
        public List<RepairHistoryItem>? RepairHistory { get; set; }

        public string GetCurrentState()
        {
            return State.LifeCycleState;
        }

        public string? GetResultState()
        {
            return State.ResultState;
        }
    }

}

