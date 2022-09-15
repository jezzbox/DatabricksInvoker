using Newtonsoft.Json;
namespace DatabricksInvoker.Models.Jobs;

public class NotebookTask
{
    [JsonConstructor]
    public NotebookTask(string notebookPath, Dictionary<string, string> baseParameters)
    {
        NotebookPath = notebookPath; 
        BaseParameters = baseParameters;
    }

    [JsonProperty("notebook_path")]
    public string NotebookPath { get; set; }
    [JsonProperty("source")]

    public string? Source { get; set; }
    [JsonProperty("base_parameters")]
    public Dictionary<string, string> BaseParameters { get; set; }
}