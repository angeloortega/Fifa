﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Fifa19.Models;

namespace Fifa19.Controllers
{
    public class EntrenadorsController : Controller
    {
        private FootballEntities db = new FootballEntities();

        // GET: Entrenadors
        public async Task<ActionResult> Index(string search)
        {
            var coach = from m in db.Entrenador
                       select m;
            if (!String.IsNullOrEmpty(search))
            {
                coach = coach.Where(s => s.nombre.Contains(search));
            }
            return View(await coach.ToListAsync());
        }

        // GET: Entrenadors/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrenador entrenador = db.Entrenador.Find(id);
            if (entrenador == null)
            {
                return HttpNotFound();
            }
            return View(entrenador);
        }

        public ActionResult HistorialEntrenador(decimal id)
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
            SqlParameter p1 = new SqlParameter("@codigoFuncionario", id);
            var lista = db.Database.SqlQuery<sp_obtenerListaEquiposEntrenador_Result>("exec FIFA.sp_obtenerListaEquiposEntrenador @codigoFuncionario", p1);
            return View(lista.ToList());
        }

        // GET: Entrenadors/Create
        public ActionResult Create()
        {
            ViewBag.codigoFuncionario = new SelectList(db.Funcionario, "codigoFuncionario", "nombre");
            return View();
        }

        // POST: Entrenadors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre,fchInicioCarrera,usuarioCreacion")] Entrenador entrenador)
        {
            var last = (from m in db.Funcionario
                        select m.codigoFuncionario).Max();
            entrenador.codigoFuncionario = last + 1;
            if (ModelState.IsValid)
            {
                entrenador.fchCreacion = DateTime.Now;
                db.Entrenador.Add(entrenador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            //ViewBag.codigoFuncionario = new SelectList(db.Funcionario, "codigoFuncionario", "idClub", entrenador.codigoFuncionario);
            return View(entrenador);
        }

        // GET: Entrenadors/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrenador entrenador = db.Entrenador.Find(id);
            if (entrenador == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigoFuncionario = new SelectList(db.Funcionario, "codigoFuncionario", "nombre", entrenador.codigoFuncionario);
            return View(entrenador);
        }

        // POST: Entrenadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoFuncionario,nombre,fchInicioCarrera,usuarioModificacion")] Entrenador entrenador)
        {
            if (ModelState.IsValid)
            {
                Entrenador entrenadorOut = db.Entrenador.Find(entrenador.codigoFuncionario);
                entrenador.usuarioCreacion = entrenadorOut.usuarioCreacion;
                entrenador.fchCreacion = entrenadorOut.fchCreacion;
                entrenador.fchModificacion = DateTime.Now;
                var newContext = new FootballEntities();
                newContext.Entry(entrenador).State = EntityState.Modified;
                newContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.codigoFuncionario = new SelectList(db.Funcionario, "codigoFuncionario", "nombre", entrenador.codigoFuncionario);
            return View(entrenador);
        }

        // GET: Entrenadors/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrenador entrenador = db.Entrenador.Find(id);
            if (entrenador == null)
            {
                return HttpNotFound();
            }
            return View(entrenador);
        }

        // POST: Entrenadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Entrenador entrenador = db.Entrenador.Find(id);
            db.Entrenador.Remove(entrenador);
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
