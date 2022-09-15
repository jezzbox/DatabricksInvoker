using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DatabricksInvoker.Models.Jobs.HttpMessages
{
    public class QueryOutput
    {
        public QueryOutput(string queryText, string warehouseId, Dictionary<string, string> sqlStatements, string outputLink)
        {
            QueryText = queryText;
            WarehouseId = warehouseId;
            SqlStatements = sqlStatements;
            OutputLink = outputLink;
        }

        [JsonPropertyName("query_text")]
        public string QueryText { get; }
        [JsonPropertyName("warehouse_id")]
        public string WarehouseId { get; }
        [JsonPropertyName("sql_statements")]
        public Dictionary<string, string> SqlStatements { get; }
        [JsonPropertyName("output_link")]
        public string OutputLink { get; }
    }
}
