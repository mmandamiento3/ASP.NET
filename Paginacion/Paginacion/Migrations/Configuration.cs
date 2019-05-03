namespace Paginacion.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Paginacion.Models.ApplicaciontDbContext>
    {
        
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Paginacion.Models.ApplicaciontDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
