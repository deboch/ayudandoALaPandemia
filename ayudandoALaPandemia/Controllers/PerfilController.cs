using Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ayudandoALaPandemia.Controllers
{
    public class PerfilController : BaseController
    {
        // GET: Perfil
        public ActionResult Index(Usuarios user)
        {
            return View(user);
        }
    }
}