using System.Web.Mvc;
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
                // si esta todo ok grabo en el Session los datos del usuario
                Session["id"] = usuario.IdUsuario;
                Session["email"] = usuario.Email.ToString();
                Session["username"] = usuario.UserName;
                // redirijo a Index de HomeController
                return RedirectToAction("Index", "Necesidades");
                
            }
            else
            {
                return View(user);
            }

        }
    }
}