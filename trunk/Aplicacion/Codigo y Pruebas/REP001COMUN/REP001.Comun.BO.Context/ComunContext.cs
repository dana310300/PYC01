using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REP001.Comun.BO.Context
{
   public class ComunContext:DbContext
    {
       public ComunContext() : base("DefaultConnection")
       { 

       }
     public  DbSet<Person> Person { get; set; }
     public DbSet<Employee> Employee { get; set; }
     public DbSet<Pais> Pais { get; set; }
     public DbSet<Estado> Estado { get; set; }
     public DbSet<Ciudad> Ciudad { get; set; }
     public DbSet<Localidad> Localidad { get; set; }
     public DbSet<Ubicacion> Ubicacion { get; set; }

       //protected override void OnModelCreating(DbModelBuilder modelBuilder)
       //{
       //    base.OnModelCreating(modelBuilder);
       //}
    }
}
