using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DatabricksInvoker.Models.Jobs.HttpMessages
{
    public class DbtOutput
    {
        DbtOutput(string artifactsLink, Dictionary<string, string> artifactsHeaders)
        {
            ArtifactsLink = artifactsLink;
            ArtifactsHeaders = artifactsHeaders;
        }

        [JsonPropertyName("artifacts_link")]
        public string ArtifactsLink { get; }
        [JsonPropertyName("artifacts_headers")]
        public Dictionary<string, string> ArtifactsHeaders { get; } = new();
    }
}
