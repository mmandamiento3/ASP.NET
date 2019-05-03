using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Paginacion.Models;
using System.Web.Routing;

namespace Paginacion.Controllers
{
    public class PersonasController : Controller
    {
        private ApplicaciontDbContext db = new ApplicaciontDbContext();

        // GET: Personas
        public ActionResult Index(int? edad,int pagina=1)//EL parametro pagina=1, es para que por defecto inicie en la pagina 1
        {
            var cantidadRegistroPorPagina = 10; //Deberia ser un parámtro
            using (var db=new ApplicaciontDbContext())
            {
                //var personas = db.Persona.OrderBy(x=>x.Id).
                //    Skip((pagina - 1)*cantidadRegistroPorPagina)//Salta los registros, dependiendo de la pagina
                //    .Take(cantidadRegistroPorPagina).ToList();

                //var totalDeRegistro = db.Persona.Count();//Si se hace un filtro en el listado de arriba, 
                //                                           //  el mismo filtro se deberia poner abajo y no usar el COUNT, ya que si hubieras 10000 registros te contarias todos

                //var modelo = new IndexViewModel();
                //modelo.Personas = personas;
                //modelo.PaginaActuak = pagina;
                //modelo.TotalDeRegistros = totalDeRegistro;
                //modelo.RegsitrosPorPagina = cantidadRegistroPorPagina;

                //return View(modelo);

                Func<Persona, bool> predicado = x => !edad.HasValue || edad.Value == x.Edad;

                var personas = db.Persona.Where(predicado).OrderBy(x => x.Id)
                    .Skip((pagina - 1) * cantidadRegistroPorPagina)
                    .Take(cantidadRegistroPorPagina).ToList();
                var totalDeRegistros = db.Persona.Where(predicado).Count();

                var modelo = new IndexViewModel();
                modelo.Personas = personas;
                modelo.PaginaActuak = pagina;
                modelo.TotalDeRegistros = totalDeRegistros;
                modelo.RegsitrosPorPagina = cantidadRegistroPorPagina;
                modelo.ValoresQueryString = new RouteValueDictionary();
                modelo.ValoresQueryString["edad"] = edad;

                return View(modelo);

            }
           
               
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
            //var personas = new Persona();
            //var lista = new List<Persona>();
            //for (int i = 10; i <= 20; i++)
            //{
            //    personas.Nombre = "Nombre :" + i;
            //    personas.Edad = i;

            //    lista.Add(personas);
            //    db.Persona.AddRange(lista);
            //    db.SaveChanges();
            //}
            //return RedirectToAction("Index");
        }

        // POST: Personas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Edad")] Persona persona)
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
        public ActionResult Edit([Bind(Include = "Id,Nombre,Edad")] Persona persona)
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
