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
                bool validoEmailYUserName = registroServicios.validoUsuarioNoExistente(u);

                if(validoEmailYUserName == true)
                {
                    registroServicios.Crear(u);
                    return RedirectToAction("Index", "Home");
                }
                else if(validoEmailYUserName == false)
                {
                    ViewData["mailExiste"] = "Email o Usuario ya existe";
                    return View(u);
                }
                
            }
            return View(u);
        }
    }
}