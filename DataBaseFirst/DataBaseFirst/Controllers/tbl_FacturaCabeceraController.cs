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
    public class tbl_FacturaCabeceraController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tbl_FacturaCabecera
        public ActionResult Index()
        {
            var tbl_FacturaCabecera = db.tbl_FacturaCabecera.Include(t => t.tbl_Clientes);
            return View(tbl_FacturaCabecera.ToList());
        }

        // GET: tbl_FacturaCabecera/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_FacturaCabecera tbl_FacturaCabecera = db.tbl_FacturaCabecera.Find(id);
            if (tbl_FacturaCabecera == null)
            {
                return HttpNotFound();
            }
            return View(tbl_FacturaCabecera);
        }

        // GET: tbl_FacturaCabecera/Create
        public ActionResult Create()
        {
            ViewBag.IdCliente = new SelectList(db.tbl_Clientes, "IdCliente", "Nombres");
            return View();
        }

        // POST: tbl_FacturaCabecera/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFacturaCabecera,IdCliente,Numero,Serie,Fecha,SubTotal,Impuestos,Total")] tbl_FacturaCabecera tbl_FacturaCabecera)
        {
            if (ModelState.IsValid)
            {
                db.tbl_FacturaCabecera.Add(tbl_FacturaCabecera);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdCliente = new SelectList(db.tbl_Clientes, "IdCliente", "Nombres", tbl_FacturaCabecera.IdCliente);
            return View(tbl_FacturaCabecera);
        }

        // GET: tbl_FacturaCabecera/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_FacturaCabecera tbl_FacturaCabecera = db.tbl_FacturaCabecera.Find(id);
            if (tbl_FacturaCabecera == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdCliente = new SelectList(db.tbl_Clientes, "IdCliente", "Nombres", tbl_FacturaCabecera.IdCliente);
            return View(tbl_FacturaCabecera);
        }

        // POST: tbl_FacturaCabecera/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFacturaCabecera,IdCliente,Numero,Serie,Fecha,SubTotal,Impuestos,Total")] tbl_FacturaCabecera tbl_FacturaCabecera)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_FacturaCabecera).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdCliente = new SelectList(db.tbl_Clientes, "IdCliente", "Nombres", tbl_FacturaCabecera.IdCliente);
            return View(tbl_FacturaCabecera);
        }

        // GET: tbl_FacturaCabecera/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_FacturaCabecera tbl_FacturaCabecera = db.tbl_FacturaCabecera.Find(id);
            if (tbl_FacturaCabecera == null)
            {
                return HttpNotFound();
            }
            return View(tbl_FacturaCabecera);
        }

        // POST: tbl_FacturaCabecera/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_FacturaCabecera tbl_FacturaCabecera = db.tbl_FacturaCabecera.Find(id);
            db.tbl_FacturaCabecera.Remove(tbl_FacturaCabecera);
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
