using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using REP001.Comun.WebAPI.MVC.Models;

namespace REP001.Comun.WebAPI.MVC.Controllers
{
    public class PersonController : ApiController
    {
        List<Person> _people;
        public PersonController() {
            _people = new List<Person>();
            _people.AddRange(new Person[]{
            new Person{ID=1,Name="Daniela",LastName="Avila",DateBird=DateTime.Today.AddDays(-27)},
            new Person{ID=2,Name="Angelina",LastName="Avila",DateBird=DateTime.Today.AddDays(-29)},
            new Person{ID=3,Name="Angelina",LastName="Avila",DateBird=DateTime.Today.AddDays(-21)}

            });
        }

        
       

        // GET api/person
        public IEnumerable<Person> Get()
        {
            return _people;
        }

        //// GET api/person/5
        //public Person Get(int id)
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

        public HttpResponseMessage<Person> Get(int id) { 
        var person = _people.FirstOrDefault(x=>x.ID==id);

        return new HttpResponseMessage<Person>(person,HttpStatusCode.OK);
        
        }
       
    }
}
