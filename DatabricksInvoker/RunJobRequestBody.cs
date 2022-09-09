using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DatabricksInvoker;

public class RunJobRequestBody
{
    public RunJobRequestBody(long jobId, int clientId, string date)
    {
        JobId = jobId;
        NotebookParams = new Dictionary<string, string>()
        {
            { "client_id", clientId.ToString() },
            { "date", date }
        };
    }
    [JsonPropertyName("job_id")]
    public long JobId { get; set; }
    [StringLength(64)]
    [JsonPropertyName("idempotency_token")]
    public string IdempotencyToken { get; set; }
    [JsonPropertyName("jar_params")]
    public List<string> JarParams { get; set; }
    [JsonPropertyName("notebook_params")]
    public Dictionary<string,string> NotebookParams { get; set; }
    [JsonPropertyName("python_params")]
    public List<string> PythonParams { get; set; }
    [JsonPropertyName("spark_submit_params")]
    public List<string> SparkSubmitParams { get; set; }
    [JsonPropertyName("python_named_params")]
    public Dictionary<string,string> PythonNamedParams { get; set; }
    [JsonPropertyName("pipeline_params")]
    public Dictionary<string,string> PipelineParams { get; set; }
    [JsonPropertyName("sql_params")]
    public Dictionary<string,string> SqlParams { get; set; }
    [JsonPropertyName("dbt_commands")]
    public List<string> DbtCommands { get; set; }
}