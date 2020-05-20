using Entidades;
using Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ayudandoALaPandemia.Controllers
{
    public class LoginController : Controller
    {
        private LoginServicios loginServicios = new LoginServicios();
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