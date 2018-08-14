using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Fifa19.Models;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Data.SqlClient;
using System.IO.Pipes;

namespace Fifa19.Controllers
{
    public class ImagenesController : Controller
    {
        private FootballEntities db = new FootballEntities();

        // GET: Imagenes
        public ActionResult Index()
        {
            //MemoryStream ms = new MemoryStream(db.Imagenes.ToList().First().image_byte);
            //Image returnImage = Image.FromStream(ms);

            return View(db.Imagenes.ToList());
        }

        // GET: Imagenes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagenes imagenes = db.Imagenes.Find(id);
            if (imagenes == null)
            {
                return HttpNotFound();
            }
            return View(imagenes);
        }
        // GET: Imagenes/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult CreateVideo()
        {
            return View();
        }

        // POST: Imagenes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre")] Imagenes imagenes, HttpPostedFileBase file)
        {
            Image convert = Image.FromFile("C:\\Users\\Giulliano\\Desktop\\" + file.FileName, true);
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(convert, typeof(byte[]));
            if (ModelState.IsValid)
            {
                imagenes.image_byte = xByte;
                db.Imagenes.Add(imagenes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(imagenes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateVideo([Bind(Include = "nombre")] Imagenes imagenes, HttpPostedFileBase file)
        {
            SqlConnection connect = new SqlConnection("Data Source = ecRhin.ec.tec.ac.cr\\Estudiantes; Initial Catalog = Football; Persist Security Info = True; User ID = angramirez; Password = angramirez");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connect;
            cmd.CommandText = "insert into Fifa.Imagenes (nombre,image_byte) values (@nombre, @image_byte)";
            cmd.Parameters.AddWithValue("nombre", imagenes.nombre);
            cmd.Parameters.AddWithValue("image_byte", SqlDbType.VarBinary).Value = System.IO.File.ReadAllBytes("C:\\Users\\Giulliano\\Desktop\\" + file.FileName);
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
            return RedirectToAction("Index");
            Image convert = Image.FromFile("C:\\Users\\Giulliano\\Desktop\\" + file.FileName, true);
            ImageConverter _imageConverter = new ImageConverter();
            byte[] xByte = (byte[])_imageConverter.ConvertTo(convert, typeof(byte[]));
            if (ModelState.IsValid)
            {
                imagenes.image_byte = xByte;
                db.Imagenes.Add(imagenes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(imagenes);
        }

        // GET: Imagenes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagenes imagenes = db.Imagenes.Find(id);
            if (imagenes == null)
            {
                return HttpNotFound();
            }
            return View(imagenes);
        }

        // POST: Imagenes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nombre,image_byte")] Imagenes imagenes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagenes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(imagenes);
        }

        // GET: Imagenes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagenes imagenes = db.Imagenes.Find(id);
            if (imagenes == null)
            {
                return HttpNotFound();
            }
            return View(imagenes);
        }

        // POST: Imagenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Imagenes imagenes = db.Imagenes.Find(id);
            db.Imagenes.Remove(imagenes);
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
