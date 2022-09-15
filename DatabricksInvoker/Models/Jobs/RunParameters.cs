using Newtonsoft.Json;

namespace DatabricksInvoker.Models.Jobs
{
    public class RunParameters
    {
        public RunParameters() { }

        [JsonProperty("jar_params")]
        public List<string> JarParams { get; set; } = new List<string>();

        [JsonProperty("notebook_params")]
        public Dictionary<string, string> NotebookParams { get; set; } = new Dictionary<string, string>();

        [JsonProperty("python_params")]
        public List<string> PythonParams { get; set; } = new List<string>();

        [JsonProperty("spark_submit_params")]
        public List<string> SparkSubmitParams { get; set; } = new List<string>();

        [JsonProperty("python_named_params")]
        public Dictionary<string, string> PythonNamedParams { get; set; } = new Dictionary<string, string>();

        [JsonProperty("pipeline_params")]
        public Dictionary<string, string> PipelineParams { get; set; } = new Dictionary<string, string>();

        [JsonProperty("sql_params")]
        public Dictionary<string, string> SqlParams { get; set; } = new Dictionary<string, string>();

        [JsonProperty("dbt_commands")]
        public List<string> DbtCommands { get; set; } = new List<string>();
    }
}