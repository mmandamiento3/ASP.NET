using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DataBaseFirst.Models;

namespace DataBaseFirst.Controllers
{
    public class tbl_ClientesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tbl_Clientes
        public ActionResult Index()
        {
            return View(db.tbl_Clientes.ToList());
        }

        // GET: tbl_Clientes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Clientes tbl_Clientes = db.tbl_Clientes.Find(id);
            if (tbl_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Clientes);
        }

        // GET: tbl_Clientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCliente,Nombres,Apellidos,Correo,Edad")] tbl_Clientes tbl_Clientes)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Clientes.Add(tbl_Clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Clientes);
        }

        // GET: tbl_Clientes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Clientes tbl_Clientes = db.tbl_Clientes.Find(id);
            if (tbl_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Clientes);
        }

        // POST: tbl_Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCliente,Nombres,Apellidos,Correo,Edad")] tbl_Clientes tbl_Clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Clientes);
        }

        // GET: tbl_Clientes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Clientes tbl_Clientes = db.tbl_Clientes.Find(id);
            if (tbl_Clientes == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Clientes);
        }

        // POST: tbl_Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_Clientes tbl_Clientes = db.tbl_Clientes.Find(id);
            db.tbl_Clientes.Remove(tbl_Clientes);
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
