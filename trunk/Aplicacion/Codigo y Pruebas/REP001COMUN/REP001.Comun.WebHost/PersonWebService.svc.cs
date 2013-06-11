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
            PersonInfo p = new PersonInfo { Name = "Daniela Avila Franco" };
            List<PersonInfo> ls = new List<PersonInfo>();
            ls.Add(p);
            return ls;
           
        }


        public List<string> DoSearchByID(long id)
        {
            List<string> ls = new List<string>();
            for (int i = 0; i < 5; i++) {

                ls.Add("Daniela Avila " + i);
            }
            return ls;
        }

        public byte[] ImageDoSearchByName(long id)
        {
            throw new NotImplementedException();
        }


        public byte[] DoImageSearch(long id)
        {
            throw new NotImplementedException();
        }
    }

    public class PersonInfo {

        public string Name { get; set; }
        public string Ap1 { get; set; }
        public string Ap2 { get; set; }
        public DateTime BirdDay { get; set; }
        public string ImgDir { get; set; }
        public byte[] Img { get; set; }
    }
}
