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
                       
                    })
                .PrimaryKey(t => t.ID);

            CreateTable(
                "dbo.Employee",
                c => new
                {
                    ID = c.Long(nullable: false, identity: true),
                    PayMent = c.Decimal(precision: 18, scale: 2),
                    Position = c.String(),
                    Pleople_ID=c.Long(),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.People", t => t.Pleople_ID);

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
                "dbo.Estado",
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
                "dbo.Ciudad",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Clave = c.String(),
                        Descripcion = c.String(),
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
                        Name = c.String(),
                        Clave = c.String(),
                        Descripcion = c.String(),
                        Ciudad_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Ciudad", t => t.Ciudad_ID)
                .Index(t => t.Ciudad_ID);
            
            CreateTable(
                "dbo.Ubicacion",
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
                .ForeignKey("dbo.Estado", t => t.Estado_ID)
                .ForeignKey("dbo.Ciudad", t => t.Ciudad_ID)
                .ForeignKey("dbo.Localidad", t => t.Localidad_ID)
                .Index(t => t.Person_ID)
                .Index(t => t.Pais_ID)
                .Index(t => t.Estado_ID)
                .Index(t => t.Ciudad_ID)
                .Index(t => t.Localidad_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Ubicacion", new[] { "Localidad_ID" });
            DropIndex("dbo.Ubicacion", new[] { "Ciudad_ID" });
            DropIndex("dbo.Ubicacion", new[] { "Estado_ID" });
            DropIndex("dbo.Ubicacion", new[] { "Pais_ID" });
            DropIndex("dbo.Ubicacion", new[] { "Person_ID" });
            DropIndex("dbo.Localidad", new[] { "Ciudad_ID" });
            DropIndex("dbo.Ciudad", new[] { "Estado_ID" });
            DropIndex("dbo.Estado", new[] { "Pais_ID" });
            DropForeignKey("dbo.Ubicacion", "Localidad_ID", "dbo.Localidad");
            DropForeignKey("dbo.Ubicacion", "Ciudad_ID", "dbo.Ciudad");
            DropForeignKey("dbo.Ubicacion", "Estado_ID", "dbo.Estado");
            DropForeignKey("dbo.Ubicacion", "Pais_ID", "dbo.Pais");
            DropForeignKey("dbo.Ubicacion", "Person_ID", "dbo.People");
            DropForeignKey("dbo.Localidad", "Ciudad_ID", "dbo.Ciudad");
            DropForeignKey("dbo.Ciudad", "Estado_ID", "dbo.Estado");
            DropForeignKey("dbo.Estado", "Pais_ID", "dbo.Pais");
            DropTable("dbo.Ubicacion");
            DropTable("dbo.Localidad");
            DropTable("dbo.Ciudad");
            DropTable("dbo.Estado");
            DropTable("dbo.Pais");
            DropTable("dbo.Employee");
            DropTable("dbo.People");
           
        }
    }
}
