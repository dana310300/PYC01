using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Web.Mvc;
using REP001.Comun.WebAPI.MVC.Models;
using REP001.Comun.WebAPI.MVC.Models.REP001.Comun.WebAPI.MVC;

namespace REP001.Comun.WebAPI.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeContext db = new EmployeeContext();
        private List<Person> _people = new List<Person>();

        //
        // GET: /Employee/

        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        //
        // GET: /Employee/Details/5

        public ActionResult Details(int id = 0)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // GET: /Employee/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Employee/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        //
        // GET: /Employee/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Employee employee = db.Employees.FirstOrDefault(x=>x.ID==id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /Employee/Edit/5

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
        // GET: /Employee/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /Employee/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }


        #region Person Views

        //
        // GET: /Employee/

        public ActionResult Person()
        {
            _people = new List<Person>();
            _people.AddRange(new Person[]{
            new Person{ID=1,Name="Daniela",LastName="Avila",DateBird=DateTime.Today.AddDays(-27)},
            new Person{ID=2,Name="Angelina",LastName="Avila",DateBird=DateTime.Today.AddDays(-29)},
            new Person{ID=3,Name="Angelina",LastName="Avila",DateBird=DateTime.Today.AddDays(-21)}});

            return View(_people.ToList());
        }

        #endregion

        #region Imagen

        public async Task<ActionResult> Imagen()
        {
            List<Task> tasks = new List<Task>();

            using (WebClient webClient = new WebClient())
            {
                Uri uri1 = new Uri(PhotoCommentServiceURL);
                tasks.Add(webClient.DownloadStringTaskAsync(uri1));
            }

            using (WebClient webClient = new WebClient())
            {
                Uri uri2 = new Uri(DynamicImgServiceUrl);
                tasks.Add(webClient.DownloadDataTaskAsync(uri2));
            }
            await Task.WhenAll(tasks);

            ViewBag.PhotoComments = ((Task<string>)tasks[0]).Result;
            string imageBase64 = Convert.ToBase64String(((Task<byte[]>)tasks[1]).Result);
            string imageSrc = string.Format("data:image/jpeg;base64,{0}", imageBase64);
            ViewBag.Photo = imageSrc;

            return View();
        }

        private string PhotoCommentServiceURL
        {
            get
            {
                return string.Concat(getRootUrl(),
                Url.Content("~/Content/PhotoComments.txt"));
            }
        }

        private string DynamicImgServiceUrl
        {
            get
            {
                return string.Concat(getRootUrl(),
                    Url.Content("~/Content/SomePicture.jpg"));
            }
        }

        private string getRootUrl()
        {
            string scheme = Request.Url.GetComponents(UriComponents.Scheme, UriFormat.SafeUnescaped);
            string rootURL = Request.Url.GetComponents(UriComponents.HostAndPort, UriFormat.SafeUnescaped);
            return string.Concat(scheme, "://", rootURL, "/");
        }


    
        #endregion
    }
}