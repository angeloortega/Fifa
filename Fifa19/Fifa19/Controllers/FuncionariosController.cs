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
    public class FuncionariosController : Controller
    {
        private FootballEntities db = new FootballEntities();

        // GET: Funcionarios
        public ActionResult Index()
        {
            var funcionario = db.Funcionario.Include(f => f.Club).Include(f => f.Entrenador).Include(f => f.Jugador);
            return View(funcionario.ToList());
        }

        // GET: Funcionarios/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // GET: Funcionarios/Create
        public ActionResult Create()
        {
            ViewBag.idClub = new SelectList(db.Club, "idClub", "nombre");
            ViewBag.codigoFuncionario = new SelectList(db.Entrenador, "codigoFuncionario", "nombre");
            ViewBag.codigoFuncionario = new SelectList(db.Jugador, "codigoFuncionario", "usuarioCreacion");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "codigoFuncionario,nombre,fchNacimiento,idClub,foto,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Funcionario.Add(funcionario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idClub = new SelectList(db.Club, "idClub", "nombre", funcionario.idClub);
            ViewBag.codigoFuncionario = new SelectList(db.Entrenador, "codigoFuncionario", "nombre", funcionario.codigoFuncionario);
            ViewBag.codigoFuncionario = new SelectList(db.Jugador, "codigoFuncionario", "usuarioCreacion", funcionario.codigoFuncionario);
            return View(funcionario);
        }

        // GET: Funcionarios/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idClub = new SelectList(db.Club, "idClub", "nombre", funcionario.idClub);
            ViewBag.codigoFuncionario = new SelectList(db.Entrenador, "codigoFuncionario", "nombre", funcionario.codigoFuncionario);
            ViewBag.codigoFuncionario = new SelectList(db.Jugador, "codigoFuncionario", "usuarioCreacion", funcionario.codigoFuncionario);
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoFuncionario,nombre,fchNacimiento,idClub,foto,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(funcionario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idClub = new SelectList(db.Club, "idClub", "nombre", funcionario.idClub);
            ViewBag.codigoFuncionario = new SelectList(db.Entrenador, "codigoFuncionario", "nombre", funcionario.codigoFuncionario);
            ViewBag.codigoFuncionario = new SelectList(db.Jugador, "codigoFuncionario", "usuarioCreacion", funcionario.codigoFuncionario);
            return View(funcionario);
        }

        // GET: Funcionarios/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Funcionario funcionario = db.Funcionario.Find(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Funcionario funcionario = db.Funcionario.Find(id);
            db.Funcionario.Remove(funcionario);
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
