using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace REP001.Comun.WebHost
{
  
    [DataContract]
    public class PersonInfo
    {
        [DataMember]
        public long? ID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime? DateBird { get; set; }

        [DataMember]
        public int? Age { get { return ((int)((DateTime.Today.AddYears(1) - (DateTime)DateBird).TotalDays / 365) - 1); } }

        [DataMember]
        public string LastName { get; set; }

    }
}