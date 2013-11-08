using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REP001.Comun.BO
{
   public class EmployeeEventArg:EventArgs
    {
       public EmployeeEventArg()
       {
           
       }
       public Employee Employee { get; set; }
       public string Error { get; set; }
       public string Message { get; set; }
    }
}
