using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace WebApp
{
    public class BaseClient
    {
        private string _baseUrl;
        private HttpClient _client;

        protected HttpClient Client { get; }

        public BaseClient(string baseUrl)
        {
            _client = new HttpClient();
            _baseUrl = baseUrl;
            _client.BaseAddress = new Uri("http://localhost:51849/");
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}