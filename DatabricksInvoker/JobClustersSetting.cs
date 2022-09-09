using System.Text.Json.Serialization;

namespace DatabricksInvoker;

public class JobClustersSetting
{
    [JsonPropertyName("job_cluster_key")]
    public string JobClusterKey { get; set; }
    [JsonPropertyName("new_cluster")]
    public Cluster NewCluster { get; set; }
}