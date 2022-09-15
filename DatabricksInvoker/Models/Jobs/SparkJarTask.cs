using Newtonsoft.Json;

namespace DatabricksInvoker.Models.Jobs;

public class SparkJarTask
{
    [JsonConstructor]
    public SparkJarTask(string mainClassName, List<string>? parameters = null)
    {
        if (parameters == null)
            Parameters = new();
        else
            Parameters = parameters;

        MainClassName = mainClassName;
    }
    [JsonProperty("main_class_name")]
    public string MainClassName { get; set; }
    [JsonProperty("parameters")]
    public List<string> Parameters { get; set; }
}