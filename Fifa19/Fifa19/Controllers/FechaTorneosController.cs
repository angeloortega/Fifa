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
    public class FechaTorneosController : Controller
    {
        private FootballEntities db = new FootballEntities();

        // GET: FechaTorneos
        public ActionResult Index()
        {
            var fechaTorneo = db.FechaTorneo.Include(f => f.Torneo);
            return View(fechaTorneo.ToList());
        }

        // GET: FechaTorneos/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FechaTorneo fechaTorneo = db.FechaTorneo.Find(id);
            if (fechaTorneo == null)
            {
                return HttpNotFound();
            }
            return View(fechaTorneo);
        }

        // GET: FechaTorneos/Create
        public ActionResult Create()
        {
            ViewBag.idCompeticion = new SelectList(db.Torneo, "idCompeticion", "idCompeticion");
            return View();
        }

        // POST: FechaTorneos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCompeticion,anho,nroFecha,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] FechaTorneo fechaTorneo)
        {
            if (ModelState.IsValid)
            {
                db.FechaTorneo.Add(fechaTorneo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCompeticion = new SelectList(db.Torneo, "idCompeticion", "usuarioCreacion", fechaTorneo.idCompeticion);
            return View(fechaTorneo);
        }

        // GET: FechaTorneos/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FechaTorneo fechaTorneo = db.FechaTorneo.Find(id);
            if (fechaTorneo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCompeticion = new SelectList(db.Torneo, "idCompeticion", "usuarioCreacion", fechaTorneo.idCompeticion);
            return View(fechaTorneo);
        }

        // POST: FechaTorneos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCompeticion,anho,nroFecha,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] FechaTorneo fechaTorneo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fechaTorneo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCompeticion = new SelectList(db.Torneo, "idCompeticion", "usuarioCreacion", fechaTorneo.idCompeticion);
            return View(fechaTorneo);
        }

        // GET: FechaTorneos/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FechaTorneo fechaTorneo = db.FechaTorneo.Find(id);
            if (fechaTorneo == null)
            {
                return HttpNotFound();
            }
            return View(fechaTorneo);
        }

        // POST: FechaTorneos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            FechaTorneo fechaTorneo = db.FechaTorneo.Find(id);
            db.FechaTorneo.Remove(fechaTorneo);
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
