using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DatabricksInvoker.Models.Jobs;

public class Cluster
{
    public Cluster(string clusterId, string nodeTypeId, Dictionary<string, bool> sparkConf, Dictionary<string, string> awsAttributes, Dictionary<string, int> autoscale)
    {
        ClusterId = clusterId;
        NodeTypeId = nodeTypeId;
        SparkConf = sparkConf;
        AwsAttributes = awsAttributes;
        Autoscale = autoscale;
    }

    [JsonProperty("cluster_id")]
    public string ClusterId { get; set; }
    [JsonProperty("node_type_id")]
    public string NodeTypeId { get; set; }
    [JsonProperty("spark_conf")]
    public Dictionary<string, bool> SparkConf { get; set; }
    [JsonProperty("aws_attributes")]
    public Dictionary<string, string> AwsAttributes { get; set; }
    [JsonProperty("autoscale")]
    public Dictionary<string, int> Autoscale { get; set; }
}