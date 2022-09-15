using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DatabricksInvoker.Models.Jobs.HttpMessages
{
    public class NotebookOutput
    {
        [JsonPropertyName("result")]
        public string? Result { get; }
        [JsonPropertyName("truncated")]
        public bool? Truncated { get; }
    }
}
