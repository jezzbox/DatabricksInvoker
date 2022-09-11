using System.Text.Json.Serialization;

namespace DatabricksInvoker.Jobs.Runs;

public class RunParameters
{
    [JsonPropertyName("jar_params")]
    public List<string> JarParams { get; set; }
    
    [JsonPropertyName("notebook_params")]
    public Dictionary<string, string> NotebookParams { get; set; }
    
    [JsonPropertyName("python_params")]
    public List<string> PythonParams { get; set; }
    
    [JsonPropertyName("spark_submit_params")]
    public List<string> SparkSubmitParams { get; set; }
    
    [JsonPropertyName("python_named_params")]
    public Dictionary<string, string> PythonNamedParams { get; set; }
    
    [JsonPropertyName("pipeline_params")]
    public Dictionary<string, string> PipelineParams { get; set; }
    
    [JsonPropertyName("sql_params")]
    public Dictionary<string, string> SqlParams { get; set; }
    
    [JsonPropertyName("dbt_commands")]
    public List<string> DbtCommands { get; set; }
}