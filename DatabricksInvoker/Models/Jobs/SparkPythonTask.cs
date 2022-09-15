using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabricksInvoker.Models.Jobs
{
    public class SparkPythonTask
    {
        public SparkPythonTask(string pythonFile, List<string> parameters)
        {
            PythonFile = pythonFile;
            Parameters = parameters;
        }

        [JsonProperty("python_file")]
        public string PythonFile { get; set; }
        [JsonProperty("parameters")]
        public List<string> Parameters { get; set; }
    }
}
