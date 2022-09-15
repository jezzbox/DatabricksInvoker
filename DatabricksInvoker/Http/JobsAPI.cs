using DatabricksInvoker.Models.Common;
using DatabricksInvoker.Models.Jobs;
using DatabricksInvoker.Models.Jobs.HttpMessages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabricksInvoker.Http
{
    public class JobsAPI
    {
        public JobsAPI(DatabricksClient client)
        {
            Client = client;
        }

        private const string jobsPath = "/api/2.1/jobs/";
        public DatabricksClient Client { get; set; }

        public async Task<Job> GetJob(long jobId)
        {
            const string path = jobsPath + "get";

            var queryParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("job_id", jobId.ToString()),
            };
            var response = await Client.Get<Job>(path, queryParams);
            return response;
        }

        public async Task<RunNowResponse> RunNow(RunNowPayload? payload)
        {
            const string path = jobsPath + "run-now";
            var response = await Client.Post<RunNowPayload, RunNowResponse>(path, payload: payload);
            return response;
        }

        public async Task<JobRun> AwaitRunResult(long runId, bool includeHistory = true, int sleepInterval = 60)
        {
            const string path = jobsPath + "runs/get";

            int delayTimeMs = sleepInterval * 1000;

            var queryParams = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("run_id", runId.ToString()),
                new KeyValuePair<string, string>("include_history", includeHistory.ToString().ToLower())

            };

            while (true)
            {
                JobRun jobRun = await Client.Get<JobRun>(path, queryParams);

                switch (jobRun.GetCurrentState())
                {
                    case "PENDING":
                    case "RUNNING":
                        {
                            Console.WriteLine(jobRun.State.ToJsonString());
                            await Task.Delay(delayTimeMs);
                            break;
                        }
                    case "TERMINATING":
                        {
                            await Task.Delay(60 * 1000);
                            break;
                        }
                    case "TERMINATED":
                        {
                            return jobRun;
                        }
                    case "SKIPPED":
                    case "INTERNAL_ERROR":
                        {
                            string errorMessage = await GetTaskErrors(jobRun);
                            throw new ArgumentException(errorMessage);
                        }
                    default:
                        {
                            throw new Exception("Unknown Life cycle state.");
                        }
                }

            }
        }

        public async Task<string> GetTaskErrors(JobRun jobRun)
        {
            const string path = jobsPath + "runs/get-output";

            string errorStart = string.Format(
                    "Error: ResultState = \"FAILED\". The Databricks run failed due to the following errors:\n\n"
                    );
            List<string> errorStrings = new()
            {
                errorStart
            };

            List<RunOutputResponse> failedTaskOutputs = new();

            foreach (var task in jobRun.Tasks.Where(t => t.State.ResultState == "FAILED"))
            {
                var queryParams = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("run_id", task.RunId.ToString()),
                };
                var runOutput = await Client.Get<RunOutputResponse>(path, queryParams);
                string? taskKey = runOutput.Metadata.TaskKey;
                string? error = runOutput.Error;
                string? errorTrace = runOutput.ErrorTrace;
                string errorString = string.Format(
                    "task_key: {0}\n  error:\n   {1}\n\n  error_trace:\n   {2}\n\n\n", taskKey, error, errorTrace
                    );
                errorStrings.Add(errorString);
            }
            return string.Join("", errorStrings);
        }
    }
}
