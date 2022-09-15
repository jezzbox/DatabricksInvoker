using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DatabricksInvoker.Models.Jobs
{
    public class JobEmailNotifications
    {
        [JsonConstructor]
        public JobEmailNotifications(List<string>? onStart = null,
            List<string>? onSuccess = null,
            List<string>? onFailure = null,
            bool? noAlertForSkippedRuns = null)
        {
            OnStart = onStart;
            OnSuccess = onSuccess;
            OnFailure = onFailure;
            NoAlertForSkippedRuns = noAlertForSkippedRuns;
        }

        [JsonProperty("on_start")]
        public List<string>? OnStart { get; set; } = new List<string>();
        [JsonProperty("on_success")]
        public List<string>? OnSuccess { get; set; } = new List<string>();
        [JsonProperty("on_failure")]
        public List<string>? OnFailure { get; set; } = new List<string>();
        [JsonProperty("no_alert_for_skipped_runs")]
        public bool? NoAlertForSkippedRuns { get; set; }
    }
}