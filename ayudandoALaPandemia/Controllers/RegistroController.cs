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
                bool pass = registroServicios.validoClave(u.Password);
                bool confirm = registroServicios.matcheoClaves(u.Password, u.ConfirmPassword);

                if (validoEmailYUserName && validoMas18 && pass && confirm)
                {
                    registroServicios.Crear(u);
                    emailServicios.sendEmail(u.Token,u.Email);
                    return RedirectToAction("activarUsuario", new { message = u.Email });
                }
                else{
                    if(!validoEmailYUserName)
                    {
                        ViewData["mailExiste"] = "Email o Usuario ya existe";
                        return View(u);
                    }
                    else if(!validoMas18)
                    {
                        ViewData["menor"] = "Tenés que ser mayor de 18 años o la fecha es mayor a la de hoy";
                        return View(u);
                    }
                    else if(!pass)
                    {
                        ViewData["pass"] = "La clave debe tener una mayus, un número y mayor a 8";
                        return View(u);
                    }else if (!confirm)
                    {
                        ViewData["confirm"] = "Las claves no coinciden. Verificar por favor.";
                        return View(u);
                    }
                }
            }
            return View(u);
        }

        [HttpGet]
        public ActionResult activarUsuario(string message)
        {
            ViewBag.Email = message;
            return View();
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