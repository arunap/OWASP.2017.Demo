using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OWASP.Top10.Controllers
{
    public class BrokenAccessControlController : Controller
    {
        // GET: BrokenAccessControl
        public ActionResult Index()
        {
            return View();
        }
    }
}