using System.Web.Mvc;
using Repositorios;

namespace ayudandoALaPandemia.Controllers
{
    public class LoginController : BaseController
    {

        public ActionResult Index()
        {
            // carga la vista que esta en la carpeta Home
            return View();
        }

        [HttpPost]
        public RedirectToRouteResult Success(FormCollection form)
        {
            Repositorios.Usuarios user = new Usuarios();
            user.Email = form["email"];
            user.Password = form["password"];

            Usuarios usuario = loginServicios.logear(user);

            if (usuario != null)
            {
                // si esta todo ok grabo en el Session los datos del usuario
                Session["id"] = usuario.IdUsuario;
                Session["email"] = usuario.Email.ToString();
                Session["username"] = usuario.UserName;
                // redirijo a Index de HomeController
                return RedirectToAction("Home", "Necesidades");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
    }
}