using OWASP.Top10.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OWASP.Top10.Controllers
{
    public class BrokenAuthenticationController : Controller
    {
        public ActionResult Login()
        {
            return View(new LoginViewModel
            {
                Username = "anishantha87@gmail.com",
                Password = "123456"
            });
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            FormsAuthentication.SetAuthCookie(username, false);

            HttpCookie userInfo = new HttpCookie("userInfo");
            //userInfo.Secure = true;
            //userInfo.HttpOnly = true;
            //userInfo.sa
            userInfo["UserName"] = username;
            userInfo["IsAdmin"] = "false";
            userInfo["Test"] = "1";
            userInfo.Expires.Add(new TimeSpan(1, 0, 0));
            Response.Cookies.Add(userInfo);

            return RedirectToAction("UserInformation");
        }

        [HttpGet]
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            this.ControllerContext.HttpContext.Response.Cookies.Clear();

            return RedirectToAction("Login");
        }

        [HttpGet]
        public ActionResult UserInformation()
        {
            var cookie = Request.Cookies["userInfo"];
            if (cookie != null)
            {
                bool.TryParse(cookie["IsAdmin"], out bool isAdmin);

                ViewBag.IsAdmin = isAdmin;
            }
            return View();
        }

    }
}