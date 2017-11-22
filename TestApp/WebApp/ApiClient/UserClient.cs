using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.ApiClient
{
    public class UserClient : BaseClient
    {
        public UserClient() : base()
        {            
        }

        public object ResponseHeadersRead { get; private set; }

        public async Task<User> GetUserInfoAsync()
        {
            User user = null;
            string path = $"/api/users";
            HttpResponseMessage response = await Client.GetAsync(path, HttpCompletionOption.ResponseHeadersRead).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<User>();
            }
            return user;
        }

    }
}