using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFCodeFirst2.Models
{
    public class Persona
    {
        
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime Nacimiento { get; set; }
        public int Edad { get; set; }
        //Asumiento que una persona puede tener 1 o mas direcciones
        public List<Direccion>Direcciones { get; set; }
    }
}