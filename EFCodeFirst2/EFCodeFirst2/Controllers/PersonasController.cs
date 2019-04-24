using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EFCodeFirst2.Models;

namespace EFCodeFirst2.Controllers
{
    public class PersonasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Personas
        public ActionResult Index()

        {
            /*VARIAS FORMAS DE MOSTRAR DATOS:
            // Seleccionar todos las columnas
            var listadoPersonasTodasLasColumnas = db.Persona.ToList();

            // Seleccionar una columna
            var listadonombres = db.Persona.Select(x => x.Nombre).ToList();

           // Selecciona varias columnas y proyectandolas a un tipo anonimo
            var listadoPERsonasVariasColumnas = db.Persona.Select(x => new { Nombre = x.Nombre, Edad = x.Edad }).ToList();

            //Selecciona varias columnas y proyectandolas hacia persona
            var listadoPersonasVariasColumnas = db.Persona.Select(x => new { Nombre = x.Nombre, Edad = x.Edad }).ToList().Select(x => new Persona() { Nombre = x.Nombre, Edad = x.Edad }).ToList();
            */

            //--------------------------------------------------------------//


            /*Agregar un neuvo registro con los MODELOS, haciendo referencia a la llave foranea
            var persona = new Persona() { Id = 13 };
            db.Persona.Attach(persona);//el attach es como si le dijeramos al EF que preste atencion a el campo con ID=12, que no intente crearlo, sino que lo traiga
            db.Direccion.Add(new Direccion() { Calle = "Direccion 2", Persona = persona });
            db.SaveChanges();*/





            //Traer un registro mediante "propiedades de navegacion", se puede hacer mediante VIRTUAL e INCLUDE
            //var persona = db.Persona.Include("Direcciones").FirstOrDefault(x => x.Id==13);
            //var direcciones = persona.Direcciones;

            var persona = db.Persona.Include("Direcciones").FirstOrDefault(x=>x.Id==12);
            var direcciones = persona.Direcciones;

            //PRopiedades de navegacion desde la direccion hacia la persona
            //var direccion = db.Direccion.Include("Persona").FirstOrDefault(x => x.CodigoDireccion == 5);
            //var nombre = direccion.Persona.Nombre;


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
        public ActionResult Create([Bind(Include = "Id,Nombre,Nacimiento,Edad")] Persona persona)
        {
            if (ModelState.IsValid)
            {

                var lista = new List<Persona>()
                {
                    persona
                };
               
                Persona persona1 = new Persona();
                persona1.Nombre = "sujeto3";
                persona1.Edad = 10;
                persona1.Nacimiento = new DateTime(2012,01,02);
                lista.Add(persona1);             
                

                db.Persona.AddRange(lista);
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
        public ActionResult Edit([Bind(Include = "Id,Nombre,Nacimiento,Edad")] Persona persona)
        {
            //Metodo 1 : Trae El objeto y lo actualiza
            var PersonaEditar = db.Persona.FirstOrDefault(x =>x.Id==11);
            PersonaEditar.Nombre = "Christian Jhonnatan Morales";
            PersonaEditar.Edad = PersonaEditar.Edad + 1;
            db.SaveChanges();
           


            //metodo 2 : Actualizacion parcial
            var PersonaEditar2 = new Persona();
            PersonaEditar2.Id = 12;
            PersonaEditar2.Nombre = "Guillermo Gonzalo Morales Mandamiento";
            PersonaEditar2.Edad = 120;
            db.Persona.Attach(PersonaEditar2);
            db.Entry(PersonaEditar2).Property(y => y.Nombre).IsModified = true;
            db.SaveChanges();



            //metodo 3 : Objeto externo actualizado (parametro persona)

           
                db.Entry(persona).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            
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
            Persona persona = new Persona();
            persona = db.Persona.Find(id);
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
