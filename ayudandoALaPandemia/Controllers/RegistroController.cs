using Antlr.Runtime.Misc;
using Repositorios;
using Servicios;
using System.Web.Mvc;

namespace ayudandoALaPandemia.Controllers
{
    public class RegistroController : BaseController
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuarios u)
        {
            if(ModelState.IsValid)
            {
                registroServicios.altaUsuario(u);
                return RedirectToAction("Home", "Necesidades");
            }
            return View(u);
        }
    }
}