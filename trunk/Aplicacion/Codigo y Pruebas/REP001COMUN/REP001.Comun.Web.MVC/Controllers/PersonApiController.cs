using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using REP001.Comun.BO;
using REP001.Comun.Service;
using REP001.Comun.Service.Implement;

namespace REP001.Comun.Web.MVC.Controllers
{
    public class PersonApiController : ApiController
    {
        private List<Person> _people;
        private PersonService _peopleCtrl;

        public PersonApiController() {
            _people = new List<Person>();
            _peopleCtrl = new PersonService();

            //_people.AddRange(new REP001.Comun.BO.Person[]{
            //new REP001.Comun.BO.Person{ID=1,Name="Daniela",LastName="Avila",DateBird=DateTime.Today.AddDays(-27)},
            //new REP001.Comun.BO.Person{ID=2,Name="Angelina",LastName="Avila",DateBird=DateTime.Today.AddDays(-29)},
            //new REP001.Comun.BO.Person{ID=3,Name="Angelina",LastName="Avila",DateBird=DateTime.Today.AddDays(-21)}

            //});
        }
     

        public IEnumerable<Person> Get()
        {
            _people = _peopleCtrl.RetrievePersons();
            return _people;
        }

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
            _peopleCtrl.Delete(new Person{ID=id});
        }

      


        ////Get Async
        //public async Task<List<Person>> Get()
        //{
        //    List<Person> list = await Personas.GetPersons();

        //    return list.ToList<Person>();
        //}
    }
}
