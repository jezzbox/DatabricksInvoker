using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabricksInvoker.Models.Jobs
{
    public class SqlTask
    {
        [JsonConstructor]
        public SqlTask(KeyValuePair<string, string> query, 
            KeyValuePair<string, string> dashboard, 
            KeyValuePair<string, string> alert, 
            List<string> parameters, 
            string warehouseId)
        {
            Query = query;
            Dashboard = dashboard;
            Alert = alert;
            Parameters = parameters;
            WarehouseId = warehouseId;
        }

        [JsonProperty("query")]

        public KeyValuePair<string, string> Query { get; set; }

        [JsonProperty("dashboard")]

        public KeyValuePair<string, string> Dashboard { get; set; }

        [JsonProperty("alert")]

        public KeyValuePair<string, string> Alert { get; set; }


        [JsonProperty("parameters")]
        public List<string> Parameters { get; set; }

        [JsonProperty("warehouse_id")]
        public string WarehouseId { get; set; }
    }
}
