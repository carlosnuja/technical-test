using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace WebApp
{
    public class BaseClient
    {
        private HttpClient _client;

        protected HttpClient Client { get { return _client; } }

        public BaseClient()
        {
	        _client = new HttpClient {BaseAddress = new Uri("http://localhost:51849/")};
	        _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

	    public void AddAuthoritationHeaders(string user, string password)
	    {
		    string authInfo = user + ":" + password;
		    authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
		    _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authInfo);
		}
    }
}