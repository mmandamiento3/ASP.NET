using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InnerJoinEF.Models;

namespace InnerJoinEF.Controllers
{
    public class PersonasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Personas
        public ActionResult Index()
        {
            

            ////ingresar una direccion
            //var persona=new Persona() { Id=2};     

            //db.Persona.Attach(persona);
            //db.Direccion.Add(new Direccion() { Calle = "Calle 22", Persona = persona });
            //db.SaveChanges();

            //---------------------------------------------------------//
                    //INNER JOIN
                    /*Traemos una direccion y su persona*/
                var personaDireccion = db.Direccion.Join(db.Persona, dir => dir.IdPersona,
                    per => per.Id, (dir,per) => new { dir,per}).FirstOrDefault(x =>x.dir.CodigoDireecion==1);

            //traemos una persona con todas sus direcciones
            var personas1ConSusDireccion = db.Persona.GroupJoin(db.Direccion, per => per.Id,
                dir => dir.IdPersona, (per, dir) => new { per, dir }).FirstOrDefault(x => x.per.Id == 1);
            //Todas las personas con todas sus diorecciones
            var personasConSusDirecciones = db.Persona.GroupJoin(db.Direccion, per => per.Id,
               dir => dir.IdPersona, (per, dir) => new { per, dir }).ToList();


            //PARA VER EL QUERY QUE ENTITY FRAMEWORK REALIZA al final de cada sentencia se pone el tostring:
            //var personas = db.Persona.ToString();
            //var direccion = db.Direccion.Select(x => new { x.CodigoDireecion, x.Calle }).ToString();
            //var personasSexoMasculino = db.Persona.GroupBy(x=>x.Sexo).ToString();


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
        public ActionResult Create([Bind(Include = "Id,Nombre,NAcimiento,Edad")] Persona persona)
        {
            

            if (ModelState.IsValid)
            {
                //var nuevo = new Persona();
                //nuevo.Nombre = "Christian";
                //nuevo.Edad = 27;
                //nuevo.NAcimiento = new DateTime(1992, 01, 03);
                //db.Persona.Add(nuevo);

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
        public ActionResult Edit([Bind(Include = "Id,Nombre,NAcimiento,Edad")] Persona persona)
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
