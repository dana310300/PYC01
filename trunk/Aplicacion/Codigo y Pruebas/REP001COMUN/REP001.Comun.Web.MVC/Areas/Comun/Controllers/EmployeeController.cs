using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using REP001.Comun.BO;
using REP001.Comun.BO.Context;
using REP001.Comun.Service.Implement;
using REP001.Comun.Helpers;
namespace REP001.Comun.Web.MVC.Areas.Comun.Controllers
{
    public class EmployeeController : Controller
    {
        private ComunContext db = new ComunContext();

        //
        // GET: /Comun/Employee/

        public ActionResult Index()
        {
            return View(db.Employee.ToList());
        }

        //
        // GET: /Comun/Employee/Details/5

        public ActionResult Details(long id = 0)
        {
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // GET: /Comun/Employee/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Comun/Employee/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
              
                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        //
        // GET: /Comun/Employee/Edit/5

        public ActionResult Edit(long id = 0)
        {
            EmployeeService employeeCtrl = new EmployeeService();
            Employee employee = employeeCtrl.RetrieveComplete(new Employee { EmployeeID = id });
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /Comun/Employee/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        //
        // GET: /Comun/Employee/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /Comun/Employee/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult PersonSearchPartial()
        {
            PersonService personCtrl = new PersonService();
            List<Person> ls = personCtrl.RetrievePersons();

            return PartialView("_PersonSearchPartial",ls);
        }

        [HttpPost]
        public ActionResult PersonSearchPartial(Person p)
        {
            //PersonService personCtrl = new PersonService();
            //List<Person> ls = personCtrl.RetrievePersons();

            return PartialView("_PersonSearchPartial");
        }

        public ActionResult GridViewEmployee(int? Page,string Sort) {

            int page = Page ?? 1;
            string sort = string.IsNullOrEmpty(Sort) ? "EmployeeID" :Sort;
           // long selected = selected != null ? (long)selected : 0;
            int count = 2;
            int resultcount;
            //long employeeId = EmployeeId.HasValue ? EmployeeId.Value : 0;
         

            EmployeeService employeeCtrl = new EmployeeService();
            List<Employee> ls = employeeCtrl.RetrieveEmployees(page, count, sort, false,out resultcount);

            ViewBag.NumberOfResults = resultcount;
            ViewBag.ItemsPerPage = count;
            ViewBag.CurrentPage = page;

            return View("GridViewEmployee",ls);
        }

      

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}