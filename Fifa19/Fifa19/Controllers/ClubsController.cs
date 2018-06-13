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
    public class ClubsController : Controller
    {
        private FootballEntities db = new FootballEntities();

        // GET: Clubs
        public async Task<ActionResult> Index(string search)
        {
            var club = from m in db.Club
                         select m;
            if (!String.IsNullOrEmpty(search))
            {
                club = club.Where(s => s.Federacion.nombre.Contains(search));
            }
            return View(await club.ToListAsync());
        }

        // GET: Clubs/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Club.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // GET: Clubs/Create
        public ActionResult Create()
        {
            ViewBag.idFederacion = new SelectList(db.Federacion, "idFederacion", "nombre");
            return View();
        }

        // POST: Clubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idFederacion,nombre,fchFundacion,usuarioCreacion")] Club club)
        {
            var last = (from m in db.Club
                        select m.idClub).Max();
            club.idClub = last + 1;
            if (ModelState.IsValid)
            {
                club.fchCreacion = DateTime.Now;
                db.Club.Add(club);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idFederacion = new SelectList(db.Federacion, "idFederacion", "idFederacion", club.idFederacion);
            return View(club);
        }

        // GET: Clubs/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Club.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            ViewBag.idFederacion = new SelectList(db.Federacion, "idFederacion", "nombre", club.idFederacion);
            return View(club);
        }

        // POST: Clubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idClub,idFederacion,nombre,fchFundacion,usuarioCreacion")] Club club)
        {
            if (ModelState.IsValid)
            {
                Club clubOut = db.Club.Find(club.idClub);
                club.usuarioCreacion = clubOut.usuarioCreacion;
                club.fchCreacion = clubOut.fchCreacion;
                club.fchModificacion = DateTime.Now;
                var newContext = new FootballEntities();
                newContext.Entry(club).State = EntityState.Modified;
                newContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idFederacion = new SelectList(db.Federacion, "idFederacion", "idFederacion", club.idFederacion);
            return View(club);
        }

        // GET: Clubs/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Club club = db.Club.Find(id);
            if (club == null)
            {
                return HttpNotFound();
            }
            return View(club);
        }

        // POST: Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Club club = db.Club.Find(id);
            db.Club.Remove(club);
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
