using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ayudandoALaPandemia.Builder;
using ayudandoALaPandemia.ViewModels;
using Repositorios;

namespace ayudandoALaPandemia.Controllers
{
    public class NecesidadesController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            if (Session != null)
            {
                int userId = (int)Session["id"];
                List<Necesidades> misNecesidades = necesidadesServicios.ObtenerPorUserId(userId);
                ViewBag.misNecesidades = misNecesidades;
            }

            if (Session["email"] == null)
            {
                return View("Index", "Home");
            }

            return View();
        }

        // GET: Necesidades
        [HttpGet]
        public ActionResult Home(string keyword)
        {
            return View();
        }

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Crear(NecesidadDto necesidadDto)
        {
            int userId = (int)Session["id"];
            Usuarios usuarioActual = registroServicios.ObtenerPorId(userId);
            List<Necesidades> necesidadesDelUsuario = necesidadesServicios.ObtenerPorUserId(userId);
            if (usuarioActual.Foto == null)
            {
                ViewBag.Incompleto = "Completa tu perfil antes de crear una necesidad";
                return View();

            }
            if (necesidadesDelUsuario.Count >= 5)
            {
                ViewBag.NoPermitir = "Ya posee 3 necesidades abiertas";
                return View();
            }
            if (!ModelState.IsValid)
                return View();

            NecesidadBuilder builder = new NecesidadBuilder();
            Necesidades nuevaNecesidad = builder.toNecesidadesEntity(necesidadDto, userId);
            necesidadesServicios.Crear(nuevaNecesidad);
            
            return RedirectToAction("Index");
        }

        [HttpPost]
        public bool Valorar(int like, int idNecesidad)
        {
            var userId = (int)Session["id"];
            return necesidadesServicios.Valorar(like, userId, idNecesidad);
        }

    }
}
