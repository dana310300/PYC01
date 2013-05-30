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
        ComunContext db = new ComunContext();

        public Person Create(Person p)
        {
            db.Person.Add(p);
            db.SaveChanges();
            Person person = db.Person.Find(p);
            return person;
            //return new Person { ID = 1, Name = "Daniela", DateBird = DateTime.Parse(string.Format("{0:MM/dd/yyyy}", "03/31/1985")) };
        }

        public void Delete(Person p)
        {
            if (p != null)
            {
                Person person = null;
                person = db.Person.FirstOrDefault(x => x.ID == p.ID);
                if (person != null)
                {
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

        public virtual void Dispose()
        {
            db.Dispose();
            //base.Dispose(disposing);
        }


        public void Edit(Person p)
        {
            if (p != null && p.ID != null)
            {
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
            }
        }


        public List<Person> RetrievePersonsByName(string name)
        {
            List<Person> lspersons = db.Person.Where(x => x.Name.Contains(name)).ToList();
            return lspersons;
        }
    }
}
