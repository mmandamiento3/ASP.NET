namespace EfCodeFirst.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EfCodeFirst.Models.Blogcontext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;

        }
        //EL COMANDO SEED SE EJECUTA CUANDO ESCRIBIMOS EL COMANDO UPDATE-DATABASE 
        protected override void Seed(EfCodeFirst.Models.Blogcontext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.





            //HACEMOS UN QUERy A COMENTARIOS//
            context.Comentarios.AddOrUpdate(x => x.Id, new Models.Comentario()
            {
                Id = 1,
                Autor = "Christian",
                BlogPostId = 1,
                Contenido="Ejemplo de Contenido"


            });

         
        }
    }
}
