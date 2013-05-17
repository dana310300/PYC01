namespace REP001.Comun.BO.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        DateBird = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Employee",
                c => new
                {
                    People_ID = c.Long(nullable: false),
                    EmployeeID = c.Long(nullable: false,identity:true),
                    PayMent = c.Decimal(precision: 18, scale: 2),
                    Position = c.String(),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.EmployeeID);

            AddForeignKey("dbo.Employee", "People_ID", "dbo.People", "ID", true);

        }
        
        public override void Down()
        {
            DropTable("dbo.Employee");
            DropTable("dbo.People");
            
        }
    }
}
