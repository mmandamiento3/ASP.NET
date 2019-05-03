using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paginacion.Models
{
    public class IndexViewModel:BaseModelo
    {
        public List<Persona> Personas { get; set; }
    }
}