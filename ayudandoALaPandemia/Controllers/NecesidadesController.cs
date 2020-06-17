using System.Collections.Generic;
using System.Web.Mvc;
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
        public bool Valorar(int like, int idNecesidad)
        {
            var userId = (int)Session["id"];
            return necesidadesServicios.Valorar(like, userId, idNecesidad);
        }

    }
}
