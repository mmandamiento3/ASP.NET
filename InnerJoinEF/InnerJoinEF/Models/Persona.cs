using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InnerJoinEF.Models
{
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime NAcimiento { get; set; }
        public int Edad { get; set; }
    }
}