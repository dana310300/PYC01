using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REP001.Comun.BO.Context
{
    public class ComunContext : DbContext
    {
        public ComunContext()
            : base("DefaultConnection")
        {
            this.Configuration.ValidateOnSaveEnabled = true;
        }
        public DbSet<Person> Person { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Localidad> Localidad { get; set; }
        public DbSet<Ubicacion> Ubicacion { get; set; }

        protected override DbEntityValidationResult ValidateEntity(DbEntityEntry entityEntry, IDictionary<object, object> items)
        {
            var result = new DbEntityValidationResult(entityEntry, new List<DbValidationError>());
            Validate(result);
            if (!result.IsValid)
            {
                return result;
            }
            return base.ValidateEntity(entityEntry, items);
        }
        protected override bool ShouldValidateEntity(DbEntityEntry entityEntry)
        {

            return (base.ShouldValidateEntity(entityEntry) ||
                    (entityEntry.State == EntityState.Deleted &&
                     entityEntry.Entity is Person));
        }
        
        private void Validate(DbEntityValidationResult result)
        {
            ValidatePerson(result);

        }
        private void ValidatePerson(DbEntityValidationResult result)
        {
            Person po = null;
            po = result.Entry.Entity as Person;
            if (po != null)
            {
                if (result.Entry.State == EntityState.Added && po.Age < 18) 
                {
                    result.ValidationErrors.Add(new DbValidationError("Person", "La edad no puede ser menor a 18"));
                }
            }

        }

        public override int SaveChanges()
        {
              return base.SaveChanges();
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
