using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EFCodeFirst2.Models
{
    public class Direccion
    {
        public int CodigoDireccion { get; set; }
        public string Calle { get; set; }
        //Asumiento que una o varias direcciones corresponden a una persona
        public Persona Persona { get; set; }
    }
}