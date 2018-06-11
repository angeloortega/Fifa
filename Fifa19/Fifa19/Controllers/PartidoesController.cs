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
    public class PartidoesController : Controller
    {
        private FootballEntities db = new FootballEntities();

        // GET: Partidoes
        public ActionResult Index()
        {
            var partido = db.Partido.Include(p => p.Club).Include(p => p.Club1).Include(p => p.FechaTorneo);
            return View(partido.ToList());
        }

        // GET: Partidoes/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido partido = db.Partido.Find(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            return View(partido);
        }

        // GET: Partidoes/Create
        public ActionResult Create()
        {
            ViewBag.equipoVisita = new SelectList(db.Club, "idClub", "nombre");
            ViewBag.equipoCasa = new SelectList(db.Club, "idClub", "nombre");
            ViewBag.idCompeticion = new SelectList(db.Torneo, "idCompeticion", "idCompeticion");
            ViewBag.nroFecha = new SelectList(db.FechaTorneo.Where(e => e.idCompeticion == 1), "nroFecha", "nroFecha");
            return View();
        }

        // POST: Partidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPartido,idCompeticion,anho,nroFecha,equipoVisita,equipoCasa,fecha,golesCasa,golesVisita,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] Partido partido)
        {
            return RedirectToAction("Index");
            if (ModelState.IsValid)
            {
                db.Partido.Add(partido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.equipoVisita = new SelectList(db.Club, "idClub", "nombre", partido.equipoVisita);
            ViewBag.equipoCasa = new SelectList(db.Club, "idClub", "nombre", partido.equipoCasa);
            ViewBag.idCompeticion = new SelectList(db.Torneo, "idCompeticion", "idCompeticion", partido.idCompeticion);
            ViewBag.nroFecha = new SelectList(db.FechaTorneo.Where(e => e.idCompeticion == partido.idCompeticion), "nroFecha", "nroFecha");
            return View(partido);
        }

        [HttpPost]
        public ActionResult Partido(Partido model)
        {
            ViewBag.equipoVisita = new SelectList(db.Club, "idClub", "nombre", model.equipoVisita);
            ViewBag.equipoCasa = new SelectList(db.Club, "idClub", "nombre", model.equipoCasa);
            ViewBag.idCompeticion = new SelectList(db.Torneo, "idCompeticion", "idCompeticion", model.idCompeticion);
            ViewBag.nroFecha = new SelectList(db.FechaTorneo.Where(e => e.idCompeticion == model.idCompeticion), "nroFecha", "nroFecha");
            return View(model);
        }
        // GET: Partidoes/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido partido = db.Partido.Find(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            ViewBag.equipoVisita = new SelectList(db.Club, "idClub", "nombre", partido.equipoVisita);
            ViewBag.equipoCasa = new SelectList(db.Club, "idClub", "nombre", partido.equipoCasa);
            ViewBag.idCompeticion = new SelectList(db.FechaTorneo, "idCompeticion", "usuarioCreacion", partido.idCompeticion);
            return View(partido);
        }

        // POST: Partidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPartido,idCompeticion,anho,nroFecha,equipoVisita,equipoCasa,fecha,golesCasa,golesVisita,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] Partido partido)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partido).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.equipoVisita = new SelectList(db.Club, "idClub", "nombre", partido.equipoVisita);
            ViewBag.equipoCasa = new SelectList(db.Club, "idClub", "nombre", partido.equipoCasa);
            ViewBag.idCompeticion = new SelectList(db.FechaTorneo, "idCompeticion", "usuarioCreacion", partido.idCompeticion);
            return View(partido);
        }

        // GET: Partidoes/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido partido = db.Partido.Find(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            return View(partido);
        }

        // POST: Partidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Partido partido = db.Partido.Find(id);
            db.Partido.Remove(partido);
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
