using ayudandoALaPandemia.Builder;
using ayudandoALaPandemia.ViewModels;
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
        [HttpGet]
        public ActionResult Index(Usuarios user)
        { 
            return View(user);
        }

        [HttpGet]
        public ActionResult MisDenuncias(Usuarios user)
        {
            return View(user);
        }

        [HttpGet]
        public ActionResult MisDonaciones(Usuarios user)
        {
            return View(user);
        }

        [HttpGet]

        public ActionResult Editar()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Editar(UsuarioDto usuarioDto)
        {
            int userId = (int)Session["id"];
            UsuarioBuilder builder = new UsuarioBuilder();
            Usuarios usuarioModificado = builder.toUsuariosEntity(usuarioDto);
            Usuarios usuarioModificado2 =  registroServicios.Editar(usuarioModificado, userId);

            Session["id"] = usuarioModificado2.IdUsuario;
            Session["email"] = usuarioModificado2.Email.ToString();
            Session["username"] = usuarioModificado2.UserName;
            Session["nombre"] = usuarioModificado2.Nombre;
            Session["apellido"] = usuarioModificado2.Apellido;
            Session["fechaNacimiento"] = usuarioModificado2.FechaNacimiento;

            TempData["exito"] = "Guardaste con exito!!";
            return View();
        }
    }
}