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
                int variable = registroServicios.validoUsuario(u);

                if(variable != 0)
                {
                    registroServicios.Crear(u);
                    //registroServicios.MD5Hash(u);
                    return RedirectToAction("Index", "Home");
                }
                else if(variable == 0)
                {
                    ViewData["mailExiste"] = "Email o Usuario ya existe";
                    return View(u);
                }
                
            }
            return View(u);
        }
    }
}