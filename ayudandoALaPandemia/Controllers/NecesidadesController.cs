using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositorios;

namespace ayudandoALaPandemia.Controllers
{
    public class NecesidadesController : BaseController
    {
        // GET: Necesidades
        public ActionResult Home (string keyword)
        {
            if (keyword != null)
            {
                return RedirectToAction("Index", "Search", new { keyword });
            }
            if (Session["email"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View("Crear", "Necesidades");
        }

        [HttpPost]
        public ActionResult Crear(Necesidades necesidad)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}