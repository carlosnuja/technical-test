using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApp.Clients
{
    public interface IApiClient
    {        
        Task<HttpResponseMessage> PostFormEncodedContent(string requestUri, params KeyValuePair<string, string>[] values);
    }
}
