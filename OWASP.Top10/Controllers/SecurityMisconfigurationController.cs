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
    public class SecurityMisconfigurationController : BaseController
    {
        // GET: SecurityMisconfiguration
        public ActionResult GetDetails(int id)
        {
            if (id <= 0)
            {
                throw new Exception("requested customer id is not valid!.");
            }

            var dt = DbHelper.ExecuteSelectCommand($"select customer_id, first_name, last_name, email from customer where customer_id = {id};");
            var customer = new CustomerViewModel
            {
                CustomerId = dt.Rows[0]["customer_id"].ToString(),
                FirstName = dt.Rows[0]["first_name"].ToString(),
                LastName = dt.Rows[0]["last_name"].ToString(),
                Email = dt.Rows[0]["email"].ToString(),
            };
            return View(customer);
        }

        public ActionResult Index()
        {
            var dt = DbHelper.ExecuteSelectCommand("select customer_id, first_name, last_name, email from customer limit 10;");
            var customers = new List<CustomerViewModel>();

            foreach (DataRow row in dt.Rows)
            {
                customers.Add(new CustomerViewModel
                {
                    CustomerId = row["customer_id"].ToString(),
                    FirstName = row["first_name"].ToString(),
                    LastName = row["last_name"].ToString(),
                    Email = row["email"].ToString(),
                });
            }
            return View(customers);
        }

        public ActionResult Edit(int id)
        {
            var dt = DbHelper.ExecuteSelectCommand($"select customer_id,first_name, last_name, email from customer where customer_id = {id};");
            var customer = new CustomerViewModel
            {
                CustomerId = dt.Rows[0]["customer_id"].ToString(),
                FirstName = dt.Rows[0]["first_name"].ToString(),
                LastName = dt.Rows[0]["last_name"].ToString(),
                Email = dt.Rows[0]["email"].ToString(),
            };
            return View(customer);
        }
    }
}