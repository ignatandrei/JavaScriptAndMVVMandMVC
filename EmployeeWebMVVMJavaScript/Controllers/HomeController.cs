using JqueryMVCRazor_Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeWebMVVMJavaScript.Controllers
{
    public class Select2DataChildren
    {
        public long id { get; set; }
        public string text { get; set; }
    }
    public class Select2Data
    {
        public string text { get; set; }
        public Select2DataChildren[] children { get; set; }
    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new ListEmployeesViewModel();
            model.Load();
            return View(model);
        }

        public ActionResult Select2()
        {
            var l = new ListEmployeesViewModel();
            l.Load();
            var ret = new List<Select2Data>();
            foreach (var dep in l.DepartmentList)
            {
                var s = new Select2Data();
                s.text = dep.NameDepartment;
                s.children = l.AllEmployees
                    .Where(it => it.iddepartament == dep.IdDepartment)
                    .Select(it => new Select2DataChildren()
                    { id = it.IdEmployee, text = it.NameEmployee }
                    )
                    .ToArray();

                ret.Add(s);
            }
            return View(ret);
        }
        [HttpPost]
        public JsonResult GetEmpSelect2(string q, int? page)
        {
            q = (q ?? "").ToLower();
            var l = new ListEmployeesViewModel();
            l.Load();
            var items = l.AllEmployees
                .Where(it => it.NameEmployee.ToLower().Contains(q))
                .Select(it => new {id = it.IdEmployee, text = it.NameEmployee})
                //.Skip(((page??1)-1)*1)
                //.Take(1)
                .ToArray();
                return Json(new
            {
                items=items,
                total_count = 2,
                page=1
            });
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

        public ActionResult Graphs()
        {
            var model = new ListEmployeesViewModel();
            model.Load();
            return View(model);
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