using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WebApp.Models;

namespace WebApp.ApiClient
{
    public class UserClient : BaseClient
    {
        public UserClient(string baseUrl) : base(baseUrl)
        {            
        }

        public async Task<User> GetUserInfoAsync(int userId)
        {
            User user = null;
            string path = $"{userId}/user/info";
            HttpResponseMessage response = await Client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                user = await response.Content.ReadAsAsync<User>();
            }
            return user;
        }


    }
}