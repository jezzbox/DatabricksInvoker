using DatabricksInvoker.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Threading.Tasks;

namespace DatabricksInvoker.Models.Jobs.HttpMessages
{
    public class RunOutputResponse
    {
        [JsonConstructor]
        public RunOutputResponse(NotebookOutput? notebookOutput, SqlOutput? sqlOutput, DbtOutput? dbtOutput, string? logs, bool? logsTruncated, string? error, string? errorTrace, JobTaskRun metadata)
        {
            NotebookOutput = notebookOutput;
            SqlOutput = sqlOutput;
            DbtOutput = dbtOutput;
            Logs = logs;
            LogsTruncated = logsTruncated;
            Error = error;
            ErrorTrace = errorTrace;
            Metadata = metadata;
        }

        [JsonProperty("notebook_output")]
        public NotebookOutput? NotebookOutput { get; set; }
        [JsonProperty("sql_output")]
        public SqlOutput? SqlOutput { get; set; }
        [JsonProperty("dbt_output")]
        public DbtOutput? DbtOutput { get; set; }
        [JsonProperty("logs")]
        public string? Logs { get; set; }
        [JsonProperty("logs_truncated")]
        public bool? LogsTruncated { get; set; }
        [JsonProperty("error")]
        public string? Error { get; set; }
        [JsonProperty("error_trace")]
        public string? ErrorTrace { get; set; }

        [JsonProperty("metadata")]
        public JobTaskRun Metadata { get; set; }

    }
}
