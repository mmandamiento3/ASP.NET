using EfCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EfCodeFirst.Services
{
    public class BlogPostRepository
    {
        public List<BlogPost> ObtenerTodosBlogs()
        {
            using ( var db = new Blogcontext())
            {
                return db.BlogPosts.Include(x =>x.Comentarios).ToList();

            }
        }

        public void Crear(BlogPost model)
        {
            using ( var db = new Blogcontext())
            {
                db.BlogPosts.Add(model);
                db.SaveChanges();
            }
        }
    }
}