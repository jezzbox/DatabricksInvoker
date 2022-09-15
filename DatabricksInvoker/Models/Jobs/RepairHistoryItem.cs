using Newtonsoft.Json;

namespace DatabricksInvoker.Models.Jobs
{
    public class RepairHistoryItem
    {

        public RepairHistoryItem(string type, long startTime, long endTime, RunState state, long id, List<long> taskRunIds)
        {
            Type = type;
            StartTime = startTime;
            EndTime = endTime;
            State = state;
            Id = id;
            TaskRunIds = taskRunIds;
        }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("start_time")]
        public long StartTime { get; set; }

        [JsonProperty("end_time")]
        public long EndTime { get; set; }

        [JsonProperty("state")]
        public RunState State { get; set; } = new();

        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("task_run_ids")]
        public List<long> TaskRunIds { get; set; } = new List<long>();
    }
}