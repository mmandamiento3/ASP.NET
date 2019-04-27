using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EagerYLazyLoading.Models
{
    public class Direccion
    {
        public int CodigoDireccion { get; set; }
        public string Calle { get; set; }
        public Persona Persona { get; set; }
        public List<SubDireccion> SubDireccion { get; set; }
    }



    public class SubDireccion
    {
        [Key]
        public int Id { get; set; }
        [StringLength(124)]
        public string SubCalle { get; set; }
        public Direccion Direccion { get; set; }
    }



}