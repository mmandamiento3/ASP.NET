using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InnerJoinEF.Models
{
    public class ApplicationDbContext : DbContext        
    {
        public ApplicationDbContext()
            :base("ConexionPorDefecto")
        {
            
        }
        
        public DbSet<Persona>Persona { get; set; }
        public DbSet<Direccion> Direccion { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<DateTime>().Configure(x => x.HasColumnType("datetime"));

            modelBuilder.Properties<int>().Where(y => y.Name.StartsWith("Codigo")).Configure(y=>y.IsKey());
            //Especificamos que la llave fornaea de la tabla Persona en la Tabla Direccion ser IdPErsona
            modelBuilder.Entity<Direccion>().HasRequired(x => x.Persona).WithMany().HasForeignKey(x => x.IdPersona);

            base.OnModelCreating(modelBuilder);
        }


    
    }
}