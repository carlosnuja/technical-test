using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace WebApp.ApiClient
{
    public interface ILoginClient
    {
        Task<TokenResponse> Login(string email, string password);
    }

}