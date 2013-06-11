using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using REP001.Comun.BO;
using REP001.Comun.BO.Context;
using REP001.Comun.Service.Interface;
using REP001.Comun.Service.Implement;


namespace REP001.Comun.Web.MVC.Controllers
{
    public class PersonController : Controller
    {
        private ComunContext db = new ComunContext();
        private PersonService personCtrl = new PersonService();
        //
        // GET: /Person/

        public ActionResult Index()
        {
            return View(db.Person.ToList());
        }

        //
        // GET: /Person/Details/5

        public ActionResult Details(long id = 0)
        {
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // GET: /Person/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Person/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Person person)
        {

            if (ModelState.IsValid)
            {
                personCtrl.Create(person);
                //db.Person.Add(person);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(person);
        }

        //
        // GET: /Person/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // POST: /Person/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Person person)
        {
            if (ModelState.IsValid)
            {
                db.Entry(person).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(person);
        }

        //
        // GET: /Person/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Person person = db.Person.Find(id);
            if (person == null)
            {
                return HttpNotFound();
            }
            return View(person);
        }

        //
        // POST: /Person/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id=0)
        {
            Person person = db.Person.Find(id);
            db.Person.Remove(person);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> PersonInfoPhoto() {

            List<Task> tasks = new List<Task>();

            using (WebClient webClient = new WebClient()) {
                Uri uri1 = new Uri(PersonImgServiceUrl);
                tasks.Add(webClient.DownloadDataTaskAsync(uri1));
            }
            await Task.WhenAll(tasks);

            string imageBase64 = Convert.ToBase64String(((Task<byte[]>)tasks[0]).Result);
            string imageSrc = string.Format("data:image/jpeg;base64,{0}", imageBase64);
            ViewBag.Photo = imageSrc;

            return View("PersonInfo");
        }

        private string PersonImgServiceUrl
        {
            get
            {
                return string.Concat(getRootUrl(),Url.Content("~/Content/Images/flower01.jpg"));
            }
        }

        private string getRootUrl()
        {
            string scheme = Request.Url.GetComponents(UriComponents.Scheme, UriFormat.SafeUnescaped);
            string rootURL = Request.Url.GetComponents(UriComponents.HostAndPort, UriFormat.SafeUnescaped);
            return string.Concat(scheme, "://", rootURL, "/");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

      
    }
}