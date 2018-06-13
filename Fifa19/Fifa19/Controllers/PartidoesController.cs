using System;
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
    public class PartidoesController : Controller
    {
        private FootballEntities db = new FootballEntities();

        // GET: Partidoes
        public async Task<ActionResult> Index(string search)
        {
            var club = from m in db.Partido
                       select m;
            if (!String.IsNullOrEmpty(search))
            {
                club = club.Where(s => s.Club.nombre.Contains(search) || s.Club1.nombre.Contains(search) || s.FechaTorneo.Torneo.Competicion.nbrCompeticion.Contains(search));
            }
            return View(await club.ToListAsync());
        }

        public ActionResult MatchHistory(decimal idEquipo1, decimal idEquipo2, DateTime idFecha)
        {
            if (idEquipo1 == null || idEquipo2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SqlParameter p1 = new SqlParameter("@equipo1", idEquipo1);
            SqlParameter p2 = new SqlParameter("@equipo2", idEquipo2);
            SqlParameter p3 = new SqlParameter("@fechaInicio", idFecha);
            var lista = db.Database.SqlQuery<sp_obtenerEncuentrosHistoricos_Result>("exec FIFA.sp_obtenerEncuentrosHistoricos @equipo1, @equipo2, @fechaInicio", p1, p2, p3);
            return View(lista.ToList());
        }

        // GET: Partidoes/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido partido = db.Partido.Find(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            return View(partido);
        }

        // GET: Partidoes/Create
        public ActionResult Create()
        {
            ViewBag.equipoVisita = new SelectList(db.Club, "idClub", "nombre");
            ViewBag.equipoCasa = new SelectList(db.Club, "idClub", "nombre");
            ViewBag.idCompeticion = new SelectList(db.Torneo, "idCompeticion", "idCompeticion");
            ViewBag.nroFecha = new SelectList(db.FechaTorneo.Where(e => e.idCompeticion == 1), "nroFecha", "nroFecha");
            ViewBag.arbitro = new SelectList(db.Arbitro, "idArbitro", "nombre");
            return View();
        }

        // POST: Partidoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idPartido,idCompeticion,anho,nroFecha,equipoVisita,equipoCasa,fecha,golesCasa,golesVisita,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] Partido partido) //[Bind(Include ="ArbitroxPartido")] ArbitroxPartido arbitro)
        {
            var last = (from m in db.Partido
                       select m.idPartido).Max();
            if (ModelState.IsValid)
            {
                partido.idPartido = last + 1;
                //db.ArbitroxPartido.Add(arbitro);
                db.Partido.Add(partido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.equipoVisita = new SelectList(db.Club, "idClub", "nombre", partido.equipoVisita);
            ViewBag.equipoCasa = new SelectList(db.Club, "idClub", "nombre", partido.equipoCasa);
            ViewBag.idCompeticion = new SelectList(db.Torneo, "idCompeticion", "idCompeticion", partido.idCompeticion);
            ViewBag.nroFecha = new SelectList(db.FechaTorneo.Where(e => e.idCompeticion == partido.idCompeticion), "nroFecha", "nroFecha");
            ViewBag.arbitro = new SelectList(db.Arbitro, "idArbitro", "nombre");
            return View(partido);
        }

        [HttpPost]
        public ActionResult Partido(decimal id)
        {
            return RedirectToAction("Index");
            //ViewBag.equipoVisita = new SelectList(db.Club, "idClub", "nombre", model.equipoVisita);
            //ViewBag.equipoCasa = new SelectList(db.Club, "idClub", "nombre", model.equipoCasa);
            //ViewBag.idCompeticion = new SelectList(db.Torneo, "idCompeticion", "idCompeticion", model.idCompeticion);
            ViewBag.nroFecha = new SelectList(db.FechaTorneo.Where(e => e.idCompeticion == id), "nroFecha", "nroFecha");
            return View();
        }

        [HttpPost]
        public ActionResult Cambio(decimal id)
        {
            //ViewBag.equipoVisita = new SelectList(db.Club, "idClub", "nombre", model.equipoVisita);
            //ViewBag.equipoCasa = new SelectList(db.Club, "idClub", "nombre", model.equipoCasa);
            //ViewBag.idCompeticion = new SelectList(db.Torneo, "idCompeticion", "idCompeticion", model.idCompeticion);
            var lista = from m in db.FechaTorneo
                        where m.idCompeticion == id
                        select m.nroFecha;
                         

            return Json(lista);
        }
        // GET: Partidoes/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido partido = db.Partido.Find(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            ViewBag.equipoVisita = new SelectList(db.Club, "idClub", "nombre", partido.equipoVisita);
            ViewBag.equipoCasa = new SelectList(db.Club, "idClub", "nombre", partido.equipoCasa);
            ViewBag.idCompeticion = new SelectList(db.FechaTorneo, "idCompeticion", "usuarioCreacion", partido.idCompeticion);
            return View(partido);
        }

        // POST: Partidoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idPartido,anho,nroFecha,idCompeticon,equipoVisita,equipoCasa,fecha,golesCasa,golesVisita,usuarioModificacion")] Partido partido)
        {
            if (ModelState.IsValid)
            {
                Partido partidoOut = db.Partido.Find(partido.idPartido);
                partido.usuarioCreacion = partidoOut.usuarioCreacion;
                partido.fchCreacion = partidoOut.fchCreacion;
                partido.fchModificacion = DateTime.Now;
                var newContext = new FootballEntities();
                newContext.Entry(partido).State = EntityState.Modified;
                newContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.equipoVisita = new SelectList(db.Club, "idClub", "nombre", partido.equipoVisita);
            ViewBag.equipoCasa = new SelectList(db.Club, "idClub", "nombre", partido.equipoCasa);
            ViewBag.idCompeticion = new SelectList(db.FechaTorneo, "idCompeticion", "usuarioCreacion", partido.idCompeticion);
            return View(partido);
        }

        // GET: Partidoes/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Partido partido = db.Partido.Find(id);
            if (partido == null)
            {
                return HttpNotFound();
            }
            return View(partido);
        }

        public ActionResult RegistrarGol(decimal idEquipo, decimal idPartido)
        {
            if (idEquipo == null || idPartido == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelectList nombreJugadores = new SelectList (from a in db.Funcionario
                         where a.idClub == idEquipo
                         join b in db.Jugador on a.codigoFuncionario equals b.codigoFuncionario
                         select new { nombre = a.nombre, codigoFuncionario = a.codigoFuncionario});
            ViewBag.codigoJugador = new SelectList(db.Funcionario.Where(x => x.idClub == idEquipo), "codigoFuncionario", "nombre");
            //SelectList minutos = new SelectList();
            GolxPartido variable = new GolxPartido();
            variable.idPartido = idPartido;
            return View(variable);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarGol(GolxPartido golxpartido, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    file.SaveAs(HttpContext.Server.MapPath("~/Resources/")
                                                          + file.FileName);
                    golxpartido.video = file.FileName;
                }
                db.GolxPartido.Add(golxpartido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SelectList nombreJugadores = new SelectList(from a in db.Funcionario
                                                        where a.idClub == golxpartido.Jugador.Funcionario.idClub
                                                        join b in db.Jugador on a.codigoFuncionario equals b.codigoFuncionario
                                                        select new { a.nombre, a.codigoFuncionario });

            ViewBag.jugadores = nombreJugadores;
            return View(golxpartido);
        }

        public ActionResult AgregarJugador(decimal idEquipo, decimal idPartido)
        {
            if (idEquipo == null || idPartido == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelectList nombreJugadores = new SelectList(from a in db.Funcionario
                                                        where a.idClub == idEquipo
                                                        join b in db.Jugador on a.codigoFuncionario equals b.codigoFuncionario
                                                        select new { nombre = a.nombre, codigoFuncionario = a.codigoFuncionario });
            ViewBag.codigoJugador = new SelectList(db.Funcionario.Where(x => x.idClub == idEquipo), "codigoFuncionario", "nombre");
            //SelectList minutos = new SelectList();
            JugadorxPartido variable = new JugadorxPartido();
            variable.idPartido = idPartido;
            return View(variable);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AgregarJugador(JugadorxPartido jugadorxpartido)
        {
            if (ModelState.IsValid)
            {
                jugadorxpartido.fchCreacion = DateTime.Now;
                jugadorxpartido.usuarioCreacion = "angramirez";
                db.JugadorxPartido.Add(jugadorxpartido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.codigoJugador = new SelectList(db.Funcionario.Where(x => x.idClub == jugadorxpartido.Jugador.Funcionario.idClub), "codigoFuncionario", "nombre");
            return View(jugadorxpartido);
        }

        public ActionResult RegistrarCambio(decimal idEquipo, decimal idPartido)
        {
            if (idEquipo == null || idPartido == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SelectList nombreJugadores = new SelectList(from a in db.Funcionario
                                                        where a.idClub == idEquipo
                                                        join b in db.Jugador on a.codigoFuncionario equals b.codigoFuncionario
                                                        select new { a.nombre, a.codigoFuncionario });
            SelectList nombreJugadores2 = new SelectList(from a in db.Funcionario
                                                        where a.idClub == idEquipo
                                                        join b in db.Jugador on a.codigoFuncionario equals b.codigoFuncionario
                                                        select new { a.nombre, a.codigoFuncionario });
            ViewBag.codigoJugadorEntra = new SelectList(db.Funcionario.Where(x => x.idClub == idEquipo), "codigoFuncionario", "nombre");
            ViewBag.codigoJugadorSale = new SelectList(db.Funcionario.Where(x => x.idClub == idEquipo), "codigoFuncionario", "nombre");
            CambioxPartido variable = new CambioxPartido();
            variable.idPartido = idPartido;
            return View(variable);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarCambio([Bind(Include = "idPartido,codigoJugadorEntra,codigoJugadorSale,minuto,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] CambioxPartido cambioxpartido)
        {
            
            if (ModelState.IsValid)
            {

                db.CambioxPartido.Add(cambioxpartido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            SelectList nombreJugadores = new SelectList(from a in db.Funcionario
                                                        where a.idClub == cambioxpartido.Jugador.Funcionario.idClub
                                                        join b in db.Jugador on a.codigoFuncionario equals b.codigoFuncionario
                                                        select new { a.nombre, a.codigoFuncionario });

            ViewBag.jugadores = nombreJugadores;
            return View(cambioxpartido);
        }

        public ActionResult RegistrarArbitro(decimal idPartido)
        {
            if (idPartido == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            };
            var tipos = new List<String>()
            {
                ("A"),
                ("S")
            };
            SelectList lista = new SelectList(tipos);
            ViewBag.idArbitro = new SelectList(db.Arbitro, "idArbitro", "nombre");
            ViewBag.tipo = lista;
            ArbitroxPartido variable = new ArbitroxPartido();
            variable.idPartido = idPartido;
            return View(variable);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarArbitro([Bind(Include = "idPartido,idArbitro,desempenho,tipo,usuarioCreacion,usuarioModificacion,fchCreacion,fchModificacion")] ArbitroxPartido arbitroxpartido)
        {

            if (ModelState.IsValid)
            {

                db.ArbitroxPartido.Add(arbitroxpartido);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var tipos = new List<String>()
            {
                ("A"),
                ("S")
            };
            SelectList lista = new SelectList(tipos);
            ViewBag.idArbitro = new SelectList(db.Arbitro, "idArbitro", "nombre");
            ViewBag.tipo = lista;
            return View(arbitroxpartido);
        }

        // POST: Partidoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Partido partido = db.Partido.Find(id);
            db.Partido.Remove(partido);
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
