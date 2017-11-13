using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp.Clients
{
    public class ClientAPI : IClientAPI
    {
        private readonly HttpClient httpClient;
        private const string BaseUri = "Http://localhost:28601/";

        public ClientAPI(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<HttpResponseMessage> PostJsonEncodedContent<T>(string requestUri, T content) where T : ApiModel
        {
            httpClient.BaseAddress = new Uri(BaseUri);
            httpClient.DefaultRequestHeaders.Accept.Clear1();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = await httpClient.PostAsJsonAsync(requestUri, content);
            return response;
        }
    }
}