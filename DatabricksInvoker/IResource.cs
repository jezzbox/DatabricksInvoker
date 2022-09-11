using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabricksInvoker
{
    internal interface IResource<C, U, R>
    {
        Task<R> SendRequest(C client, U baseUri);

    }
}
