using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Newtonsoft.Json;
using WebApp.Models;
using WepApp.Models.ViewModels;

namespace WebApp.Controllers
{
	[Authorize]
	public class RestrictedAreaController : Controller
	{
		[Authorize(Roles = "Page1")]
		// GET: RestrictedArea/Page_1
		public ActionResult Page1()
		{
			return View();
		}

		[Authorize(Roles = "Page2")]
		// GET: RestrictedArea/Page_2
		public ActionResult Page2()
		{
			return View();
		}

		[Authorize(Roles = "Page3")]
		// GET: RestrictedArea/Page_3
		public ActionResult Page3()
		{
			return View();
		}
		
	}
}