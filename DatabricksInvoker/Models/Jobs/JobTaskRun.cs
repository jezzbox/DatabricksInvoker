using Newtonsoft.Json;
using DatabricksInvoker.Http;
using DatabricksInvoker.Models.Common;


namespace DatabricksInvoker.Models.Jobs
{

    public class JobTaskRun : JobRun
    {
        [JsonConstructor]
        public JobTaskRun(string taskKey, long parentRunId,
            long jobId, long runId, RunState state, List<RunTask> tasks,
            long startTime, long setupDuration, long executionDuration, long cleanupDuration,
            long endTime, string trigger, string runPageUrl, string runType, string format,
            string? creatorUserName = null, long? originalAttemptRunId = null,
            CronSchedule? schedule = null, List<JobCluster>? jobClusters = null,
            ClusterSpec? clusterSpec = null, Dictionary<string, string>? clusterInstance = null,
            string? gitSource = null, RunParameters? overridingParameters = null, string? RunName = null) : base(jobId, runId, state, tasks,
                                                                                                                    startTime, setupDuration, executionDuration, cleanupDuration,
                                                                                                                    endTime, trigger, runPageUrl, runType, format,
                                                                                                                    creatorUserName, originalAttemptRunId,
                                                                                                                    schedule, jobClusters,
                                                                                                                    clusterSpec, clusterInstance,
                                                                                                                    gitSource, overridingParameters, RunName)
        {
            TaskKey = taskKey;
            ParentRunId = parentRunId;
        }

        [JsonProperty("task_key")]
        public string TaskKey { get; set; }

        [JsonProperty("parent_run_id")]
        public long ParentRunId { get; set; }

    }
}

