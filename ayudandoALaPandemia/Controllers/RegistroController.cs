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
                bool validoMas18 = registroServicios.mas18(u.FechaNacimiento);

                if (validoEmailYUserName && validoMas18)
                {
                    registroServicios.Crear(u);
                    emailServicios.sendEmail(u.Token,u.Email);
                    return RedirectToAction("Index", "Home");
                }
                else{
                    if(validoEmailYUserName == false)
                    {
                        ViewData["mailExiste"] = "Email o Usuario ya existe";
                        return View(u);
                    }
                    else
                    {
                        ViewData["menor"] = "Tenés que ser mayor de 18 años";
                        return View(u);
                    }
                    
                }
            }
            return View(u);
        }

        [HttpGet]
        public ActionResult activoUsuario(string token)
        {
            Usuarios user = new Usuarios();
            user = registroServicios.obtenerPorToken(token);
            registroServicios.activoToken(user);

            return View();
        }
    }
}