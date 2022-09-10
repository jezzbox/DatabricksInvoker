using System.Text.Json.Serialization;

namespace DatabricksInvoker.Clusters;

public class ClusterSpec
{
    public ClusterSpec(){}
    
    [JsonPropertyName("existing_cluster_id")]
    public string ExistingClusterId { get; set; }
    
    [JsonPropertyName("new_cluster")]
    public Cluster NewCluster { get; set; }
    
    [JsonPropertyName("libraries")]
    public List<Dictionary<string, string>> Libraries { get; set; }
    
}