using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;


namespace REP001.Comun.BO.Context
{
    public class PersonContext:DbContext
    {
        public PersonContext() : base("name=DefaultConnection") { 
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
