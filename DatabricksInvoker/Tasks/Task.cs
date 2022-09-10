using System.Text.Json.Serialization;
using DatabricksInvoker.Clusters;

namespace DatabricksInvoker.Tasks;

public class Task
{
    [JsonPropertyName("task_key")]
    public string TaskKey { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("depends_on")]
    public List<Dictionary<string, string>> DependsOn { get; set; }
    [JsonPropertyName("existing_cluster_id")]
    public string ExistingClusterId { get; set; }
    [JsonPropertyName("job_cluster_key")]
    public string JobClusterKey { get; set; }
    [JsonPropertyName("new_cluster")]
    public Cluster NewCluster { get; set; }
    [JsonPropertyName("spark_jar_task")]
    public SparkJarTask SparkJarTask { get; set; }
    [JsonPropertyName("libraries")]
    public List<Dictionary<string, string>> Libraries { get; set; }
    [JsonPropertyName("notebook_task")]
    public NotebookTask NotebookTask { get; set; }

}