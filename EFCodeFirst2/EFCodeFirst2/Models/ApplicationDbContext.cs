using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFCodeFirst2.Models
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext()
            :base("ConexionPorDefecto")
        {

        }
        public DbSet<Persona>Persona { get; set; }

        public DbSet<Direccion> Direccion { get; set; }


        //Metodo que nos sirve para hacer cnfiguraciones en como Entity Framework
        //trabajara connuestra Base de dAtos
        protected override void  OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Especificamos que queremos ahcer un cambio en el Datetime por datetime2
            modelBuilder.Properties<DateTime>().Configure(x => x.HasColumnType("datetime2"));
            //Segun convencion al gun campo en un tabala con "ID" automaticamente se vuelve primary key,
            //sin embargo se puede modificar este parametro. en el ejemplo
            //especificamos que si un nombre empieza con "codigo" automaticamente se especifica 
            //como primary KEY :) -- Ejemplo en la clase-modelo : Direccion
            modelBuilder.Properties<int>().Where(p => p.Name.StartsWith("Codigo"))
                .Configure(p => p.IsKey());

            base.OnModelCreating(modelBuilder);
        }



    }
}