namespace DataBaseFirst.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tbl_Clientes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Clientes()
        {
            tbl_FacturaCabecera = new HashSet<tbl_FacturaCabecera>();
        }

        [Key]
        [StringLength(250)]
        public string IdCliente { get; set; }

        [Required]
        [StringLength(250)]
        public string Nombres { get; set; }

        [Required]
        [StringLength(250)]
        public string Apellidos { get; set; }

        [Required]
        [StringLength(250)]
        public string Correo { get; set; }

        public int Edad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_FacturaCabecera> tbl_FacturaCabecera { get; set; }
    }
}
