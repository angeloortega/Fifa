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
    public class CompeticionsController : Controller
    {
        private FootballEntities db = new FootballEntities();

        // GET: Competicions
        public ActionResult Index()
        {
            var competicion = db.Competicion.Include(c => c.Federacion);
            return View(competicion.ToList());
        }

        // GET: Competicions/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competicion competicion = db.Competicion.Find(id);
            if (competicion == null)
            {
                return HttpNotFound();
            }
            return View(competicion);
        }

        // GET: Competicions/Create
        public ActionResult Create()
        {
            ViewBag.idFederacion = new SelectList(db.Federacion, "idFederacion", "nombre");
            return View();
        }

        // POST: Competicions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdCompeticion,idFederacion,nbrCompeticion,tipo,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] Competicion competicion)
        {
            if (ModelState.IsValid)
            {
                db.Competicion.Add(competicion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFederacion = new SelectList(db.Federacion, "idFederacion", "nombre", competicion.idFederacion);
            return View(competicion);
        }

        // GET: Competicions/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competicion competicion = db.Competicion.Find(id);
            if (competicion == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFederacion = new SelectList(db.Federacion, "idFederacion", "nombre", competicion.idFederacion);
            return View(competicion);
        }

        // POST: Competicions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdCompeticion,idFederacion,nbrCompeticion,tipo,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] Competicion competicion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competicion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFederacion = new SelectList(db.Federacion, "idFederacion", "nombre", competicion.idFederacion);
            return View(competicion);
        }

        // GET: Competicions/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competicion competicion = db.Competicion.Find(id);
            if (competicion == null)
            {
                return HttpNotFound();
            }
            return View(competicion);
        }

        // POST: Competicions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Competicion competicion = db.Competicion.Find(id);
            db.Competicion.Remove(competicion);
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
