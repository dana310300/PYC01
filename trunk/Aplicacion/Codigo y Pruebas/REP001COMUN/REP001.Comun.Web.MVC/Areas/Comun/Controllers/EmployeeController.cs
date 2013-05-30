using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using REP001.Comun.BO;
using REP001.Comun.BO.Context;

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
            Employee employee = db.Employee.Find(id);
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
            return PartialView("_PersonSearchPartial");
        }
       
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}