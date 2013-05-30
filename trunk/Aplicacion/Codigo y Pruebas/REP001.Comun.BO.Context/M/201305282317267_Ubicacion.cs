namespace REP001.Comun.BO.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ubicacion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
               "dbo.Pais",
               c => new
               {
                   ID = c.Int(nullable: false, identity: true),
                   Name = c.Int(nullable: false),
                   Descripcion = c.Int(nullable: false),
               })
               .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Estado",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.Int(nullable: false),
                    Descripcion = c.Int(nullable: false),
                    Pais_ID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pais", t => t.Pais_ID)
                .Index(t => t.Pais_ID);

            CreateTable(
                "dbo.Ciudad",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.Int(nullable: false),
                    Descripcion = c.Int(nullable: false),
                    Estado_ID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Estado", t => t.Estado_ID)
                .Index(t => t.Estado_ID);

            CreateTable(
                "dbo.Localidad",
                c => new
                {
                    ID = c.Int(nullable: false, identity: true),
                    Name = c.Int(nullable: false),
                    Descripcion = c.Int(nullable: false),
                    Ciudad_ID = c.Int(),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ciudad", t => t.Ciudad_ID)
                .Index(t => t.Ciudad_ID);

           
        }
        
        public override void Down()
        {
            DropIndex("dbo.Localidad", new[] { "Ciudad_ID" });
            DropIndex("dbo.Ciudad", new[] { "Estado_ID" });
            DropIndex("dbo.Estado", new[] { "Pais_ID" });
            DropForeignKey("dbo.Localidad", "Ciudad_ID", "dbo.Ciudad");
            DropForeignKey("dbo.Ciudad", "Estado_ID", "dbo.Estado");
            DropForeignKey("dbo.Estado", "Pais_ID", "dbo.Pais");
            DropTable("dbo.Localidad");
            DropTable("dbo.Ciudad");
            DropTable("dbo.Estado");
            DropTable("dbo.Pais");
        }
    }
}
