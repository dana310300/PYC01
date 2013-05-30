namespace REP001.Comun.BO.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.People", "EmployeeID");
            DropColumn("dbo.People", "PayMent");
            DropColumn("dbo.People", "Position");
            DropColumn("dbo.People", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.People", "Position", c => c.String());
            AddColumn("dbo.People", "PayMent", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.People", "EmployeeID", c => c.Long());
        }
    }
}
