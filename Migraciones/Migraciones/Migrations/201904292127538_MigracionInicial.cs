namespace Migraciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigracionInicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Direccions",
                c => new
                    {
                        CodigoDireccion = c.Int(nullable: false, identity: true),
                        Calle = c.String(),
                        Persona_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CodigoDireccion)
                .ForeignKey("dbo.Personas", t => t.Persona_Id, cascadeDelete: true)
                .Index(t => t.Persona_Id);
            
            CreateTable(
                "dbo.Personas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Nacimiento = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Edad = c.Int(nullable: false),
                        Sexo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subdireccions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubCalle = c.String(maxLength: 124),
                        Direccion_CodigoDireccion = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Direccions", t => t.Direccion_CodigoDireccion, cascadeDelete: true)
                .Index(t => t.Direccion_CodigoDireccion);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subdireccions", "Direccion_CodigoDireccion", "dbo.Direccions");
            DropForeignKey("dbo.Direccions", "Persona_Id", "dbo.Personas");
            DropIndex("dbo.Subdireccions", new[] { "Direccion_CodigoDireccion" });
            DropIndex("dbo.Direccions", new[] { "Persona_Id" });
            DropTable("dbo.Subdireccions");
            DropTable("dbo.Personas");
            DropTable("dbo.Direccions");
        }
    }
}
