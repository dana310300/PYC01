namespace REP001.Comun.BO.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.People", "ImgDir", c => c.String());
            AddColumn("dbo.People", "Email", c => c.String());
            AlterColumn("dbo.People", "Name", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.People", "LastName", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.People", "ImgUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "ImgUrl", c => c.String());
            AlterColumn("dbo.People", "LastName", c => c.String());
            AlterColumn("dbo.People", "Name", c => c.String());
            DropColumn("dbo.People", "Email");
            DropColumn("dbo.People", "ImgDir");
        }
    }
}
