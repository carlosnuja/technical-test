using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApp.Controllers
{
    public class RestrictedAreaController : Controller
    {
        // GET: RestrictedArea/Page_1
        public ActionResult Page_1()
        {
            return View();
        }

        // GET: RestrictedArea/Page_2
        public ActionResult Page_2()
        {
            return View();
        }

        // GET: RestrictedArea/Page_3
        public ActionResult Page_3()
        {
            return View();
        }
       
    }
}
