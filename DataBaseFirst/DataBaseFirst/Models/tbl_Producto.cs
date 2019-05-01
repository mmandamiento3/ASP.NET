namespace DataBaseFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Producto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Producto()
        {
            tbl_FacturaDetalle = new HashSet<tbl_FacturaDetalle>();
        }

        [Key]
        [StringLength(250)]
        public string IdProducto { get; set; }

        [Required]
        [StringLength(10)]
        public string Codigo { get; set; }

        [Required]
        [StringLength(250)]
        public string Descripcion { get; set; }

        public decimal PrecioUnitario { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_FacturaDetalle> tbl_FacturaDetalle { get; set; }
    }
}
