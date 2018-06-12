﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fifa19.Models;

namespace Fifa19.Controllers
{
    public class TorneosController : Controller
    {
        private FootballEntities db = new FootballEntities();

        // GET: Torneos
        public ActionResult Index()
        {
            var torneo = db.Torneo.Include(t => t.Competicion);
            return View(torneo.ToList());
        }

        public ActionResult Simulation(decimal id, decimal id2)
        {
            if (id == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo torneo = db.Torneo.Find(id, id2);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            SqlParameter p1 = new SqlParameter("@idCompetencia", id);
            SqlParameter p2 = new SqlParameter("@anho", id2);
            db.Database.ExecuteSqlCommand("exec FIFA.sp_simulacion @idCompetencia, @anho", p1, p2); 
            return View(torneo);
        }

        public ActionResult Calendar(decimal id, decimal id2)
        {
            if (id == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo torneo = db.Torneo.Find(id, id2);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            return View(torneo);
        }
        public ActionResult GenerateCalendar(decimal id, decimal id2, DateTime id3)
        {
            if (id == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo torneo = db.Torneo.Find(id, id2);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            SqlParameter p1 = new SqlParameter("@idCampeonato", id);
            SqlParameter p2 = new SqlParameter("@anho", id2);
            SqlParameter p3 = new SqlParameter("@fchInicio", id3);
            db.Database.ExecuteSqlCommand("exec FIFA.sp_simulacion @idCampeonato, @anho, @fchInicio", p1, p2, p3);
            return View();
        }


        // GET: Torneos/Details/5
        public ActionResult Details(decimal id, decimal id2)
        {
            if (id == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo torneo = db.Torneo.Find(id, id2);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            return View(torneo);
        }

        public ActionResult Performance(decimal id, decimal id2)
        {
            if (id == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo torneo = db.Torneo.Find(id, id2);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            SqlParameter p1 = new SqlParameter("@idCampeonato", id);
            SqlParameter p2 = new SqlParameter("@anho", id2);
            var lista = db.Database.SqlQuery<sp_desempenhoArbitroTorneo_Result>("exec FIFA.sp_desempenhoArbitroTorneo @idCampeonato, @anho", p1, p2);
            return View(lista.ToList());
        }

        // GET: Torneos/Create
        public ActionResult Create()
        {
            ViewBag.idCompeticion = new SelectList(db.Competicion, "IdCompeticion", "IdCompeticion");
            return View();
        }

        // POST: Torneos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCompeticion,anho,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] Torneo torneo)
        {
            if (ModelState.IsValid)
            {
                db.Torneo.Add(torneo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCompeticion = new SelectList(db.Competicion, "IdCompeticion", "IdCompeticion", torneo.idCompeticion);
            return View(torneo);
        }

        public ActionResult Positions(decimal id, decimal id2)
        {
            if (id == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo torneo = db.Torneo.Find(id, id2);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            SqlParameter p1 = new SqlParameter("@idCampeonato", id);
            SqlParameter p2 = new SqlParameter("@anho", id2);
            var lista = db.Database.SqlQuery<sp_generarTablaPosiciones_Result>("exec FIFA.sp_generarTablaPosiciones @idCampeonato, @anho", p1, p2);
            List<posConColores> posiciones = new List<posConColores>();
            int i = 1;
            var iterate = lista.ToList();
            int amount = iterate.Count;
            foreach (var p in iterate)
            {
                posiciones.Add(new posConColores(p,i,amount));
                i++;
            }
            return View(posiciones);
        }

        // GET: Torneos/Edit/5
        public ActionResult Edit(decimal id, decimal id2)
        {
            if (id == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo torneo = db.Torneo.Find(id, id2);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCompeticion = new SelectList(db.Competicion, "IdCompeticion", "nbrCompeticion", torneo.idCompeticion);
            ViewBag.anho = new SelectList(db.Competicion, "anho", "anho", torneo.anho);
            return View(torneo); 
        }

        // POST: Torneos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCompeticion,anho,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] Torneo torneo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(torneo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCompeticion = new SelectList(db.Competicion, "IdCompeticion", "nbrCompeticion", torneo.idCompeticion);
            ViewBag.anho = new SelectList(db.Competicion, "anho", "anho", torneo.anho);
            return View(torneo);
        }

        // GET: Torneos/Delete/5
        public ActionResult Delete(decimal id, decimal id2)
        {
            if (id == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Torneo torneo = db.Torneo.Find(id, id2);
            if (torneo == null)
            {
                return HttpNotFound();
            }
            return View(torneo);
        }

        public ActionResult AddFecha(decimal id, decimal id2)
        {
            if (id == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FechaTorneo torneo = new FechaTorneo();
            torneo.idCompeticion = id;
            torneo.anho = id2;
            if (torneo == null)
            {
                return HttpNotFound();
            }

            return View(torneo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFecha([Bind(Include = "idCompeticion,anho,nroFecha,usuarioCreacion,fchCreacion,usuarioModificacion,fchModificacion")] FechaTorneo torneo)
        {
            if (ModelState.IsValid && !db.FechaTorneo.Contains(new FechaTorneo { idCompeticion = torneo.idCompeticion , anho = torneo.anho , nroFecha =torneo.nroFecha}))
            {
                db.FechaTorneo.Add(torneo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.idCompeticion = new SelectList(db.Competicion, "IdCompeticion", "nbrCompeticion", torneo.idCompeticion);
            return View(torneo);
        }

        // POST: Torneos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id, decimal id2)
        {
            Torneo torneo = db.Torneo.Find(id, id2);
            db.Torneo.Remove(torneo);
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
