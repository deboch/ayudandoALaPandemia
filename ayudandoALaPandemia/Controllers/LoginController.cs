using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ayudandoALaPandemia.Controllers
{
    public class LoginController :BaseController
    {
        private LoginServicios loginServicios = new LoginServicios();

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login(Usuario u)
        {
            bool logeado = LoginServicios.logear(u);

            if (logeado == true)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }

        }
    }
}