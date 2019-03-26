using OWASP.Top10.Helpers;
using OWASP.Top10.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace OWASP.Top10.Controllers
{
    public class SensitiveDataExposureController : Controller
    {
        // GET: SensitiveDataExposure
        public ActionResult Index()
        {
            DataTable dt = DbHelper.ExecuteSelectCommand(" SELECT category_id, name FROM category limit 10 ");
            var list = new List<SelectListItem>();

            foreach (DataRow dataRow in dt.Rows)
            {
                list.Add(new SelectListItem
                {
                    Value = dataRow["category_id"].ToString(),
                    Text = dataRow["name"].ToString(),
                });
            }
            ViewBag.FilmList = list;

            return View();
        }

        [HttpGet]
        public JsonResult GetFilmDetails(int id)
        {
            var dt = DbHelper.ExecuteSelectCommand(string.Format("SELECT f.film_id, f.title, f.description, f.rental_rate, f.rating, c.name  " +
                "FROM film f " +
                "INNER JOIN film_category fc ON fc.film_id = f.film_id "+
                "INNER JOIN category c on c.category_Id = fc.category_id " +
                "WHERE fc.category_id = {0} ;", id));
            var list = new List<FilmViewModel>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new FilmViewModel
                {
                    FilmId = row["film_id"].ToString(),
                    Title = row["title"].ToString(),
                    Description = row["description"].ToString(),
                    Rental = (decimal)row["rental_rate"],
                    Rating = row["rating"].ToString(),
                    CategoryName = row["name"].ToString()
                });
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}