using Newtonsoft.Json;

namespace DatabricksInvoker.Models.Jobs;

public abstract partial class JobTaskSettingsBase
{
    [JsonConstructor]
    public JobTaskSettingsBase(string taskKey, string? description,
        List<Dictionary<string, string>>? dependsOn, string? existingClusterId,
        Cluster? newCluster, SparkJarTask sparkJarTask,
        List<Dictionary<string, string>>? libraries,
        NotebookTask? notebookTask)
    {
        TaskKey = taskKey;
        Description = description;
        DependsOn = dependsOn;
        ExistingClusterId = existingClusterId;
        NewCluster = newCluster;
        SparkJarTask = sparkJarTask;
        Libraries = libraries;
        NotebookTask = notebookTask;
    }

    [JsonProperty("task_key")]
    public string TaskKey { get; set; }
    [JsonProperty("description")]
    public string? Description { get; set; }
    [JsonProperty("depends_on")]
    public List<Dictionary<string, string>>? DependsOn { get; set; }
    [JsonProperty("existing_cluster_id")]
    public string? ExistingClusterId { get; set; }

    [JsonProperty("new_cluster")]
    public Cluster? NewCluster { get; set; }
    [JsonProperty("spark_jar_task")]
    public SparkJarTask SparkJarTask { get; set; }
    [JsonProperty("libraries")]
    public List<Dictionary<string, string>>? Libraries { get; set; } = new();
    [JsonProperty("notebook_task")]
    public NotebookTask? NotebookTask { get; set; }

    [JsonProperty("spark_python_task")]
    public SparkPythonTask? SparkPythonTask { get; set; }
    [JsonProperty("spark_submit_task")]
    public SparkSubmitTask SparkSubmitTask { get; set; }
    [JsonProperty("pipeline_task")]
    public PipelineTask? PipelineTask { get; set; }
    [JsonProperty("python_wheel_task")]
    public PythonWheelTask? PythonWheelTask { get; set; }
    [JsonProperty("sql_task")]
    public SqlTask? SqlTask { get; set; }
    [JsonProperty("dbt_task")]
    public DbtTask? DbtTask { get; set; }

}