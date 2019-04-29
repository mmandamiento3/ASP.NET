using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Migraciones.Models
{
    public class Direccion
    {
        public int CodigoDireccion { get; set; }
        public string Calle { get; set; }
        public Persona Persona { get; set; }
        public List<Subdireccion> SubDireccion { get; set; }

    }





    public class Subdireccion
    {
        [Key]
        public int Id { get; set; }
        [StringLength(124)]
        public string SubCalle { get; set; }
        public Direccion Direccion{ get; set; }
    }
}