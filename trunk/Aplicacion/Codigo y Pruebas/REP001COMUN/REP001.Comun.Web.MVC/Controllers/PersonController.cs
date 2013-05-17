using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using REP001.Comun.BO;
using REP001.Comun.BO.Context;

using REP001.Comun.Service.Implement;

namespace REP001.Comun.Web.MVC.Controllers
{
    public class PersonController : Controller
    {
       private PersonContext db = new PersonContext();
       private PersonService personService = new PersonService();

        //
        // GET: /Person/

        public ActionResult Index()
        {
            return View(personService.RetrievePersons());
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id = 0)
        {
            //Artist artist = db.Artists.Find(id);
            Person person = new Person { ID = id };
            person = personService.Retrieve(person);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(Person p)
        {
            if (ModelState.IsValid)
            {
               p=personService.Create(p);
               if (p != null) {
                   return RedirectToAction("Index");
               }
              
            }

            return View(p);
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // POST: /Home/Edit/5

        [HttpPost]
        public ActionResult Edit(Person p)
        {
            if (ModelState.IsValid)
            {
                personService.Edit(p);
                return RedirectToAction("Index");
            }
            return View(p);
        }

        //
        // GET: /Home/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Person person = db.Persons.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // POST: /Home/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Person person = db.Persons.Find(id);
            if (person != null)
            {
                personService.Delete(person);
                return RedirectToAction("Index");
            }
            else {
                return HttpNotFound();
            }
           
        }

       
    }
}
