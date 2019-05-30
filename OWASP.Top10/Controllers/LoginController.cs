using OWASP.Top10.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OWASP.Top10.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View();

            //HttpCookie cookie = new HttpCookie("CEG.Secutity.Identity");
            //cookie["ApplicationName"] = "Cyber Security Training";
            //cookie["HostedBy"] = "Security CEG";
            //cookie["User"]  = JsonConvert.SerializeObject(model);

            //Response.Cookies.Add(cookie);

            return RedirectToAction("Index", "Home");
        }
    }
}