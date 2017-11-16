using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.ApiClient.Helpers
{
    public interface ITokenContainer
    {
        object ApiToken { get; set; }
    }
}