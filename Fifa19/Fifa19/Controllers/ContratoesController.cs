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
    public class ContratoesController : Controller
    {
        private FootballEntities db = new FootballEntities();

        // GET: Contratoes
        public ActionResult Index()
        {
            var contrato = db.Contrato.Include(c => c.Club).Include(c => c.Funcionario);
            return View(contrato.ToList());
        }

        // GET: Contratoes/Details/5
        public ActionResult Details(decimal id, decimal id2, DateTime id3)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id, id2, id3);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // GET: Contratoes/Create
        public ActionResult Create()
        {
            ViewBag.idClub = new SelectList(db.Club, "idClub", "nombre");
            ViewBag.codigoFuncionario = new SelectList(db.Funcionario, "codigoFuncionario", "codigoFuncionario");
            return View();
        }

        // POST: Contratoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idClub,codigoFuncionario,importe,fchInicio,fchFinProgramado,fchFinReal,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Contrato.Add(contrato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idClub = new SelectList(db.Club, "idClub", "nombre", contrato.idClub);
            ViewBag.codigoFuncionario = new SelectList(db.Funcionario, "codigoFuncionario", "nombre", contrato.codigoFuncionario);
            return View(contrato);
        }

        // GET: Contratoes/Edit/5
        public ActionResult Edit(decimal id, decimal id2, DateTime id3)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id, id2, id3);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            ViewBag.idClub = new SelectList(db.Club, "idClub", "nombre", contrato.idClub);
            ViewBag.codigoFuncionario = new SelectList(db.Funcionario, "codigoFuncionario", "nombre", contrato.codigoFuncionario);
            return View(contrato);
        }

        // POST: Contratoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idClub,codigoFuncionario,importe,fchInicio,fchFinProgramado,fchFinReal,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contrato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idClub = new SelectList(db.Club, "idClub", "nombre", contrato.idClub);
            ViewBag.codigoFuncionario = new SelectList(db.Funcionario, "codigoFuncionario", "nombre", contrato.codigoFuncionario);
            return View(contrato);
        }

        // GET: Contratoes/Delete/5
        public ActionResult Delete(decimal id, decimal id2, DateTime id3)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contrato contrato = db.Contrato.Find(id, id2, id3);
            if (contrato == null)
            {
                return HttpNotFound();
            }
            return View(contrato);
        }

        // POST: Contratoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id, decimal id2, DateTime id3)
        {
            Contrato contrato = db.Contrato.Find(id, id2, id3);
            db.Contrato.Remove(contrato);
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
