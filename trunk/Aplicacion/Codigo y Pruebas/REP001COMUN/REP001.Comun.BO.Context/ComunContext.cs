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
            this.Configuration.LazyLoadingEnabled = true;
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
            var autoDetectChanges = Configuration.AutoDetectChangesEnabled;
            int affectedEntitiesCount = 0;
            try
            {

                Configuration.AutoDetectChangesEnabled = false;

                ChangeTracker.DetectChanges();

                List<DbEntityValidationResult> errors = GetValidationErrors().ToList();
                if (errors.Any())
                {
                    foreach (DbEntityValidationResult  item in errors ) {
                       
                        foreach ( DbValidationError itemer in item.ValidationErrors ) {
                            throw new DbEntityValidationException("Validation error found during saving" +itemer.ErrorMessage);
                        }
                    }
                   
                }

                Configuration.ValidateOnSaveEnabled = false;
                affectedEntitiesCount = base.SaveChanges();

                foreach (var entry in this.ChangeTracker.Entries().Where(x => x.State == EntityState.Added || x.State == EntityState.Modified))
                {

                    //Se puede realizar un log o algo asi
                }
                return affectedEntitiesCount;
            }
            catch (Exception e)
            {
                throw;
            }
            finally {
                Configuration.AutoDetectChangesEnabled = autoDetectChanges;
            }

            return affectedEntitiesCount;
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
