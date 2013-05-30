using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using REP001.Comun.BO;

namespace REP001.Comun.Web.MVC.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IComunPersonService" in both code and config file together.
    [ServiceContract]
    public interface IComunPersonService
    {
        [OperationContract]
        List<PersonInfo> DoSearchByName(string name);
    }

    [DataContract]
    public class PersonInfo {
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
