using DatabricksInvoker.Models.Common;
using Newtonsoft.Json;

namespace DatabricksInvoker.Models.Jobs.HttpMessages
{
    public class RunNowResponse
    {
        [JsonConstructor]
        RunNowResponse(long runId, long numberInJob)
        {
            RunId = runId;
            NumberInJob = numberInJob;
        }

        [JsonProperty("run_id")]
        public long RunId { get; set; }
        [JsonProperty("number_in_job")]
        public long NumberInJob { get; set; }
    }
}