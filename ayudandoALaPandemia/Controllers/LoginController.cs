using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Repositorios;

namespace ayudandoALaPandemia.Controllers
{
    public class LoginController : BaseController
    {

        public ActionResult Index()
        {
            // carga la vista que esta en la carpeta Home
            return View("~/Views/Home/Login.cshtml");
        }

        [HttpPost]
        public RedirectToRouteResult Success(FormCollection form)
        {
            Usuarios user = new Usuarios();
            user.Email = form["email"];
            user.Password = form["password"];

            var usuario = loginServicios.logear(user);

            if (usuario != null)
            {
                // si esta todo ok grabo en el Session los datos del usuario
                Session["id"] = usuario.IdUsuario;
                Session["email"] = usuario.Email.ToString();
                Session["username"] = usuario.UserName;
                // redirijo a Index de HomeController
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
    }
}