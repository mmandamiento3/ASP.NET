namespace DataBaseFirst.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public virtual DbSet<tbl_Clientes> tbl_Clientes { get; set; }
        public virtual DbSet<tbl_FacturaCabecera> tbl_FacturaCabecera { get; set; }
        public virtual DbSet<tbl_FacturaDetalle> tbl_FacturaDetalle { get; set; }
        public virtual DbSet<tbl_Producto> tbl_Producto { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_Clientes>()
                .Property(e => e.IdCliente)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Clientes>()
                .Property(e => e.Nombres)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Clientes>()
                .Property(e => e.Apellidos)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Clientes>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Clientes>()
                .HasMany(e => e.tbl_FacturaCabecera)
                .WithRequired(e => e.tbl_Clientes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<tbl_FacturaCabecera>()
                .Property(e => e.IdCliente)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_FacturaCabecera>()
                .Property(e => e.SubTotal)
                .HasPrecision(11, 2);

            modelBuilder.Entity<tbl_FacturaCabecera>()
                .Property(e => e.Impuestos)
                .HasPrecision(11, 2);

            modelBuilder.Entity<tbl_FacturaCabecera>()
                .Property(e => e.Total)
                .HasPrecision(11, 2);

            modelBuilder.Entity<tbl_FacturaDetalle>()
                .Property(e => e.IdProducto)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_FacturaDetalle>()
                .Property(e => e.PrecioUnitario)
                .HasPrecision(11, 2);

            modelBuilder.Entity<tbl_FacturaDetalle>()
                .Property(e => e.Total)
                .HasPrecision(11, 2);

            modelBuilder.Entity<tbl_Producto>()
                .Property(e => e.IdProducto)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Producto>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Producto>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<tbl_Producto>()
                .Property(e => e.PrecioUnitario)
                .HasPrecision(11, 2);

            modelBuilder.Entity<tbl_Producto>()
                .HasMany(e => e.tbl_FacturaDetalle)
                .WithRequired(e => e.tbl_Producto)
                .WillCascadeOnDelete(false);
        }
    }
}
