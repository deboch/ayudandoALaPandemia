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
                else if (usuario.Activo == false)
                {
                    Usuarios nuevoUsuarios = loginServicios.obtenerPorMail(usuario.Email);
                    nuevoUsuarios.Token = registroServicios.generoToken();
                    registroServicios.generoTokenNuevo(nuevoUsuarios, nuevoUsuarios.Token);
                    emailServicios.sendEmail(nuevoUsuarios.Token, nuevoUsuarios.Email);
                    return (RedirectToAction("activarUsuario","Login", new {email = nuevoUsuarios.Email }));
                }
                else
                {
                    Session["id"] = usuario.IdUsuario;
                    Session["email"] = usuario.Email.ToString();
                    Session["username"] = usuario.UserName;
                    return RedirectToAction("Index", "Necesidades");
                }

            }
            return View(user);
        }
    
        [HttpGet]
        public ActionResult activarUsuario(string email)
        {
            ViewBag.email = email;
            return View();
        }
    }
}