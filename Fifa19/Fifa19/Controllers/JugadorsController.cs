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
using PagedList;

namespace Fifa19.Controllers
{
    public class JugadorsController : Controller
    {
        private FootballEntities db = new FootballEntities();

        // GET: Jugadors
        public ViewResult Index(string sortOrder, string currentFilter, string search, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            
            if (search != null)
            {
                page = 1;
            }
            else
            {
                search = currentFilter;
            }

            ViewBag.CurrentFilter = search;

            var player = from m in db.Jugador
                       select m;

            if (!String.IsNullOrEmpty(search))
            {
                player = player.Where(s => s.Funcionario.nombre.Contains(search));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    player = player.OrderByDescending(s => s.Funcionario.nombre);
                    break;
                default:
                    player = player.OrderBy(s => s.Funcionario.nombre);
                    break;
            }
            int pageSize = 50;
            int pageNumber = (page ?? 1);
            return View(player.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult HistorialEquipos(decimal id)
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
            var lista = db.Database.SqlQuery<sp_obtenerListaEquiposJugador_Result>("exec FIFA.sp_obtenerListaEquiposJugador @codigoFuncionario", p1);
            return View(lista.ToList());
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
            ViewBag.codigoFuncionario = new SelectList(db.Funcionario, "codigoFuncionario", "idClub");
            
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
            Funcionario funcionario = db.Funcionario.Find(id);
            if (jugador == null)
            {
                return HttpNotFound();
            }
            ViewBag.codigoFuncionario = new SelectList(db.Funcionario, "codigoFuncionario", "nombre", jugador.codigoFuncionario);
            ViewBag.idClub = new SelectList(db.Club, "idClub", "nombre", funcionario.idClub);
            return View(jugador);
        }

        // POST: Jugadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoFuncionario,Peso,Altura,nroCamiseta,usuarioModificacion")] Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                Jugador jugadorOut = db.Jugador.Find(jugador.codigoFuncionario);
                jugador.usuarioCreacion = jugadorOut.usuarioCreacion;
                jugador.fchCreacion = jugadorOut.fchCreacion;
                jugador.fchModificacion = DateTime.Now;
                var newContext = new FootballEntities();
                newContext.Entry(jugador).State = EntityState.Modified;
                newContext.SaveChanges();
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
