using JqueryMVCRazor_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeWebMVVMJavaScript.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new ListEmployeesViewModel();
            model.Load();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult SaveEmployees(ListEmployeesViewModel e,string deletedItems)
        {
            try
            {
                var arrIdsDeleted = deletedItems.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                var newEmps = e.AllEmployees.Count(item => item.IdEmployee == 0);
                long[] delIds = null;
                if (arrIdsDeleted != null && arrIdsDeleted.Length > 0)
                {
                    arrIdsDeleted.Select(item => long.Parse(item)).ToArray();
                }
                e.Save(delIds);
                string msg = string.Format("all emp {0},new emps {1}, deleted {2}", e.AllEmployees.Count(), newEmps, arrIdsDeleted.Length);
                return Json(new { ok = true, emps = e.AllEmployees});
            }
            catch (Exception ex)
            {
                return Json(new { ok = false, message = ex.Message });
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "MVVM javascript to MVC binding";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Andrei Ignat";

            return View();
        }
    }
}