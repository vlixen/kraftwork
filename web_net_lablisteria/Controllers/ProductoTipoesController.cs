using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LaBlisteria.Models;

namespace LaBlisteria.Controllers
{
    public class ProductoTipoesController : Controller
    {
        private LaBlisteriaContext db = new LaBlisteriaContext();

        // GET: ProductoTipoes
        public ActionResult Index()
        {
            return View(db.ProductoTipoes.ToList());
        }

        // GET: ProductoTipoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoTipo productoTipo = db.ProductoTipoes.Find(id);
            if (productoTipo == null)
            {
                return HttpNotFound();
            }
            return View(productoTipo);
        }

        // GET: ProductoTipoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoTipoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductoTipoID,ProductoTipoNombre")] ProductoTipo productoTipo)
        {
            if (ModelState.IsValid)
            {
                db.ProductoTipoes.Add(productoTipo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productoTipo);
        }

        // GET: ProductoTipoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoTipo productoTipo = db.ProductoTipoes.Find(id);
            if (productoTipo == null)
            {
                return HttpNotFound();
            }
            return View(productoTipo);
        }

        // POST: ProductoTipoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductoTipoID,ProductoTipoNombre")] ProductoTipo productoTipo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productoTipo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productoTipo);
        }

        // GET: ProductoTipoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductoTipo productoTipo = db.ProductoTipoes.Find(id);
            if (productoTipo == null)
            {
                return HttpNotFound();
            }
            return View(productoTipo);
        }

        // POST: ProductoTipoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductoTipo productoTipo = db.ProductoTipoes.Find(id);
            db.ProductoTipoes.Remove(productoTipo);
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
