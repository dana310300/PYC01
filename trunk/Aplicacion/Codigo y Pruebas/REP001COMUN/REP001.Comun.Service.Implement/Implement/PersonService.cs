using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using REP001.Comun.BO;
using REP001.Comun.BO.Context;
using REP001.Comun.Service.Interface;
using System.Data.Entity;
using System.Data;
using System.Data.Entity.Validation;
using System.ComponentModel.DataAnnotations;

namespace REP001.Comun.Service.Implement
{
    public class PersonService : IPersonService
    {
        ComunContext db = new ComunContext();

        public Person Create(Person p)
        {
            db.Person.Add(p);
            db.SaveChanges();
            string str = ValidatePersonProperty(p);
            if ( str.Length > 0 ) { throw new Exception(str); }

            return db.Person.FirstOrDefault(x => x.Name == p.Name && x.LastName == p.LastName && x.DateBird == p.DateBird && x.Email == p.Email);
            //return new Person { ID = 1, Name = "Daniela", DateBird = DateTime.Parse(string.Format("{0:MM/dd/yyyy}", "03/31/1985")) };
        }

        public void Delete(Person p)
        {
            if ( p != null ) {
                Person person = null;
                person = db.Person.FirstOrDefault(x => x.ID == p.ID);
                if ( person != null ) {
                    db.Person.Remove(person);
                    db.SaveChanges();
                }
            }
        }

        public Person Retrieve(Person p)
        {
            Person person = db.Person.Find(p);
            return person;
        }

        public List<Person> RetrievePersons()
        {
            List<Person> lspersons = db.Person.ToList();

            return lspersons;
        }


        public void Edit(Person p)
        {
            if ( p != null && p.ID != null ) {
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public List<Person> RetrievePersonsByName(string name)
        {
            List<Person> lspersons = db.Person.Where(x => x.Name.Contains(name)).ToList();
            return lspersons;
        }

        public Person RetrievePersonById(long ID)
        {

            Person person = db.Person.FirstOrDefault(p => p.ID == ID);
            return person;
        }

        public void Dispose()
        {
            db.Dispose();
        }

        private string ValidatePersonProperty(Person p)
        {
            ICollection<DbValidationError> results;
            string sError = string.Empty;
            using ( var context = new ComunContext() ) {
                results = context.Entry(p).Property(a => a.Name).GetValidationErrors();
            }
            foreach ( DbValidationError item in results ) {
                sError += item.PropertyName + " : " + item.ErrorMessage;
            }

            return sError;
        }

        private string ValidatePerson(Person p)
        {
            DbEntityValidationResult results;
            string sError = string.Empty;
            using ( ComunContext context = new ComunContext() ) {
                results = context.Entry(p).GetValidationResult();
            }

            foreach ( var error in results.ValidationErrors ) {
                sError += error.PropertyName + " : " + error.ErrorMessage;
            }

            return sError;

        }


    }
}
