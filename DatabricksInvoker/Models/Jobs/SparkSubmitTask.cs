using Newtonsoft.Json;


namespace DatabricksInvoker.Models.Jobs
{
    public class SparkSubmitTask
    {
        public SparkSubmitTask(List<string> parameters)
        {
            Parameters = parameters;
        }

        [JsonProperty("parameters")]
        public List<string> Parameters { get; set; }
    }
}
