using System.Text.Json.Serialization;

namespace DatabricksInvoker.Clusters;

public class JobCluster
{
    [JsonPropertyName("job_cluster_key")]
    public string JobClusterKey { get; set; }
    [JsonPropertyName("new_cluster")]
    public Cluster NewCluster { get; set; }
}