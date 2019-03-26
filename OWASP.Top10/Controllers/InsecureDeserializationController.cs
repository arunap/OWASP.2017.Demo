using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OWASP.Top10.Controllers
{
    public class InsecureDeserializationController : Controller
    {
        // GET: InsecureDeserialization
        public ActionResult Index()
        {
            return View();
        }
    }
}