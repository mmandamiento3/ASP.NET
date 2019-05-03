using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Paginacion.Models
{
    public class BaseModelo
    {
        public int PaginaActuak { get; set; }
        public int TotalDeRegistros { get; set; }
        public int RegsitrosPorPagina { get; set; }


    }
}