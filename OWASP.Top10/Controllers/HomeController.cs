using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OWASP.Top10.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            HttpCookie cookie = new HttpCookie("CEG.Secutity.Identity");
            cookie["ApplicationName"] = "Cyber Security Training";
            cookie["HostedBy"] = "Security CEG";
            cookie["User"] = JsonConvert.SerializeObject(new { FirstName = "Aruna", LastName = "Perera" });
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