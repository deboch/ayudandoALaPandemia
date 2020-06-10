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

        [HttpGet]
        public ActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        public int Crear(Necesidades necesidad)
        {
            Usuarios usuarioActual = registroServicios.ObtenerPorId(necesidad.IdUsuarioCreador);
            List<Necesidades> necesidadesDelUsuario = necesidadesServicios.ObtenerPorUserId(necesidad.IdUsuarioCreador);
            if (usuarioActual.Foto == null)
            {
                ViewBag.Incompleto = "Completa tu perfil antes de crear una necesidad";
                return 0;

            }
            if (necesidadesDelUsuario.Count >= 3)
            {
                ViewBag.NoPermitir = "Ya posee 3 necesidades abiertas";
                return 0;
            }
            return necesidadesServicios.Crear(necesidad);
        }

        [HttpPost]
        public int Eliminar(int id)
        {
            return necesidadesServicios.Borrar(id);
        }

        [HttpPost]
        public Necesidades Modificar(Necesidades necesidad)
        {
            return necesidadesServicios.Modificar(necesidad);
        }

        [HttpGet]
        public ActionResult Detalle(int? id)
        {
            return View();
        }

        [HttpPost]
        public bool Valorar(int like, int idNecesidad)
        {
            int userId = (int)Session["id"];
            if(userId == null)
            {
                return false;
            }
            return necesidadesServicios.Valorar(like, userId, idNecesidad);
        }

    }
}
