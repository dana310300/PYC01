using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using REP001.Comun.BO;
using REP001.Comun.Service.Interface;
namespace REP001.Comun.Service.Implement
{
    public class PersonService:IPersonService
    {
        public Person Create(Person p)
        {
            return new Person { ID = 1, Name = "Daniela", DateBird = DateTime.Parse(string.Format("{0:MM/dd/yyyy}", "03/31/1985")) };
        }

        public void Delete(Person p)
        {
           
        }

        public Person Retrieve(Person p)
        {
            return new Person { ID = 1, Name = "Daniela", DateBird = DateTime.Parse(string.Format("{0:MM/dd/yyyy}", "03/31/1985")) };
           
        }

        public List<Person> RetrievePersons(Person p)
        {
            List<Person> lspersons = new List<Person>();

            for (int i = 0; i < 2; i++)
            {
                lspersons.Add(new Person { ID = i, Name = "Daniela" + i, DateBird = DateTime.Parse(string.Format("{0:MM/dd/yyyy}", "03/31/1985")) });
            }

            for (int i = 2; i < 4; i++)
            {
                lspersons.Add(new Person { ID = i, Name = "Anai" + i, DateBird = DateTime.Parse(string.Format("{0:MM/dd/yyyy}", "03/31/1985")) });
            }

         
            return lspersons;
        }
    }
}
