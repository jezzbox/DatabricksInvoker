using System.Text.Json.Serialization;

namespace DatabricksInvoker.Clusters;

public class Cluster
{
    [JsonPropertyName("cluster_id")]
    public string ClusterId { get; set; }
    [JsonPropertyName("node_type_id")]
    public string NodeTypeId { get; set; }
    [JsonPropertyName("spark_conf")]
    public Dictionary<string, bool> SparkConf { get; set; }
    [JsonPropertyName("aws_attributes")]
    public Dictionary<string, string> AwsAttributes { get; set; }
    [JsonPropertyName("autoscale")]
    public Dictionary<string, int> Autoscale { get; set; }
}