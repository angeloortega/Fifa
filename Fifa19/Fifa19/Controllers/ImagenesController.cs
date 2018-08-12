using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fifa19.Models;

namespace Fifa19.Controllers
{
    public class ImagenesController : Controller
    {
        private FootballEntities db = new FootballEntities();

        // GET: Imagenes
        public ActionResult Index()
        {
            return View(db.Imagenes.ToList());
        }

        // GET: Imagenes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagenes imagenes = db.Imagenes.Find(id);
            if (imagenes == null)
            {
                return HttpNotFound();
            }
            return View(imagenes);
        }

        // GET: Imagenes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Imagenes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre,image_byte")] Imagenes imagenes)
        {
            if (ModelState.IsValid)
            {
                db.Imagenes.Add(imagenes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(imagenes);
        }

        // GET: Imagenes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagenes imagenes = db.Imagenes.Find(id);
            if (imagenes == null)
            {
                return HttpNotFound();
            }
            return View(imagenes);
        }

        // POST: Imagenes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nombre,image_byte")] Imagenes imagenes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagenes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imagenes);
        }

        // GET: Imagenes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagenes imagenes = db.Imagenes.Find(id);
            if (imagenes == null)
            {
                return HttpNotFound();
            }
            return View(imagenes);
        }

        // POST: Imagenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Imagenes imagenes = db.Imagenes.Find(id);
            db.Imagenes.Remove(imagenes);
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
