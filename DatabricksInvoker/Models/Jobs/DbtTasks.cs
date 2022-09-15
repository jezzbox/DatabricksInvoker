using Newtonsoft.Json;

namespace DatabricksInvoker.Models.Jobs
{
    public class DbtTask
    {
        public DbtTask(string? projectDirectory, List<string> commands, string? schema, string? warehouseId, string? profilesDirectory)
        {
            ProjectDirectory = projectDirectory;
            Commands = commands;
            Schema = schema;
            WarehouseId = warehouseId;
            ProfilesDirectory = profilesDirectory;
        }

        [JsonProperty("project_directory")]
        public string? ProjectDirectory { get; set; }

        [JsonProperty("commands")]
        public List<string> Commands { get; set; }

        [JsonProperty("schema")]
        public string? Schema { get; set; }

        [JsonProperty("warehouse_id")]
        public string? WarehouseId { get; set; }

        [JsonProperty("profiles_directory")]
        public string? ProfilesDirectory { get; set; }
    }
}
