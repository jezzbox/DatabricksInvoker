using CommandLine;
using DatabricksInvoker.Models.Jobs.HttpMessages;

namespace DatabricksInvoker.CmdLineOptions;

[Verb("run", HelpText = "Run a databricks job.")]
public class RunOptions : Options
{

    [Option('p', "payload", Required = false, HelpText = "Payload of request as JSON String")]
    public string? Payload { get; set; }

    [Option('i', "job-id", Required = false, HelpText = "The Job Id to run.")]
    public long? JobId { get; set; }

    [Option('s', "sleep-interval", Required = false, HelpText = "The interval to sleep between getting updates from the Databricks server")]
    public int? SleepInterval { get; set; }

    [Option("notebook-params", Required = false, HelpText = "The notebook params as a JSON string")]
    public string? NotebookParams { get; set; }

    [Option("jar-params", Required = false, HelpText = "The notebook params as a JSON string")]
    public string? JarParams { get; set; }

    [Option("python-params", Required = false, HelpText = "The notebook params as a JSON string")]
    public string? PythonParams { get; set; }

    [Option("spark-submit-params", Required = false, HelpText = "The notebook params as a JSON string")]
    public string? SparkSubmitParams { get; set; }

    [Option("python-named-params", Required = false, HelpText = "The notebook params as a JSON string")]
    public string? PythonNamedParams { get; set; }

    [Option("pipeline-params", Required = false, HelpText = "The notebook params as a JSON string")]
    public string? PipelineParams { get; set; }
    [Option("sql-params", Required = false, HelpText = "The notebook params as a JSON string")]
    public string? SqlParams { get; set; }
    [Option("dbt-commands", Required = false, HelpText = "The notebook params as a JSON string")]
    public string? DbtCommands { get; set; }


    public RunNowPayload ParsePayload()
    {
        if (Payload != null)
        {
            var payload = new RunNowPayload(Payload);
            return payload;
        }
        else if (JobId != null)
        {
            var jobId = JobId.Value;
            var payload = new RunNowPayload(jobId, NotebookParams, JarParams,
            PythonParams, SparkSubmitParams, PythonNamedParams,
            PipelineParams, SqlParams, DbtCommands );
            return payload;
        }
        else
        {
            throw new ArgumentException("Invalid arguments, must have either a payload or job-id");
        }
    }
}