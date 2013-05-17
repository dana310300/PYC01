using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using REP001.Comun.BO;
namespace REP001.Comun.Service.Interface
{
    public interface IPersonService
    {
        Person Create(Person p);
        void Delete(Person p);
        Person Retrieve(Person p);
        void Edit(Person p);
        List<Person> RetrievePersons();
    }
}
