using Newtonsoft.Json;
namespace DatabricksInvoker.Models.Jobs;

public class PythonWheelTask
{
    public PythonWheelTask(string packageName, string entryPoint, List<string>? parameters, List<string>? namedParameters)
    {
        PackageName = packageName;
        EntryPoint = entryPoint;
        Parameters = parameters;
        NamedParameters = namedParameters;
    }

    [JsonProperty("package_name")]
    public string PackageName { get; set; }

    [JsonProperty("entry_point")]
    public string EntryPoint { get; set; }

    [JsonProperty("parameters")]
    public List<string>? Parameters { get; set; }

    [JsonProperty("named_parameters")]
    public List<string>? NamedParameters { get; set; }
}