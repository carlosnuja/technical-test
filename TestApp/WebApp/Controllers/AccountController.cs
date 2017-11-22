using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.WebPages;
using Newtonsoft.Json;
using WebApp.ApiClient;
using WebApp.Models;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
	[AllowAnonymous]
	public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View(new LoginViewModel());
        }

		[HttpPost]
	    public ActionResult Login(LoginViewModel model, string returnUrl = "")
	    {
		    if (ModelState.IsValid)
		    {
				UserClient client = new UserClient();
			    string authInfo = model.Username + ":" + model.Password;
			    client.AddAuthoritationHeaders(model.Username, model.Password);
			    User user = client.GetUserInfoAsync().Result;
			    if (user != null)
			    {
					string userData = JsonConvert.SerializeObject(user);
					FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
						1,
						user.UserName,
						DateTime.Now,
						DateTime.Now.AddMinutes(15),
						false, //pass here true, if you want to implement remember me functionality
						userData);
				    string encTicket = FormsAuthentication.Encrypt(authTicket);
				    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
				    Response.Cookies.Add(faCookie);
				    if (!returnUrl.IsEmpty() && this.Url.IsLocalUrl(returnUrl))
					    return Redirect(returnUrl);
					return RedirectToAction("Index", "Home");
			    }
		    }
		    return View(model);
		}

	    public ActionResult Logout()
	    {
		    FormsAuthentication.SignOut();
		    return RedirectToAction("Index", "Home");
	    }
	}
}