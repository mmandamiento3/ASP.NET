namespace EFCodeFirst2.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFCodeFirst2.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            //Si queremos que no salga la advertencia de quie s eperdera data ponemos el siguiente codigo:
            //NO ES RECOMMENDBALE
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EFCodeFirst2.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
