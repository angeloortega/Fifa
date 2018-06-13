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
    public class SociosController : Controller
    {
        private FootballEntities db = new FootballEntities();

        // GET: Socios
        public ActionResult Index()
        {
            return View(db.Socio.ToList());
        }

        // GET: Socios/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = db.Socio.Find(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return View(socio);
        }

        // GET: Socios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Socios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre,fchNacimiento,usuarioCreacion")] Socio socio)
        {
            var last = (from m in db.Socio
                        select m.codigoSocio).Max();
            socio.codigoSocio = last + 1;
            if (ModelState.IsValid)
            {
                socio.fchCreacion = DateTime.Now;
                db.Socio.Add(socio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(socio);
        }

        // GET: Socios/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = db.Socio.Find(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return View(socio);
        }

        // POST: Socios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nombre,codigoSocio,fchNacimiento,usuarioModificacion")] Socio socio)
        {
            if (ModelState.IsValid)
            {
                Socio socioOut = db.Socio.Find(socio.codigoSocio);
                socio.usuarioCreacion = socioOut.usuarioCreacion;
                socio.fchCreacion = socioOut.fchCreacion;
                socio.fchModificacion = DateTime.Now;
                var newContext = new FootballEntities();
                newContext.Entry(socio).State = EntityState.Modified;
                newContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(socio);
        }

        // GET: Socios/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Socio socio = db.Socio.Find(id);
            if (socio == null)
            {
                return HttpNotFound();
            }
            return View(socio);
        }

        // POST: Socios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            Socio socio = db.Socio.Find(id);
            db.Socio.Remove(socio);
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
