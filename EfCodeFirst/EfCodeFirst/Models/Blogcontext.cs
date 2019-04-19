using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EfCodeFirst.Models
{
    public class Blogcontext:DbContext
    {
        //Podemos tener varios connectionstrings aqui especificamos cual es
        public Blogcontext()
            :base("DefaultConnection")
        {
            
        }
        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Comentario> Comentarios { get; set; }
    }
}