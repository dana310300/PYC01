using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using REP001.Comun.WebClient.MVC.PersonWebServiceReference;


namespace REP001.Comun.WebClient.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public async Task<ActionResult>  Contact()
        {
            ViewBag.Message = "Your contact page.";
            string Info = string.Empty;
            await Task.Delay(30000);
            Info = await GetName();
            ViewBag.PersonInfo = Info;
            return View();
        }

        public async Task<string> GetName() 
        {

            string name = string.Empty;
            List<Task<PersonInfo[]>> dataTask = new List<Task<PersonInfo[]>>();
            //await Task.Delay(10000);

            for (int i = 0; i < 3; i++)
            {
                using (PersonWebServiceClient client = new PersonWebServiceClient())
                {
                    dataTask.Add(client.DoSearchByNameAsync("da"));
                }
            }
            PersonInfo[][] persons = await Task.WhenAll(dataTask);
            List<PersonInfo> inf = new List<PersonInfo>();
            for (int i = 0; i < persons.Length; i++)
            {
                foreach (PersonInfo item in persons[i])
                {
                    name += item.Name;
                }
            }

            return name;
        }

        /*Permite consultar servicios con otro tipo de valor de retorno*/
        public async Task<List<PersonInfo>> GetPersonInfo() 
        {
            List<Task> dataTask = new List<Task>();       
            //await Task.Delay(10000);

            for (int i = 0; i < 3; i++)
            {
                using (PersonWebServiceClient client = new PersonWebServiceClient())
                {
                    dataTask.Add(client.DoSearchByNameAsync("da"));
                }
            }
            await Task.WhenAll(dataTask);
            int co = dataTask.Count;
            List<PersonInfo> inf = new List<PersonInfo>();
            for (int i = 0; i < co; i++)
            {
              PersonInfo p = ((Task<PersonInfo>)dataTask[i]).Result;

              inf.Add(p);
            }

            return inf;
        }
        
    }
}
