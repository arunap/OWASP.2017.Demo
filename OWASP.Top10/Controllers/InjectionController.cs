﻿using OWASP.Top10.Helpers;
using OWASP.Top10.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OWASP.Top10.Controllers
{
    public class InjectionController : BaseController
    {
        // GET: Injection
        public ActionResult Index()
        {
            var dt = DbHelper.ExecuteSelectCommand("select customer_id,first_Name, last_Name,email, last_update from customer order by first_name limit 20;");
            var list = new List<CustomerViewModel>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new CustomerViewModel
                {
                    FirstName = row["first_Name"].ToString(),
                    LastName = row["last_Name"].ToString(),
                    Email = row["email"].ToString()
                });
            }
            ViewBag.RowCount = list.Count();
            return View(list);
        }

        [HttpPost]
        public ActionResult Index(string searchQuery)
        {
            string query = $"select customer_id,first_Name, last_Name,email, last_update from customer where first_name like '%{searchQuery}%';";
            var dt = DbHelper.ExecuteSelectCommand(query);
            var list = new List<CustomerViewModel>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new CustomerViewModel
                {
                    FirstName = row["first_Name"].ToString(),
                    LastName = row["last_Name"].ToString(),
                    Email = row["email"].ToString()
                });
            }

            ViewBag.RowCount = list.Count();
            return View(list);
        }
    }
}