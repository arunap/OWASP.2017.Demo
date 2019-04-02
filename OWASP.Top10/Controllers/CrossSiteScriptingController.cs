using OWASP.Top10.Helpers;
using OWASP.Top10.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OWASP.Top10.Controllers
{
    public class CrossSiteScriptingController : Controller
    {
        // GET: CrossSiteScripting
        public ActionResult Index()
        {
            var list = new List<CommentViewModel>();
            var dt = DbHelper.ExecuteSelectCommand("select * from comment");
            foreach (DataRow item in dt.Rows)
            {
                list.Add(new CommentViewModel { Comment = item["comment"].ToString() });
            }
            return View(list);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(string searchQuery = "")
        {
            if (!string.IsNullOrEmpty(searchQuery))
            {
                DbHelper.ExecuteInsertCommand("Insert into comment(comment) values ('" + searchQuery + "')");
            }

            var dt = DbHelper.ExecuteSelectCommand("select * from comment");
            var list = new List<CommentViewModel>();

            foreach (DataRow item in dt.Rows)
            {
                list.Add(new CommentViewModel { Comment = item["comment"].ToString() });
            }
            return View(list);
        }
    }
}