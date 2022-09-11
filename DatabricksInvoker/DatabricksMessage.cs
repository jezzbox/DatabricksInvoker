using System.Collections.Specialized;
using System.Web;

namespace DatabricksInvoker;

public class DatabricksMessage
{
    // public RunRequest(long jobId, int clientId, string date, string baseUri)
    // {
    //     JobId = jobId;
    //     ClientId = clientId;
    //     Date = date;
    //     BaseUri = new Uri(baseUri + "/api/2.1/");
    // }
    private Uri BaseUri {get;}
    private string Operation { get;}
    private string JsonPayload { get; }
    
    // private long JobId { get;}
    // private int ClientId { get; }
    // private string Date { get; }
    // private Uri BaseUri {get;}

    public string GetEndpoint(string endpoint, NameValueCollection queryParameters)
    {
        Uri requestUri = new Uri(BaseUri, endpoint);
        UriBuilder requestUriBuilder = new UriBuilder(requestUri);
        requestUriBuilder.Query = queryParameters.ToString();

        return requestUriBuilder.ToString();
    }
    
}