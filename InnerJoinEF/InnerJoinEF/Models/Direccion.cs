using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InnerJoinEF.Models
{
    public class Direccion
    {
        public int CodigoDireecion { get; set; }
        public string Calle { get; set; }
        public int IdPersona { get; set; }
        public Persona Persona { get; set; }
    }
}