
using Newtonsoft.Json;

namespace DatabricksInvoker.Models.Jobs;

public class JobCluster
{
    public JobCluster(string jobClusterKey, Cluster? newCluster)
    {
        JobClusterKey = jobClusterKey;
        NewCluster = newCluster;
    }

    [JsonProperty("job_cluster_key")]
    public string JobClusterKey { get; set; }
    [JsonProperty("new_cluster")]
    public Cluster? NewCluster { get; set; }
}