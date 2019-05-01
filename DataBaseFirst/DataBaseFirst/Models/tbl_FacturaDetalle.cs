namespace DataBaseFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_FacturaDetalle
    {
        [Key]
        public int IdFacturaDetalle { get; set; }

        public int IdFacturaCabecera { get; set; }

        [Required]
        [StringLength(250)]
        public string IdProducto { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Total { get; set; }

        public virtual tbl_FacturaCabecera tbl_FacturaCabecera { get; set; }

        public virtual tbl_Producto tbl_Producto { get; set; }
    }
}
