using CommandLine;

namespace DatabricksInvoker.CmdLineOptions;

[Verb("run", HelpText = "Run a databricks job.")]
public class RunOptions : Options
{
    [Option('u', "url", Required = true, HelpText = "url of Databricks instance.")]
    public string Url { get; set; }

    [Option('p', "payload", Required = false, HelpText = "Payload of request as JSON String")]
    public string? Payload { get; set; }

    [Option('j', "job-id", Required = false, HelpText = "The Job Id to run.")]
    public long? JobId { get; set; }

    [Option('n', "params", Required = false, HelpText = "The params as a JSON string")]
    public string? Params { get; set; }

    [Option('t', "param-type", Required = false, HelpText = "The type of params")]
    public string? ParamType { get; set; }
}