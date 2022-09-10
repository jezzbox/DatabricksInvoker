using System.Text.Json.Serialization;

namespace DatabricksInvoker.Jobs;

public class EmailNotificationsSetting
{
    [JsonPropertyName("on_start")]
    public List<string> OnStart { get; set; }
    [JsonPropertyName("on_success")]
    public List<string> OnSuccess { get; set; }
    [JsonPropertyName("on_failure")]
    public List<string> OnFailure { get; set; }
    [JsonPropertyName("no_alert_for_skipped_runs")]
    public bool NoAlertForSkippedRuns { get; set; }
}