using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabricksInvoker.Models.Jobs
{
    public class PipelineTask
    {
        public PipelineTask(string pipelineId, bool fullRefresh)
        {
            PipelineId = pipelineId;
            FullRefresh = fullRefresh;
        }

        [JsonProperty("pipeline_id")]
        public string PipelineId { get; set; }
        [JsonProperty("full_refresh")]
        public bool FullRefresh { get; set; }
    }
}
