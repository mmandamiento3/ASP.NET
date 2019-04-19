using EfCodeFirst.Models;
using EfCodeFirst.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EfCodeFirst.Controllers
{
    public class BlogPostController : Controller
    {
        private BlogPostRepository _repo;

        public BlogPostController()
        {
           _repo = new BlogPostRepository();
        }
        
        // GET: BlogPost
        public ActionResult Index()
        {
            var modelo = _repo.ObtenerTodosBlogs();
            var comentario = modelo[0].Comentarios[0];
            return View(modelo);
        }

        // GET: BlogPost/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BlogPost/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: BlogPost/Create
        [HttpPost]
        public ActionResult Create(BlogPost model)
        {
            try
            {
                // TODO: Add insert logic here

                if (ModelState.IsValid) //Si las reglas estan cumplidas
                {
                    _repo.Crear(model);
                   
                    return RedirectToAction("Index");
                }

                
            }
            catch(Exception ex)
            {
                //Log ex
            }
            return View(model);
            
        }

        // GET: BlogPost/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BlogPost/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BlogPost/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BlogPost/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
