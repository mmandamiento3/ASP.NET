using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EagerYLazyLoading.Models;

namespace EagerYLazyLoading.Controllers
{
    public class PersonasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Personas
        public ActionResult Index()
        {
            //Inresar Direccion
            //var direccion = new Persona() { Id = 2 };
            //db.Persona.Attach(direccion);
            //db.Direccion.Add(new Direccion() { Calle = "Calle 2", Persona = direccion });
            //db.SaveChanges();

            //insertar una subdireccion
            //var subdireccion = new Direccion() { CodigoDireccion = 2 };
            //db.Direccion.Attach(subdireccion);
            //db.SubDireccion.Add(new SubDireccion() { SubCalle = "Subcalle 222", Direccion = subdireccion });
            //db.SaveChanges();
            //return View(db.Persona.ToList());

            //Error debemos utilizar include
            var persona = db.Persona.FirstOrDefault();

            //include con Lambda
            var personasInclude = db.Persona.Include(x => x.Direcciones).FirstOrDefault();
            var primerDireccionInclude = db.Persona.FirstOrDefault().Direcciones[0];

            //Include con String
            var personaConDirecciones = db.Persona.Include("Direcciones").ToList();
            var DirecciomDeLaSegundaPersona = personaConDirecciones[1].Direcciones[0];

            //Include segundo nivel
            var personasConDireccionesConSub = db.Persona.Include(x => x.Direcciones.Select(y => y.SubDireccion)).FirstOrDefault();
            var subCalle = personasConDireccionesConSub.Direcciones[0].SubDireccion[1].SubCalle;


            return View(db.Persona.ToList());
        }

        // GET: Personas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Nacimiento,Edad,Sexo")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Persona.Add(persona);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(persona);
        }

        // GET: Personas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Nacimiento,Edad,Sexo")] Persona persona)
        {
            if (ModelState.IsValid)
            {
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(persona);
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Persona persona = db.Persona.Find(id);
            if (persona == null)
            {
                return HttpNotFound();
            }
            return View(persona);
        }

        // POST: Personas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Persona persona = db.Persona.Find(id);
            db.Persona.Remove(persona);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
