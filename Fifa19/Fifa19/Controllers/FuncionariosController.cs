using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Fifa19.Models;

namespace Fifa19.Controllers
{
    public class FuncionariosController : Controller
    {
        private FootballEntities db = new FootballEntities();

        public async Task<ActionResult> Index(string search)
        {
            var funcionario = from m in db.Funcionario
                       select m;
            if (!String.IsNullOrEmpty(search))
            {
                funcionario = funcionario.Where(s => s.Club.nombre.Contains(search) || s.nombre.Contains(search));
            }
            return View(await funcionario.ToListAsync());
        }

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
        public ActionResult CreatePlayer()
        {
            ViewBag.idClub = new SelectList(db.Club, "idClub", "nombre");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePlayer([Bind(Include = "Funcionario.nombre,Funcionario.fchNacimiento,Funcionario.idClub,usuarioCreacion")] Funcionario funcionario, [Bind(Include = "Peso,Altura,nroCamiseta")] Jugador jugador, HttpPostedFileBase file)
        {
            var last = (from m in db.Funcionario
                        select m.codigoFuncionario).Max();

            if (ModelState.IsValid)
            {
                funcionario.codigoFuncionario = last + 1;
                jugador.codigoFuncionario = last + 1;
                jugador.usuarioCreacion = funcionario.usuarioCreacion;
                funcionario.fchCreacion = DateTime.Now;
                jugador.fchCreacion = DateTime.Now;
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Resources/")
                                                          + file.FileName);
                    funcionario.foto = file.FileName;
                }
                //db.Funcionario.Add(funcionario);
                //db.SaveChanges();
                db.Jugador.Add(jugador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idClub = new SelectList(db.Club, "idClub", "nombre", funcionario.idClub);
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
            ViewBag.idClub = new SelectList(db.Club, "idClub", "idClub", funcionario.idClub);
            ViewBag.codigoFuncionario = new SelectList(db.Entrenador, "codigoFuncionario", "nombre", funcionario.codigoFuncionario);
            ViewBag.codigoFuncionario = new SelectList(db.Jugador, "codigoFuncionario", "usuarioCreacion", funcionario.codigoFuncionario);
            return View(funcionario);
        }

        // POST: Funcionarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "codigoFuncionario,nombre,fchNacimiento,idClub,foto,usuarioModificacion")] Funcionario funcionario, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Resources/")
                                                          + file.FileName);
                    funcionario.foto = file.FileName;
                }
                Funcionario funcionarioOut = db.Funcionario.Find(funcionario.codigoFuncionario);
                funcionario.usuarioCreacion = funcionarioOut.usuarioCreacion;
                funcionario.fchCreacion = funcionarioOut.fchCreacion;
                funcionario.fchModificacion = DateTime.Now;
                var newContext = new FootballEntities();
                newContext.Entry(funcionario).State = EntityState.Modified;
                newContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idClub = new SelectList(db.Club, "idClub", "idClub", funcionario.idClub);
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
