using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabricksInvoker
{
    public abstract class Resource
    {
        public abstract string Path { get; }
        public abstract JSONSchema? Payload { get; }
        public abstract JSONSchema? Response { get; }

        public List<KeyValuePair<string, string>>? QueryParams { get; set; }

        public string GetQueryString()
        {
            if (QueryParams != null)
            {
                var query = new QueryBuilder(QueryParams);
                return query.ToQueryString().ToString();
            }
            else
            {
                return "";
            }

        }
        public Uri GetEndpoint(Uri baseUri)
        {
            string queryString = GetQueryString();

            var endpoint = new Uri(baseUri, Path);
            var endpointWithParams = new Uri(endpoint, queryString);
            Console.WriteLine(endpointWithParams);
            return endpointWithParams;
        }

    }
}
