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
    public class EntrenadorsController : Controller
    {
        private FootballEntities db = new FootballEntities();

        // GET: Entrenadors
        public ActionResult Index()
        {
            var entrenador = db.Entrenador.Include(e => e.Funcionario);
            return View(entrenador.ToList());
        }

        // GET: Entrenadors/Details/5
        public ActionResult Details(decimal id)
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
        public ActionResult Create([Bind(Include = "codigoFuncionario,nombre,fchInicioCarrera,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] Entrenador entrenador)
        {
            if (ModelState.IsValid)
            {
                db.Entrenador.Add(entrenador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigoFuncionario = new SelectList(db.Funcionario, "codigoFuncionario", "nombre", entrenador.codigoFuncionario);
            return View(entrenador);
        }

        // GET: Entrenadors/Edit/5
        public ActionResult Edit(decimal id)
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
            ViewBag.codigoFuncionario = new SelectList(db.Funcionario, "codigoFuncionario", "nombre", entrenador.codigoFuncionario);
            return View(entrenador);
        }

        // POST: Entrenadors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoFuncionario,nombre,fchInicioCarrera,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] Entrenador entrenador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrenador).State = EntityState.Modified;
                db.SaveChanges();
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
