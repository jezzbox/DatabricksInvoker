using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabricksInvoker.Models.Jobs
{
    internal interface IRunSettings
    {
        long RunId { get; set; }
        RunState State { get; set; }

        string RunPageUrl { get; set; }
        long StartTime { get; set; }
        long SetupDuration { get; set; }
        long ExecutionDuration { get; set; }
        long CleanupDuration { get; set; }
        long EndTime { get; set; }
        int AttemptNumber { get; set; }
        Dictionary<string, string>? ClusterInstance { get; set; }
    }
}
