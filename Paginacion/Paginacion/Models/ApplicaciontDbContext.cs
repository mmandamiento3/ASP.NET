using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Paginacion.Models
{
    public class ApplicaciontDbContext:DbContext
    {
        public ApplicaciontDbContext()
            :base("ConexionPorDefecto")
        {

        }
        public DbSet<Persona>Persona { get; set; }
    }
}