using System.Data.Entity;

namespace REP001.Comun.WebAPI.MVC.Models.REP001.Comun.WebAPI.MVC
{
    public class EmployeeContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<REP001.Comun.WebAPI.MVC.Models.REP001.Comun.WebAPI.MVC.EmployeeContext>());

        public EmployeeContext() : base("name=EmployeeContext")
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
