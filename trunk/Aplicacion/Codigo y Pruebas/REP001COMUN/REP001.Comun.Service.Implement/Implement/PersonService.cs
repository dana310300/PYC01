using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using REP001.Comun.BO;
using REP001.Comun.BO.Context;
using REP001.Comun.Service.Interface;
using System.Data.Entity;
using System.Data;


namespace REP001.Comun.Service.Implement
{
    public class PersonService:IPersonService
    {
        PersonContext db = new PersonContext();

        public Person Create(Person p)
        {
            db.Persons.Add(p);
            db.SaveChanges();
            Person person = db.Persons.Find(p);
            return person;
            //return new Person { ID = 1, Name = "Daniela", DateBird = DateTime.Parse(string.Format("{0:MM/dd/yyyy}", "03/31/1985")) };
        }

        public void Delete(Person p)
        {
            if (p != null) {
                Person person = null;
                person = db.Persons.FirstOrDefault(x=>x.ID==p.ID);
                if (person != null) {
                    db.Persons.Remove(person);
                    db.SaveChanges();
                }
            }
        }

        public Person Retrieve(Person p)
        {
           Person person= db.Persons.Find(p);
           return person;
        }

        public List<Person> RetrievePersons()
        {
            List<Person> lspersons = db.Persons.ToList();
         
            return lspersons;
        }

        public virtual void Dispose()
        {
            db.Dispose(); 
            //base.Dispose(disposing);
        }


        public void Edit(Person p)
        {
            if (p != null && p.ID != null) {
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
