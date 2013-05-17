using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace REP001.Comun.BO
{
   public class Employee:Person
    {
        public long? EmployeeID { get; set; }
        public decimal? PayMent { get; set; }
        public string Position { get; set; }
    }
}
