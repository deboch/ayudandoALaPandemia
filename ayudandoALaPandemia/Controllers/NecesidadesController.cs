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
        [HttpGet]
        public ActionResult Index (string keyword)
        {
            /*if (keyword != null)
            {
                return RedirectToAction("Index", "Search", new { keyword });
            }*/
            if (Session["email"] == null)
            {
                return View("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public int Crear(Necesidades necesidad)
        {
            List<Necesidades> necesidadesDelUsuario = necesidadesServicios.ObtenerPorUserId(necesidad.IdUsuarioCreador);
            if (necesidadesDelUsuario.Count >= 3)
            {
                return 0;
            }
            return necesidadesServicios.Crear(necesidad);
        }
    }
}