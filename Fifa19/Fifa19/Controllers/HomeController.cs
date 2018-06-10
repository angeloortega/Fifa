using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fifa19.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Jugador()
        {
            ViewBag.Message = "Jugador Page";

            return View();
        }

        public ActionResult Entrenador()
        {
            ViewBag.Message = "Entrenador Page";

            return View();
        }

        public ActionResult Funcionario()
        {
            ViewBag.Message = "Funcionario Page";

            return View();
        }

        public ActionResult Torneo()
        {
            ViewBag.Message = "Torneo Page";

            return View();
        }
    }
}