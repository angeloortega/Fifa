using System;
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
            Calendar cal = new Calendar();
            cal.anho = torneo.anho;
            cal.idCompeticion = torneo.idCompeticion;
            return View(cal);
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

        public ActionResult RefereePerformance(decimal id, decimal id2)
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

        public ActionResult PlayerPerformance(decimal id, decimal id2)
        {
            if (id == null || id2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelectList nombreClubes = new SelectList(from a in db.TorneoXClub
                                                        where (a.idCompeticion == id && a.anho == id2)
                                                        join b in db.Club on a.idClub equals b.idClub
                                                        select b.nombre);
            ViewBag.idClub = new SelectList(db.TorneoXClub.Where(e =>  e.idCompeticion== id), "idClub", "idClub");
            ViewBag.codigoFuncionario = new SelectList(db.Funcionario.Where(e => e.idClub == 0), "codigoFuncionario", "codigoFuncionario");
            FuncionarioXClubXTorneo funcionario = new FuncionarioXClubXTorneo();
            funcionario.idCompeticion = id;
            funcionario.anho = id2;
            return View(funcionario); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PlayerPerformance([Bind(Include = "idCompeticion,anho,idClub,codigoFuncionario,sinopsisRendimiento,usuarioModificacion")] FuncionarioXClubXTorneo funcionario)
        {
            FuncionarioXClubXTorneo funcionarioOut = db.FuncionarioXClubXTorneo.Find(funcionario.codigoFuncionario, funcionario.idClub,funcionario.idCompeticion,funcionario.anho);
            funcionario.usuarioCreacion = funcionarioOut.usuarioCreacion;
            funcionario.fchCreacion = funcionarioOut.fchCreacion;
            funcionario.posicionTabla = funcionarioOut.posicionTabla;
            funcionario.fchModificacion = DateTime.Now;
            if (ModelState.IsValid)
            {
                var newContext = new FootballEntities();
                newContext.Entry(funcionario).State = EntityState.Modified;
                newContext.SaveChanges();
                return RedirectToAction("Index");
            }
            SelectList nombreClubes = new SelectList(from a in db.TorneoXClub
                                                     where (a.idCompeticion == funcionario.idCompeticion && a.anho == funcionario.anho)
                                                     join b in db.Club on a.idClub equals b.idClub
                                                     select b.nombre);
            ViewBag.idClub = nombreClubes;
            ViewBag.codigoFuncionario = new SelectList(db.Funcionario.Where(e => e.idClub == 1), "codigoFuncionario", "nombre");
            return View(funcionario);
        }

        [HttpPost]
        public ActionResult CambioClub(decimal id)
        {
            //ViewBag.equipoVisita = new SelectList(db.Club, "idClub", "nombre", model.equipoVisita);
            //ViewBag.equipoCasa = new SelectList(db.Club, "idClub", "nombre", model.equipoCasa);
            //ViewBag.idCompeticion = new SelectList(db.Torneo, "idCompeticion", "idCompeticion", model.idCompeticion);
            var lista = from a in db.Funcionario
                        where a.idClub == id
                        select a.codigoFuncionario;

            //SelectList result = new SelectList(db.Funcionario.Where(e => e.idClub == 1), "codigoFuncionario", "nombre");

            return Json(lista);
        }

        // GET: Torneos/Create
        public ActionResult Create()
        {
            ViewBag.idCompeticion = new SelectList(db.Competicion, "IdCompeticion", "nombre");
            return View();
        }

        // POST: Torneos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCompeticion,anho,usuarioCreacion")] Torneo torneo)
        {
            if(ModelState.IsValid)
            {
                torneo.fchCreacion = DateTime.Now;
                db.Torneo.Add(torneo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCompeticion = new SelectList(db.Competicion, "IdCompeticion", "nombre", torneo.idCompeticion);
            return View(torneo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Calendar(Calendar calendario)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlCommand(
                "EXEC FIFA.sorteoTabla @idCampeonato, @anho, @fchInicio",
                new SqlParameter("@idCampeonato", calendario.idCompeticion),
                new SqlParameter("@anho", calendario.anho),
                new SqlParameter("@fchInicio", calendario.fchInicio));
                return RedirectToAction("Index");
            }

            ViewBag.idCompeticion = new SelectList(db.Competicion, "IdCompeticion", "IdCompeticion", calendario.idCompeticion);
            return View(calendario);
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
        public ActionResult Edit([Bind(Include = "idCompeticion,anho,usuarioModificacion")] Torneo torneo)
        {
            
            if (ModelState.IsValid)
            {
                Torneo torneoOut = db.Torneo.Find(torneo.idCompeticion, torneo.anho);
                torneo.usuarioCreacion = torneoOut.usuarioCreacion;
                torneo.fchCreacion = torneoOut.fchCreacion;
                torneo.fchModificacion = DateTime.Now;
                var newContext = new FootballEntities();
                newContext.Entry(torneo).State = EntityState.Modified;
                newContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCompeticion = new SelectList(db.Competicion, "IdCompeticion", "nbrCompeticion", torneo.idCompeticion);
            //ViewBag.anho = new SelectList(db.Competicion, "anho", "anho", torneo.anho);
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
            var query = from m in db.FechaTorneo
                        where m.nroFecha == torneo.nroFecha && m.idCompeticion == torneo.idCompeticion && m.anho == torneo.anho
                        select m.nroFecha;
                        
            if (ModelState.IsValid && query.ToList().Count == 0)
            {
                db.FechaTorneo.Add(torneo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            ViewBag.idCompeticion = new SelectList(db.Competicion, "IdCompeticion", "nbrCompeticion", torneo.idCompeticion);
            return View(torneo);
        }

        public ActionResult AddTeam(decimal id, decimal id2)
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
            ViewBag.idClub = new SelectList(db.Club, "idClub", "nombre");
            TorneoXClub variable = new TorneoXClub();
            variable.idCompeticion = id;
            variable.anho = id2;
            return View(variable);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTeam([Bind(Include ="idClub, idCompeticion, anho, usuarioCreacion, usuarioModificacion, fchCreacion, fchModificacion")] TorneoXClub torneoxclub)
        {
            if (ModelState.IsValid)
            {

                db.TorneoXClub.Add(torneoxclub);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idClub = new SelectList(db.Club, "idClub", "nombre");
            return View(torneoxclub);
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
