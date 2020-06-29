using System.Web.Mvc;
using Antlr.Runtime.Misc;
using Repositorios;

namespace ayudandoALaPandemia.Controllers
{
    public class LoginController : BaseController
    {

        [HttpGet]
        public ActionResult Index()
        {
            // carga la vista que esta en la carpeta Home
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuarios user)
        {
            // esto es feo!!
            if (ModelState.IsValid)
            {
                Usuarios usuario = loginServicios.logear(user);
                if (usuario == null)
                {
                    return View(user);
                }
                else if (user.Activo == false)
                {
                    user.Token = registroServicios.generoToken();
                    registroServicios.generoTokenNuevo(user);
                    emailServicios.sendEmail(user.Token);
                    return (RedirectToAction("activarUsuario", "Login", user.Email));
                }
                    Session["id"] = usuario.IdUsuario;
                    Session["email"] = usuario.Email.ToString();
                    Session["username"] = usuario.UserName;
                    // redirijo a Index de HomeController
                    return RedirectToAction("Index", "Necesidades");
            }
            return View(user);
        }
    
        [HttpPost]
        public ActionResult activarUsuario(string email)
        {
            ViewBag.email = email;
            return View();
        }
    }
}