using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;


namespace REP001.Comun.BO.Context
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(): base("name=DefaultConnection")
        { 
        
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
