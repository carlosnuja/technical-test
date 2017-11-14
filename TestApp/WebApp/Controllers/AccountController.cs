using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models.ViewModels;

namespace WebApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
	    public ActionResult Login(LoginViewModel model)
	    {
		    if (!ModelState.IsValid)
		    {
			    return View(model);
		    }
	    }
    }
}