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
    public class FederacionsController : Controller
    {
        private FootballEntities db = new FootballEntities();

        // GET: Federacions
        public ActionResult Index()
        {
            return View(db.Federacion.ToList());
        }

        // GET: Federacions/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Federacion federacion = db.Federacion.Find(id);
            if (federacion == null)
            {
                return HttpNotFound();
            }
            return View(federacion);
        }

        // GET: Federacions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Federacions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFederacion,nombre,fchFundacion,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] Federacion federacion)
        {
            if (ModelState.IsValid)
            {
                db.Federacion.Add(federacion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(federacion);
        }

        // GET: Federacions/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Federacion federacion = db.Federacion.Find(id);
            if (federacion == null)
            {
                return HttpNotFound();
            }
            return View(federacion);
        }

        // POST: Federacions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idFederacion,nombre,fchFundacion,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] Federacion federacion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(federacion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(federacion);
        }

        // GET: Federacions/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Federacion federacion = db.Federacion.Find(id);
            if (federacion == null)
            {
                return HttpNotFound();
            }
            return View(federacion);
        }

        // POST: Federacions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Federacion federacion = db.Federacion.Find(id);
            db.Federacion.Remove(federacion);
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
