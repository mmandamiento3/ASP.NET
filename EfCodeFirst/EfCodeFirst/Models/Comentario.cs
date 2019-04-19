using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EfCodeFirst.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Contenido { get; set; }
        public string Autor { get; set; }

        public int BlogPostId { get; set; }
        [ForeignKey("BlogPostId")]        
        public BlogPost BlogPost { get; set; }
        //Propiedad Navigacional
        /*Es como una relacion entre la clase Blogpost
         y el Comentario */

    }
}