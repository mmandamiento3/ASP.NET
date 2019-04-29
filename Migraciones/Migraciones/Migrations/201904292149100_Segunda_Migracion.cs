namespace Migraciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Segunda_Migracion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Direccions", "Calle", c => c.String(nullable: false, maxLength: 300));
            AlterColumn("dbo.Personas", "Nombre", c => c.String(maxLength: 120));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Personas", "Nombre", c => c.String());
            AlterColumn("dbo.Direccions", "Calle", c => c.String());
        }
    }
}
