using System.Text.Json.Serialization;

namespace DatabricksInvoker;

public class NotebookTask
{
    [JsonPropertyName("notebook_path")]
    public string NotebookPath { get; set; }
    [JsonPropertyName("base_parameters")]
    public Dictionary<string, string> BaseParameters { get; set; }
}