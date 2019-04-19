using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EFCodeFirst2.Models
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext()
            :base("ConexionPorDefecto")
        {

        }
        public DbSet<Persona>Persona { get; set; }
    }
}