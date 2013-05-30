using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using REP001.Comun.WebAPI.MVC.Models;
using REP001.Comun.BO;
namespace REP001.Comun.WebAPI.MVC.Controllers
{
    public class PersonController : ApiController
    {
        List<REP001.Comun.BO.Person> _people;
        public PersonController() {
            _people = new List<REP001.Comun.BO.Person>();
            _people.AddRange(new REP001.Comun.BO.Person[]{
            new REP001.Comun.BO.Person{ID=1,Name="Daniela",LastName="Avila",DateBird=DateTime.Today.AddDays(-27)},
            new REP001.Comun.BO.Person{ID=2,Name="Angelina",LastName="Avila",DateBird=DateTime.Today.AddDays(-29)},
            new REP001.Comun.BO.Person{ID=3,Name="Angelina",LastName="Avila",DateBird=DateTime.Today.AddDays(-21)}

            });
        }
     
        //public IEnumerable<REP001.Comun.BO.Person> Get()
        //{
        //    return _people;
        //}

        // GET api/person/5
        //public REP001.Comun.BO.Person Get(int id)
        //{
        //    return _people.FirstOrDefault(x => x.ID == id);
        //}

        // POST api/person
        public void Post([FromBody]string value)
        {

        }

        // PUT api/person/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/person/5
        public void Delete(int id)
        {
        }

        //public HttpResponseMessage<REP001.Comun.BO.Person> Get(int id) { 
        //REP001.Comun.BO.Person person = _people.FirstOrDefault(x=>x.ID==id);

        //return new HttpResponseMessage<REP001.Comun.BO.Person>(person,HttpStatusCode.OK);
        
        //}


        //Get Async
        public async Task<List<REP001.Comun.BO.Person>> Get()
        {
            List<REP001.Comun.BO.Person> list = await REP001.Comun.BO.Personas.GetPersons();

            return list.ToList<REP001.Comun.BO.Person>();
        }
       
    }
}
