using System.Web.Mvc;
using Repositorios;
using Servicios;

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
            if (ModelState.IsValid)
            {
                bool validoEmailYUserName = registroServicios.validoUsuarioNoExistente(u);

                if (validoEmailYUserName)
                {
                    registroServicios.Crear(u);
                    emailServicios.sendEmail(u.Token,u.Email);
                    return RedirectToAction("Index", "Home");
                }
                else{
                    ViewData["mailExiste"] = "Email o Usuario ya existe";
                    return View(u);
                }
            }
            return View(u);
        }

        [HttpGet]
        public ActionResult activoUsuario(string token)
        {
            Usuarios user = registroServicios.obtenerPorToken(token);
            registroServicios.activoToken(user);

            return View();
        }
    }
}