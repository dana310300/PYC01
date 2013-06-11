using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace REP001.Comun.WebHost
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IPersonWebService" in both code and config file together.
    [ServiceContract]
    public interface IPersonWebService
    {
        [OperationContract]
        List<PersonInfo> DoSearchByName(string name);

        [OperationContract]
        List<string> DoSearchByID(long id);

        [OperationContract]
        byte[] DoImageSearch(long id);
    }
}
