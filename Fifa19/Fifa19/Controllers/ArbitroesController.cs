﻿using System;
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
    public class ArbitroesController : Controller
    {
        private FootballEntities db = new FootballEntities();

        // GET: Arbitroes
        public ActionResult Index()
        {
            return View(db.Arbitro.ToList());
        }

        // GET: Arbitroes/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arbitro arbitro = db.Arbitro.Find(id);
            if (arbitro == null)
            {
                return HttpNotFound();
            }
            return View(arbitro);
        }

        // GET: Arbitroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Arbitroes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idArbitro,categoria,nombre,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] Arbitro arbitro)
        {
            if (ModelState.IsValid)
            {
                db.Arbitro.Add(arbitro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(arbitro);
        }

        // GET: Arbitroes/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arbitro arbitro = db.Arbitro.Find(id);
            if (arbitro == null)
            {
                return HttpNotFound();
            }
            return View(arbitro);
        }

        // POST: Arbitroes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idArbitro,categoria,nombre,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] Arbitro arbitro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(arbitro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(arbitro);
        }

        // GET: Arbitroes/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Arbitro arbitro = db.Arbitro.Find(id);
            if (arbitro == null)
            {
                return HttpNotFound();
            }
            return View(arbitro);
        }

        // POST: Arbitroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Arbitro arbitro = db.Arbitro.Find(id);
            db.Arbitro.Remove(arbitro);
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
