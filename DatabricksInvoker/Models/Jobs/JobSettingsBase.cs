using Newtonsoft.Json;

namespace DatabricksInvoker.Models.Jobs
{

    public abstract class JobSettingsBase<TaskType>
    {
        [JsonConstructor]

        public JobSettingsBase(
            List<TaskType> tasks,
            List<JobCluster>? jobClusters,
            CronSchedule? schedule,
            string? gitSource,
            string format)
        {
            Tasks = tasks;
            JobClusters = jobClusters;
            Schedule = schedule;
            GitSource = gitSource;
            Format = format;
        }

        public List<TaskType> Tasks { get; set; }
        [JsonProperty("job_clusters")]
        public List<JobCluster>? JobClusters { get; set; }
        [JsonProperty("email_notifications")]
        public CronSchedule? Schedule { get; set; }
        [JsonProperty("max_concurrent_runs")]
        public string? GitSource { get; set; }
        [JsonProperty("format")]
        public string Format { get; set; }
    }
}