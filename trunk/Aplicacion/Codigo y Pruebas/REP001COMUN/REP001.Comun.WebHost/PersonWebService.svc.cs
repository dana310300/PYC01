using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using REP001.Comun.BO;

namespace REP001.Comun.WebHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PersonWebService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PersonWebService.svc or PersonWebService.svc.cs at the Solution Explorer and start debugging.
    public class PersonWebService : IPersonWebService
    {
        public List<PersonInfo> DoSearchByName(string name)
        {

            //List<Person> p = new List<Person>();
            //p.Add(new Person { ID = 1, Name = "Daniela", LastName = "Avila", DateBird = DateTime.Today.AddYears(-20) });

            //List<PersonInfo> pinf = new List<PersonInfo>();
            //foreach (Person pi in p)
            //{
            //    pinf.Add(new PersonInfo
            //    {
            //        ID = pi.ID,
            //        Name = pi.Name,
            //        DateBird = pi.DateBird,
            //        LastName = pi.LastName
            //    });
            //}
            //return pinf;
            PersonInfo p = new PersonInfo { Name = "Daniela Avila Franco" };
            List<PersonInfo> ls = new List<PersonInfo>();
            ls.Add(p);
            return ls;
            
           
        }
    }

    public class PersonInfo {

        public string Name { get; set; }
    }
}
