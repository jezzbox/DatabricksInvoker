using System.Text.Json.Serialization;

namespace DatabricksInvoker.Runs;

public class RepairHistoryItem
{
    [JsonPropertyName("type")]
    public string Type { get; set; }
        
    [JsonPropertyName("start_time")]
    public long StartTime { get; set; }
        
    [JsonPropertyName("end_time")]
    public long EndTime { get; set; }
        
    [JsonPropertyName("state")]
    public RunState State { get; set; }
        
    [JsonPropertyName("id")]
    public long Id { get; set; }
        
    [JsonPropertyName("task_run_ids")]
    public List<long> TaskRunIds { get; set; }
}