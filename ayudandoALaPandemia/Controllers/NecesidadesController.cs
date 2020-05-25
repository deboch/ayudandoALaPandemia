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
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Salir()
        {
            return RedirectToAction("Home", "Necesidades");
        }
    }
}