using System.Text;
using Microsoft.AspNetCore.Http.Extensions;
using DatabricksInvoker.Models.Common;
using System.Net.Http.Headers;
using DatabricksInvoker.Models.Jobs;
using DatabricksInvoker.Models.Jobs.HttpMessages;

namespace DatabricksInvoker.Http
{
    public class DatabricksClient : HttpClient
    {
        public DatabricksClient(Uri? baseUri, string? bearerToken = null)
        {
            BaseUri = baseUri ?? throw new ArgumentNullException(nameof(baseUri));   
            DefaultRequestHeaders.Accept.Clear();
            DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            if (bearerToken != null)
            {
                DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", bearerToken);
            }
            JobsAPI = new(this);
        }

        public Uri BaseUri { get;}

        public JobsAPI JobsAPI { get; set; }

        public static string GetQueryString(List<KeyValuePair<string, string>>? queryParams)
        {
            if (queryParams != null)
            {
                var query = new QueryBuilder(queryParams);
                return query.ToQueryString().ToString();
            }
            else
            {
                return "";
            }

        }
        public Uri BuildUrl(string? path, List<KeyValuePair<string, string>>? queryParams)
        {
            string queryString = GetQueryString(queryParams);

            var endpoint = new Uri(BaseUri, path ?? "");
            var endpointWithParams = new Uri(endpoint, queryString);
            return endpointWithParams;
        }

        public async Task<R> Get<R>(string path = "", List<KeyValuePair<string, string>>? queryParams = null)
        {
            var endpoint = BuildUrl(path, queryParams);


            HttpResponseMessage responseMessage = await GetAsync(endpoint);
            responseMessage.EnsureSuccessStatusCode();
            string responseBody = await responseMessage.Content.ReadAsStringAsync();

            var responseObject = responseBody.ToObject<R>(); 
            return responseObject!;
        }

        public async Task<R> Post<P, R>(string path = "",
            List<KeyValuePair<string, string>>? queryParams = null,
            P? payload = default,  
            string? contentType = "application/json")
        {
            var endpoint = BuildUrl(path, queryParams);

            StringContent? stringContent = null;

            if (payload != null)
            {
                string json = payload.ToJsonString();

                stringContent = new StringContent(
                    json!, Encoding.UTF8, contentType
                    );
            }

            HttpResponseMessage responseMessage = await PostAsync(endpoint, stringContent);
            responseMessage.EnsureSuccessStatusCode();

            string responseBody = await responseMessage.Content.ReadAsStringAsync();

            var responseObject = responseBody.ToObject<R>();
            return responseObject!;
        }
    }


}
