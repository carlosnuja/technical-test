﻿using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Newtonsoft.Json;
using WebApp.Models;

namespace WebApp
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}


		protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
		{
			HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
			if (authCookie != null)
			{
				FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
				User model = JsonConvert.DeserializeObject<User>(authTicket.UserData);
				CustomPrincipal newUser = new CustomPrincipal(model);
				HttpContext.Current.User = newUser;
			}

		}
	}
}
