using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Validaciones.Models
{
    public class PersonaContext:DbContext
    {
        
        public PersonaContext()
            : base("DefaultConnection")
        {
            
        }
        public DbSet<Persona>Persona { get; set; }
    }
}