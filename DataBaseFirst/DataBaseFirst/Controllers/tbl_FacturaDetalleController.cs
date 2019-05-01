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
    public class tbl_FacturaDetalleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tbl_FacturaDetalle
        public ActionResult Index()
        {
            var tbl_FacturaDetalle = db.tbl_FacturaDetalle.Include(t => t.tbl_FacturaCabecera).Include(t => t.tbl_Producto);
            return View(tbl_FacturaDetalle.ToList());
        }

        // GET: tbl_FacturaDetalle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_FacturaDetalle tbl_FacturaDetalle = db.tbl_FacturaDetalle.Find(id);
            if (tbl_FacturaDetalle == null)
            {
                return HttpNotFound();
            }
            return View(tbl_FacturaDetalle);
        }

        // GET: tbl_FacturaDetalle/Create
        public ActionResult Create()
        {
            ViewBag.IdFacturaCabecera = new SelectList(db.tbl_FacturaCabecera, "IdFacturaCabecera", "IdCliente");
            ViewBag.IdProducto = new SelectList(db.tbl_Producto, "IdProducto", "Codigo");
            return View();
        }

        // POST: tbl_FacturaDetalle/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdFacturaDetalle,IdFacturaCabecera,IdProducto,Cantidad,PrecioUnitario,Total")] tbl_FacturaDetalle tbl_FacturaDetalle)
        {
            if (ModelState.IsValid)
            {
                db.tbl_FacturaDetalle.Add(tbl_FacturaDetalle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdFacturaCabecera = new SelectList(db.tbl_FacturaCabecera, "IdFacturaCabecera", "IdCliente", tbl_FacturaDetalle.IdFacturaCabecera);
            ViewBag.IdProducto = new SelectList(db.tbl_Producto, "IdProducto", "Codigo", tbl_FacturaDetalle.IdProducto);
            return View(tbl_FacturaDetalle);
        }

        // GET: tbl_FacturaDetalle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_FacturaDetalle tbl_FacturaDetalle = db.tbl_FacturaDetalle.Find(id);
            if (tbl_FacturaDetalle == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdFacturaCabecera = new SelectList(db.tbl_FacturaCabecera, "IdFacturaCabecera", "IdCliente", tbl_FacturaDetalle.IdFacturaCabecera);
            ViewBag.IdProducto = new SelectList(db.tbl_Producto, "IdProducto", "Codigo", tbl_FacturaDetalle.IdProducto);
            return View(tbl_FacturaDetalle);
        }

        // POST: tbl_FacturaDetalle/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdFacturaDetalle,IdFacturaCabecera,IdProducto,Cantidad,PrecioUnitario,Total")] tbl_FacturaDetalle tbl_FacturaDetalle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_FacturaDetalle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdFacturaCabecera = new SelectList(db.tbl_FacturaCabecera, "IdFacturaCabecera", "IdCliente", tbl_FacturaDetalle.IdFacturaCabecera);
            ViewBag.IdProducto = new SelectList(db.tbl_Producto, "IdProducto", "Codigo", tbl_FacturaDetalle.IdProducto);
            return View(tbl_FacturaDetalle);
        }

        // GET: tbl_FacturaDetalle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_FacturaDetalle tbl_FacturaDetalle = db.tbl_FacturaDetalle.Find(id);
            if (tbl_FacturaDetalle == null)
            {
                return HttpNotFound();
            }
            return View(tbl_FacturaDetalle);
        }

        // POST: tbl_FacturaDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_FacturaDetalle tbl_FacturaDetalle = db.tbl_FacturaDetalle.Find(id);
            db.tbl_FacturaDetalle.Remove(tbl_FacturaDetalle);
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
