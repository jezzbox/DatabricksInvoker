using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using Newtonsoft.Json;
using DatabricksInvoker.CmdLineOptions;
using DatabricksInvoker.Models.Common;

namespace DatabricksInvoker.Models.Jobs.HttpMessages
{

    public class RunNowPayload
    {
        public RunNowPayload(string jsonString)
        {

            var payload = jsonString.ToObject<RunNowPayload>();
            if (payload != null)
            {
                JobId = payload.JobId;
                IdempotencyToken = payload.IdempotencyToken;
                JarParams = payload.JarParams;
                NotebookParams = payload.NotebookParams;
                PythonParams = payload.PythonParams;
                SparkSubmitParams = payload.SparkSubmitParams;
                PythonNamedParams = payload.PythonNamedParams;
                PipelineParams = payload.PipelineParams;
                SqlParams = payload.SqlParams;
                DbtCommands = payload.DbtCommands;
            }
            else
            {
                throw new ArgumentNullException(nameof(payload), "payload is null. You likely have a messed up string.");
            }

        }
        public RunNowPayload(long jobId, string? notebookParams, string? jarParams,
            string? pythonParams, string? sparkSubmitParams, string? pythonNamedParams,
            string? pipelineParams, string? sqlParams, string? dbtCommands)
        {
            JobId = jobId;
            IdempotencyToken = null;

            NotebookParams = notebookParams.ToObject<Dictionary<string, string?>>();
            JarParams = jarParams.ToObject<List<string?>>();
            PythonParams = pythonParams.ToObject<List<string?>>();
            SparkSubmitParams = sparkSubmitParams.ToObject<List<string?>>();
            PythonNamedParams = pythonNamedParams.ToObject<Dictionary<string, string?>>();
            PipelineParams = pipelineParams.ToObject<Dictionary<string, string?>>();
            SqlParams = sqlParams.ToObject<Dictionary<string, string?>>();
            DbtCommands = dbtCommands.ToObject<List<string?>>();
        }

        [JsonConstructor]
        public RunNowPayload(long jobId, string? idempotencyToken, List<string?> jarParams, Dictionary<string, string?> notebookParams, List<string?> pythonParams, List<string?> sparkSubmitParams, Dictionary<string, string?> pythonNamedParams, Dictionary<string, string?> pipelineParams, Dictionary<string, string?> sqlParams, List<string?> dbtCommands)
        {
            JobId = jobId;
            IdempotencyToken = idempotencyToken;
            JarParams = jarParams;
            NotebookParams = notebookParams;
            PythonParams = pythonParams;
            SparkSubmitParams = sparkSubmitParams;
            PythonNamedParams = pythonNamedParams;
            PipelineParams = pipelineParams;
            SqlParams = sqlParams;
            DbtCommands = dbtCommands;
        }

        [JsonProperty("job_id")]
        public long JobId { get; }

        [StringLength(64)]
        [JsonProperty("idempotency_token")]
        public string? IdempotencyToken { get; set; }

        [JsonProperty("jar_params")]
        public List<string?>? JarParams { get; set; } = new();

        [JsonProperty("notebook_params")]
        public Dictionary<string, string?>? NotebookParams { get; } = new();

        [JsonProperty("python_params")]
        public List<string?>? PythonParams { get; } = new();

        [JsonProperty("spark_submit_params")]
        public List<string?>? SparkSubmitParams { get; } = new();

        [JsonProperty("python_named_params")]
        public Dictionary<string, string?>? PythonNamedParams { get; } = new();

        [JsonProperty("pipeline_params")]
        public Dictionary<string, string?>? PipelineParams { get; } = new();

        [JsonProperty("sql_params")]
        public Dictionary<string, string?>? SqlParams { get; } = new();

        [JsonProperty("dbt_commands")]
        public List<string?>? DbtCommands { get; } = new();
    }
}