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

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login(Usuarios u)
        {

            Usuarios usuario = loginServicios.logear(u);

            if (usuario != null)
            {
                Session["id"] = usuario.IdUsuario;
                Session["email"] = usuario.Email;
                Session["username"] = usuario.UserName;
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
    }
}