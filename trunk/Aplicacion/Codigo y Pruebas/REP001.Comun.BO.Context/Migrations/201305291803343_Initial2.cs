namespace REP001.Comun.BO.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "EmployeeID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "EmployeeID", c => c.Long());
        }
    }
}
