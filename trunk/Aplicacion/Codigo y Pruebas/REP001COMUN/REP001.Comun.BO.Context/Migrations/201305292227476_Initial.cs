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
                        LastName = c.String(),
                        ImgUrl = c.String(),
                        Img = c.Binary(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);

            CreateTable(
               "dbo.Employee",
               c => new
               {
                   ID = c.Long(nullable: false, identity: true),
                   Person_ID=c.Long(nullable:false),
                   PayMent = c.Decimal(precision: 18, scale: 2),
                   Position = c.String(),
                   Discriminator = c.String(nullable: false, maxLength: 128),
               })
               .PrimaryKey(t => t.ID).ForeignKey("dbo.People", t => t.Person_ID).Index(t=>t.Person_ID);
            

            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Clave = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Estadoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Clave = c.String(),
                        Descripcion = c.String(),
                        Pais_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Pais", t => t.Pais_ID)
                .Index(t => t.Pais_ID);
            
            CreateTable(
                "dbo.Ciudads",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Clave = c.String(),
                        Descripcion = c.String(),
                        Estado_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Estadoes", t => t.Estado_ID)
                .Index(t => t.Estado_ID);
            
            CreateTable(
                "dbo.Localidads",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Clave = c.String(),
                        Descripcion = c.String(),
                        Ciudad_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ciudads", t => t.Ciudad_ID)
                .Index(t => t.Ciudad_ID);
            
            CreateTable(
                "dbo.Ubicacions",
                c => new
                    {
                        UbicacionID = c.Long(nullable: false, identity: true),
                        FechaRegistro = c.DateTime(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        Person_ID = c.Long(),
                        Pais_ID = c.Int(),
                        Estado_ID = c.Int(),
                        Ciudad_ID = c.Int(),
                        Localidad_ID = c.Int(),
                    })
                .PrimaryKey(t => t.UbicacionID)
                .ForeignKey("dbo.People", t => t.Person_ID)
                .ForeignKey("dbo.Pais", t => t.Pais_ID)
                .ForeignKey("dbo.Estadoes", t => t.Estado_ID)
                .ForeignKey("dbo.Ciudads", t => t.Ciudad_ID)
                .ForeignKey("dbo.Localidads", t => t.Localidad_ID)
                .Index(t => t.Person_ID)
                .Index(t => t.Pais_ID)
                .Index(t => t.Estado_ID)
                .Index(t => t.Ciudad_ID)
                .Index(t => t.Localidad_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Ubicacions", new[] { "Localidad_ID" });
            DropIndex("dbo.Ubicacions", new[] { "Ciudad_ID" });
            DropIndex("dbo.Ubicacions", new[] { "Estado_ID" });
            DropIndex("dbo.Ubicacions", new[] { "Pais_ID" });
            DropIndex("dbo.Ubicacions", new[] { "Person_ID" });
            DropIndex("dbo.Localidads", new[] { "Ciudad_ID" });
            DropIndex("dbo.Ciudads", new[] { "Estado_ID" });
            DropIndex("dbo.Estadoes", new[] { "Pais_ID" });
            DropForeignKey("dbo.Ubicacions", "Localidad_ID", "dbo.Localidads");
            DropForeignKey("dbo.Ubicacions", "Ciudad_ID", "dbo.Ciudads");
            DropForeignKey("dbo.Ubicacions", "Estado_ID", "dbo.Estadoes");
            DropForeignKey("dbo.Ubicacions", "Pais_ID", "dbo.Pais");
            DropForeignKey("dbo.Ubicacions", "Person_ID", "dbo.People");
            DropForeignKey("dbo.Localidads", "Ciudad_ID", "dbo.Ciudads");
            DropForeignKey("dbo.Ciudads", "Estado_ID", "dbo.Estadoes");
            DropForeignKey("dbo.Estadoes", "Pais_ID", "dbo.Pais");
            DropForeignKey("dbo.Employee","Person_ID","dbo.People");
            DropTable("dbo.Ubicacions");
            DropTable("dbo.Localidads");
            DropTable("dbo.Ciudads");
            DropTable("dbo.Estadoes");
            DropTable("dbo.Pais");
            DropTable("dbo.Employee");
            DropTable("dbo.People");
           
        }
    }
}
