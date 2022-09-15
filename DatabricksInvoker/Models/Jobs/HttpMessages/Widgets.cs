using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DatabricksInvoker.Models.Jobs.HttpMessages
{
    public class Widgets
    {
        public Widgets(string widgetId, string widgetTitle, string outputLink, string status, Dictionary<string, string> error, long startTime, long endTime)
        {
            WidgetId = widgetId;
            WidgetTitle = widgetTitle;
            OutputLink = outputLink;
            Status = status;
            Error = error;
            StartTime = startTime;
            EndTime = endTime;
        }

        [JsonPropertyName("widget_id")]
        public string WidgetId { get; }

        [JsonPropertyName("widget_title")]
        public string WidgetTitle { get; }

        [JsonPropertyName("output_link")]
        public string OutputLink { get; }

        [JsonPropertyName("status")]
        public string Status { get; }

        [JsonPropertyName("error")]
        public Dictionary<string, string> Error { get; }

        [JsonPropertyName("start_time")]
        public long StartTime { get; }

        [JsonPropertyName("end_time")]
        public long EndTime { get; }

    }
}
