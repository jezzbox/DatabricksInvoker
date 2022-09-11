using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DatabricksInvoker
{
    public static class Utils
    {
        public static string ToJSONString(object jsonObject)
        {
            return JsonSerializer.Serialize(jsonObject);
        }
    }
}
