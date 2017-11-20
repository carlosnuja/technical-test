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

        public async Task<User> GetUserInfoAsync()
        {
            User user = null;
            string path = $"/user/info";
            HttpResponseMessage response = await Client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<User>();
            }
            return user;
        }

    }
}