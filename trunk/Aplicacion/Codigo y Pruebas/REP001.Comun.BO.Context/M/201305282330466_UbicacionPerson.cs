namespace REP001.Comun.BO.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UbicacionPerson : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ubicacion",
                c => new
                    {
                        UbicacionID = c.Long(nullable: false, identity: true),
                        FechaRegistro = c.DateTime(nullable: false),
                        Activo = c.Boolean(nullable: false),
                        People_ID = c.Long(nullable:false),
                        Pais_ID = c.Int(nullable:false),
                        Estado_ID = c.Int(nullable:false),
                        Ciudad_ID = c.Int(nullable:false),
                        Localidad_ID = c.Int(nullable:false),
                    })
                .PrimaryKey(t => t.UbicacionID);
              

            AddForeignKey("dbo.Ubicacion", "People_ID", "dbo.People", "ID", true);
            AddForeignKey("dbo.Ubicacion", "Pais_ID", "dbo.Pais", "ID", true);
            AddForeignKey("dbo.Ubicacion", "Estado_ID", "dbo.Estado", "ID", true);
            AddForeignKey("dbo.Ubicacion", "Ciudad_ID", "dbo.Ciudad", "ID", true);
            AddForeignKey("dbo.Ubicacion", "Localidad_ID", "dbo.Localidad", "ID", true);

                //.ForeignKey("dbo.Pais", t => t.Pais_ID)
                //.ForeignKey("dbo.Estado", t => t.Estado_ID)
                //.ForeignKey("dbo.Ciudad", t => t.Ciudad_ID)
                //.ForeignKey("dbo.Localidad", t => t.Localidad_ID)
                //.Index(t => t.Person_ID)
                //.Index(t => t.Pais_ID)
                //.Index(t => t.Estado_ID)
                //.Index(t => t.Ciudad_ID)
                //.Index(t => t.Localidad_ID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Ubicacion", new[] { "Localidad_ID" });
            DropIndex("dbo.Ubicacion", new[] { "Ciudad_ID" });
            DropIndex("dbo.Ubicacion", new[] { "Estado_ID" });
            DropIndex("dbo.Ubicacion", new[] { "Pais_ID" });
            DropIndex("dbo.Ubicacion", new[] { "Person_ID" });
            DropForeignKey("dbo.Ubicacion", "Localidad_ID", "dbo.Localidad","ID",true);
            DropForeignKey("dbo.Ubicacion", "Ciudad_ID", "dbo.Ciudad","ID",true);
            DropForeignKey("dbo.Ubicacion", "Estado_ID", "dbo.Estado","ID",true);
            DropForeignKey("dbo.Ubicacion", "Pais_ID", "dbo.Pais","ID",true);
            DropForeignKey("dbo.Ubicacion", "People_ID", "dbo.People","ID",true);
            DropTable("dbo.Ubicacion");
        }
    }
}
