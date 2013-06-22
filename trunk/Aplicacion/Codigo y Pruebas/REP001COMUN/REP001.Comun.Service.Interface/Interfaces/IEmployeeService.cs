using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using REP001.Comun.BO;

namespace REP001.Comun.Service.Interface
{
   public interface IEmployeeService
    {

        Employee Create(Employee p);

        void Delete(Employee p);

        Employee Retrieve(Employee p);

        Employee RetrieveComplete(Employee p);

        void Edit(Employee p);

        void Dispose();

        List<Employee> RetrieveEmployees();

        List<Employee> RetrieveEmployees(Employee p);

        List<Employee> RetrieveEmployees(int page, int count, string sort, bool sortdecending, out int resultcount);
    }
}
