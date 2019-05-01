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
    public class tbl_ProductoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tbl_Producto
        public ActionResult Index()
        {
            return View(db.tbl_Producto.ToList());
        }

        // GET: tbl_Producto/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Producto tbl_Producto = db.tbl_Producto.Find(id);
            if (tbl_Producto == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Producto);
        }

        // GET: tbl_Producto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tbl_Producto/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdProducto,Codigo,Descripcion,PrecioUnitario")] tbl_Producto tbl_Producto)
        {
            if (ModelState.IsValid)
            {
                db.tbl_Producto.Add(tbl_Producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tbl_Producto);
        }

        // GET: tbl_Producto/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Producto tbl_Producto = db.tbl_Producto.Find(id);
            if (tbl_Producto == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Producto);
        }

        // POST: tbl_Producto/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdProducto,Codigo,Descripcion,PrecioUnitario")] tbl_Producto tbl_Producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_Producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_Producto);
        }

        // GET: tbl_Producto/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_Producto tbl_Producto = db.tbl_Producto.Find(id);
            if (tbl_Producto == null)
            {
                return HttpNotFound();
            }
            return View(tbl_Producto);
        }

        // POST: tbl_Producto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            tbl_Producto tbl_Producto = db.tbl_Producto.Find(id);
            db.tbl_Producto.Remove(tbl_Producto);
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
