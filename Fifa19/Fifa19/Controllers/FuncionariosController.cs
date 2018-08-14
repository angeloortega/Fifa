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
        public ActionResult Create()
        {
            ViewBag.idClub = new SelectList(db.Club, "idClub", "nombre");
            return View();
        }

        // POST: Funcionarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Funcionario funcionario, HttpPostedFileBase file)
        {
            var last = (from m in db.Funcionario
                        select m.codigoFuncionario).Max();
            funcionario.codigoFuncionario = last + 1;
            funcionario.fchCreacion = DateTime.Now;

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Resources/")
                                                          + file.FileName);
                    funcionario.foto = file.FileName;
                }
                db.Funcionario.Add(funcionario);
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

        public ActionResult Jugador(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jugador funcionario = new Jugador();
            funcionario.codigoFuncionario = id;

            return View(funcionario);
        }
        public ActionResult Entrenador(decimal id)
        {
            Funcionario original = db.Funcionario.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrenador funcionario = new Entrenador();
            funcionario.codigoFuncionario = id;
            funcionario.nombre = original.nombre;

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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Jugador(Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                jugador.fchCreacion = DateTime.Now;
                var newContext = new FootballEntities();
                db.Jugador.Add(jugador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jugador);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Entrenador(Entrenador entrenador)
        {
            if (ModelState.IsValid)
            {
                entrenador.fchCreacion = DateTime.Now;
                var newContext = new FootballEntities();
                db.Entrenador.Add(entrenador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entrenador);
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
