using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace DatabricksInvoker
{
    public abstract class JSONSchema
    {
        public virtual string ToJSONString()
        {
            return JsonSerializer.Serialize(this);
        }

    }
}
