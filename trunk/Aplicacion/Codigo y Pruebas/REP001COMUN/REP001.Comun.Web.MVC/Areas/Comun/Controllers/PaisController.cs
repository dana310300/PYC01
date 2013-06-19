using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using REP001.Comun.BO;
using REP001.Comun.BO.Context;
using REP001.Comun.Service.Interface;
using REP001.Comun.Service.Implement;


namespace REP001.Comun.Web.MVC.Areas.Comun.Controllers
{
    public class PaisController : Controller
    {
        private PaisService paisCtrl = new PaisService();
        //private ComunContext db = new ComunContext();

        //
        // GET: /Comun/Pais/

        public ActionResult Index()
        {
            return View(paisCtrl.RetrievePaises());
        }

        //
        // GET: /Comun/Pais/Details/5

        public ActionResult Details(int id =0)
        {
            Pais pais = paisCtrl.Retrieve(new Pais{ID=id});

            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }


        //
        // GET: /Comun/Pais/Create

        public ActionResult Create()
        {
            ViewBag.isError = false;
            ViewBag.errorMsg = "";
            return View();
        }

        //
        // POST: /Comun/Pais/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Pais pais)
        {
            if (ModelState.IsValid)
            {
                try 
                {
                    ViewBag.isError = false;
                    ViewBag.errorMsg = "";

                    paisCtrl.Create(pais);
                    return RedirectToAction("Index");
                }
                catch(Exception ex) 
                {
                    ViewBag.errorMsg = ex.Message;
                    ViewBag.isError = true;
                    return View(pais);
                }
               
            }

            return View(pais);
        }

        //
        // GET: /Comun/Pais/Edit/5
        public ActionResult Edit(int id =0)
        {
            Pais pais = paisCtrl.Retrieve(new Pais{ID=id});
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        //
        // POST: /Comun/Pais/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Pais pais)
        {
            if (ModelState.IsValid)
            {
                paisCtrl.Edit(pais);
                return RedirectToAction("Index");
            }
            return View(pais);
        }

        //
        // GET: /Comun/Pais/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Pais pais = paisCtrl.Retrieve(new Pais{ID=id});
            if (pais == null)
            {
                return HttpNotFound();
            }
            return View(pais);
        }

        //
        // POST: /Comun/Pais/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pais pais = paisCtrl.Retrieve(new Pais { ID = id });
            paisCtrl.Delete(pais);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if ( disposing ) {
                paisCtrl.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}