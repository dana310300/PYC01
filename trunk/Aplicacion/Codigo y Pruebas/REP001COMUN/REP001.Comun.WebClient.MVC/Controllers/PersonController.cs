using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using REP001.Comun.WebClient.MVC.PersonWebServiceReference;

namespace REP001.Comun.WebClient.MVC.Controllers
{
    public class PersonController : ApiController
    {
        public async Task<List<PersonInfo>> Get() 
        {

            List<Task<PersonInfo[]>> dataTask = new List<Task<PersonInfo[]>>();
            await Task.Delay(5000);

            for (int i = 0; i < 2; i++)
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
                    inf.Add(item);
                }
            }

            return inf;
        }
    }
}
