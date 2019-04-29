using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Migraciones.Models
{
    public class Persona
    {
        public int Id { get; set; }
        [StringLength(120)]
        public string Nombre { get; set; }
        public DateTime Nacimiento { get; set; }
        public int Edad { get; set; }
        public Sexo Sexo { get; set; }
        public List<Direccion> Direcciones { get; set; }
    }
}