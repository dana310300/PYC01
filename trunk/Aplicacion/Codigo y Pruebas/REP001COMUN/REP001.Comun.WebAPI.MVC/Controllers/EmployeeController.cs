using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Web.Mvc;
using REP001.Comun.BO.Context;
using REP001.Comun.Service.Interface;
using REP001.Comun.Service.Implement;
using REP001.Comun.BO;

namespace REP001.Comun.WebAPI.MVC.Controllers
{
    public class EmployeeController : Controller
    {
        private ComunContext db = new ComunContext();
        private List<Person> _people;
        //
        // GET: /Comun/Employee/

        public ActionResult Index()
        {
            return View(db.Employee.ToList());
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