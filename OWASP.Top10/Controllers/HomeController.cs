using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OWASP.Top10.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            HttpCookie cookie = new HttpCookie("OWASP.TOP.10");
            cookie["ApplicationName"] = "Cyber Security Training";
            cookie["HostedBy"] = "Security CEG";
            Response.Cookies.Add(cookie);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}