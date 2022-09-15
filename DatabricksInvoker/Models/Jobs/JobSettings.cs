using Newtonsoft.Json;

namespace DatabricksInvoker.Models.Jobs
{

    public class JobSettings : JobSettingsBase<JobTaskSettings>
    {
        [JsonConstructor]
        public JobSettings(string? name, Dictionary<string, string>? tags, 
            List<JobTaskSettings> tasks, string format,
            List<JobCluster>? jobClusters = null,
            JobEmailNotifications? emailNotifications = null, 
            int? timeoutSeconds = null, 
            CronSchedule? schedule = null, 
            int? maxConcurrentRuns = null, 
            string? gitSource = null) : base(
                tasks, jobClusters, schedule, gitSource, format)
        {
            Name = name;
            Tags = tags ?? new Dictionary<string, string>();
            EmailNotifications = emailNotifications;
            TimeoutSeconds = timeoutSeconds;
            MaxConcurrentRuns = maxConcurrentRuns;
        }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("tags")]
        public Dictionary<string, string> Tags { get; set; } = new Dictionary<string, string>();

        [JsonProperty("email_notifications")]
        public JobEmailNotifications? EmailNotifications { get; set; }

        [JsonProperty("timeout_seconds")]
        public int? TimeoutSeconds { get; set; }

        [JsonProperty("max_concurrent_runs")]
        public int? MaxConcurrentRuns { get; set; }
    }
}