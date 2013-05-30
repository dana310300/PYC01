namespace REP001.Comun.BO.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Long(nullable: false, identity: true),
                        PayMent = c.Decimal(precision: 18, scale: 2),
                        Position = c.String(),
                        Person_ID = c.Long(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.People", t => t.Person_ID)
                .Index(t => t.Person_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "Person_ID" });
            DropForeignKey("dbo.Employees", "Person_ID", "dbo.People");
            DropTable("dbo.Employees");
        }
    }
}
