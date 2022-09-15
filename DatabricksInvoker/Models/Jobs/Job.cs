using Newtonsoft.Json;


namespace DatabricksInvoker.Models.Jobs;

public class Job
{
    public Job(long jobId, JobSettings settings, bool? runAsOwner,
        string? creatorUserName = null, 
        string? runAsUserName = null, long createdTime = 0)
    {
        JobId = jobId;
        CreatorUserName = creatorUserName;
        RunAsUserName = runAsUserName;
        RunAsOwner = runAsOwner;
        Settings = settings;
        CreatedTime = createdTime;
    }

    [JsonProperty("job_id")]
    public long JobId { get; set; }
    [JsonProperty("creator_user_name")]
    public string? CreatorUserName { get; set; }
    [JsonProperty("run_as_user_name")]
    public string? RunAsUserName { get; set; }

    [JsonProperty("run_as_owner")]
    public bool? RunAsOwner { get; set; }
    [JsonProperty("settings")]

    public JobSettings Settings { get; set; }
    [JsonProperty("created_time")]
    public long CreatedTime { get; set; }
}