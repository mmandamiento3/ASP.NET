namespace DataBaseFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_FacturaCabecera
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_FacturaCabecera()
        {
            tbl_FacturaDetalle = new HashSet<tbl_FacturaDetalle>();
        }

        [Key]
        public int IdFacturaCabecera { get; set; }

        [Required]
        [StringLength(250)]
        public string IdCliente { get; set; }

        public int Numero { get; set; }

        public int Serie { get; set; }

        public int Fecha { get; set; }

        public decimal SubTotal { get; set; }

        public decimal Impuestos { get; set; }

        public decimal Total { get; set; }

        public virtual tbl_Clientes tbl_Clientes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_FacturaDetalle> tbl_FacturaDetalle { get; set; }
    }
}
