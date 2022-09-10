using System.Text.Json.Serialization;

namespace DatabricksInvoker.Tasks;

public class SparkJarTask
{
    [JsonPropertyName("main_class_name")]
    public string MainClassName { get; set; }
    [JsonPropertyName("parameters")]
    public List<string> Parameters { get; set; }
}