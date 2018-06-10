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
    public class JugadorsController : Controller
    {
        private FootballEntities db = new FootballEntities();

        // GET: Jugadors
        public ActionResult Index()
        {
            var jugador = db.Jugador.Include(j => j.Funcionario);
            return View(jugador.ToList());
        }

        // GET: Jugadors/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jugador jugador = db.Jugador.Find(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            return View(jugador);
        }

        // GET: Jugadors/Create
        public ActionResult Create()
        {
            ViewBag.codigoFuncionario = new SelectList(db.Funcionario, "codigoFuncionario", "nombre");
            return View();
        }

        // POST: Jugadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoFuncionario,Peso,Altura,nroCamiseta,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                db.Jugador.Add(jugador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigoFuncionario = new SelectList(db.Funcionario, "codigoFuncionario", "nombre", jugador.codigoFuncionario);
            return View(jugador);
        }

        // GET: Jugadors/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jugador jugador = db.Jugador.Find(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigoFuncionario = new SelectList(db.Funcionario, "codigoFuncionario", "nombre", jugador.codigoFuncionario);
            return View(jugador);
        }

        // POST: Jugadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoFuncionario,Peso,Altura,nroCamiseta,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jugador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigoFuncionario = new SelectList(db.Funcionario, "codigoFuncionario", "nombre", jugador.codigoFuncionario);
            return View(jugador);
        }

        // GET: Jugadors/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jugador jugador = db.Jugador.Find(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            return View(jugador);
        }

        // POST: Jugadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Jugador jugador = db.Jugador.Find(id);
            db.Jugador.Remove(jugador);
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
