using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Migraciones.Models
{
    public class ApplicationDBContext : DbContext
    {

        public DbSet<Persona> Persona { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Subdireccion> SubDireccion { get; set; }


        public ApplicationDBContext()
            :base("ConexionPorDefecto")
        {

        }

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
            modelBuilder.Entity<Subdireccion>().HasRequired(x => x.Direccion);

            modelBuilder.Entity<Direccion>().Property(x => x.Calle).HasMaxLength(300).IsRequired();


            base.OnModelCreating(modelBuilder);
        }
    }
}


