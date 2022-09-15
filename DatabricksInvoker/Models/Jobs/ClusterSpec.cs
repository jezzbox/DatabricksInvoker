using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DatabricksInvoker.Models.Jobs;

public class ClusterSpec
{
    public ClusterSpec(string existingClusterId, Cluster newCluster, List<Dictionary<string, string>> libraries)
    {
        ExistingClusterId = existingClusterId;
        NewCluster = newCluster;
        Libraries = libraries;
    }

    [JsonProperty("existing_cluster_id")]
    public string ExistingClusterId { get; set; }

    [JsonProperty("new_cluster")]
    public Cluster NewCluster { get; set; }

    [JsonProperty("libraries")]
    public List<Dictionary<string, string>> Libraries { get; set; }

}