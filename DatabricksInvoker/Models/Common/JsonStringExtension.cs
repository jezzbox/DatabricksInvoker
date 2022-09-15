using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabricksInvoker.Models.Common
{
    public static class JsonStringExtension
    {
        public static T? ToObject<T>(this string? jsonString)
        {
            var jsonObject = JsonConvert.DeserializeObject<T>(jsonString ?? "");

            return jsonObject;
        }

        public static string ToJsonString(this object jsonObject)
        {
            DefaultContractResolver contractResolver = new()
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            };

            string json = JsonConvert.SerializeObject(jsonObject, new JsonSerializerSettings
            {
                ContractResolver = contractResolver,
                Formatting = Formatting.Indented
            });

            return json;
        }
    }
}
