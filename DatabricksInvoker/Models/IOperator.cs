using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabricksInvoker.Models
{
    internal interface IOperator<C, R>
    {
        Task<R> SendRequest(C client);

    }
}
