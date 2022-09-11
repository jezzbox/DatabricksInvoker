using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DatabricksInvoker.Jobs.Runs.RunNow;

public class Payload
{
    public Payload(long jobId, string? requestParams, string? paramType)
    {
        JobId = jobId;
        IdempotencyToken = "12345";

        switch (paramType)
        {
            case "jar":
            {
                var jarParams = JsonSerializer.Deserialize<List<string>>(requestParams);
                JarParams = jarParams;
                break;
            }
            case "notebook":
            {
                var notebookParams = JsonSerializer.Deserialize<Dictionary<string, string>>(requestParams);
                NotebookParams = notebookParams;
                break;
            }
            
            case "python":
            {
                var pythonParams = JsonSerializer.Deserialize<List<string>>(requestParams);
                PythonParams = pythonParams;
                break;
            }
            
            case "spark_submit":
            {
                var sparkSubmitParams = JsonSerializer.Deserialize<List<string>>(requestParams);
                SparkSubmitParams = sparkSubmitParams;
                break;
            }
            
            case "python_named":
            {
                var pythonNamedParams = JsonSerializer.Deserialize<Dictionary<string, string>>(requestParams);
                PythonNamedParams = pythonNamedParams;
                break;
            }
            
            case "pipeline":
            {
                var pipelineParams = JsonSerializer.Deserialize<Dictionary<string, string>>(requestParams);
                PipelineParams = pipelineParams;
                break;
            }
            
            case "sql":
            {
                var sqlParams = JsonSerializer.Deserialize<Dictionary<string, string>>(requestParams);
                SqlParams = sqlParams;
                break;
            }
            
            case "dbt_commands":
            {
                var dbtCommands= JsonSerializer.Deserialize<List<string>>(requestParams);
                DbtCommands = dbtCommands;
                break;
            }
        }
    }
    
    [JsonPropertyName("job_id")]
    public long JobId { get;}
    
    [StringLength(64)]
    [JsonPropertyName("idempotency_token")]
    public string? IdempotencyToken { get; set; }

    [JsonPropertyName("jar_params")]
    public List<string?> JarParams { get; }
    [JsonPropertyName("notebook_params")]
    public Dictionary<string,string?> NotebookParams { get;}

    [JsonPropertyName("python_params")] private List<string?> PythonParams { get; }
    [JsonPropertyName("spark_submit_params")]
    public List<string?> SparkSubmitParams { get;}
    [JsonPropertyName("python_named_params")]
    public Dictionary<string,string?> PythonNamedParams { get;}
    [JsonPropertyName("pipeline_params")]
    public Dictionary<string,string?> PipelineParams { get;}
    [JsonPropertyName("sql_params")]
    public Dictionary<string,string?> SqlParams { get;}
    [JsonPropertyName("dbt_commands")]
    public List<string?> DbtCommands { get;}
}