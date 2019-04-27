using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EagerYLazyLoading.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("ConexionPorDefecto")
        {

        }

        public DbSet<Persona> Persona { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<SubDireccion>SubDireccion { get; set; }


        //Metodo que nos sirve para hacer cnfiguraciones en como Entity Framework
        //trabajara connuestra Base de dAtos
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Especificamos que queremos ahcer un cambio en el Datetime por datetime2
            modelBuilder.Properties<DateTime>().Configure(x => x.HasColumnType("datetime2"));
            //Segun convencion al gun campo en un tabala con "ID" automaticamente se vuelve primary key,
            //sin embargo se puede modificar este parametro. en el ejemplo
            //especificamos que si un nombre empieza con "codigo" automaticamente se especifica 
            //como primary KEY :) -- Ejemplo en la clase-modelo : Direccion
            modelBuilder.Properties<int>().Where(p => p.Name.StartsWith("Codigo"))
                .Configure(p => p.IsKey());


            //Relaciona la tabla Direccion con la tabla persona
            /*Se crea una columna personaid en la tabla direccion en la cual hace refernaica
             (llave foranea) hacia la tabla persona*/
            //--EN pocas palabras la entidad Direccion siempre requirira el id de la persona
            modelBuilder.Entity<Direccion>().HasRequired(x => x.Persona);
            modelBuilder.Entity<SubDireccion>().HasRequired(x=>x.Direccion);

            base.OnModelCreating(modelBuilder);
        }
    }
}