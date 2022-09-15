using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DatabricksInvoker.Models.Jobs.HttpMessages
{
    public class SqlOutput
    {
        public SqlOutput(QueryOutput queryOutput, KeyValuePair<string, Widgets> dashboardOutput, QueryOutput alertOutput)
        {
            QueryOutput = queryOutput;
            DashboardOutput = dashboardOutput;
            AlertOutput = alertOutput;
        }

        [JsonPropertyName("query_output")]
        public QueryOutput? QueryOutput { get; }
        [JsonPropertyName("dashboard_output")]
        public KeyValuePair<string, Widgets>? DashboardOutput { get; }
        [JsonPropertyName("alert_output")]
        public QueryOutput? AlertOutput { get; }
    }
}
