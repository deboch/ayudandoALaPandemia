using System;
using System.Collections.Generic;
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
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuarios user)
        {
            string returnUrl = Request.UrlReferrer.ToString();

            if (!ModelState.IsValid)
                return View(user);

            Usuarios usuario = loginServicios.logear(user);

            if (usuario == null)
            {
                ViewBag.Error = "Email y/o Contraseña inválidos";
                return View(user);
            }
            else if (usuario.TipoUsuario == 0) 
            {
                Session["id"] = usuario.IdUsuario;
                Session["email"] = usuario.Email.ToString();
                Session["username"] = usuario.UserName;
                Session["nombre"] = usuario.Nombre;
                Session["apellido"] = usuario.Apellido;
                Session["fechaNacimiento"] = usuario.FechaNacimiento;
                Session["foto"] = usuario.Foto;
                Session["tipo"] = usuario.TipoUsuario;
                return RedirectToAction("Index", "Necesidades");
            }
            else if (!usuario.Activo)
            {
                Usuarios nuevoUsuarios = loginServicios.obtenerPorMail(usuario.Email);
                nuevoUsuarios.Token = registroServicios.generoToken();
                registroServicios.generoTokenNuevo(nuevoUsuarios, nuevoUsuarios.Token);
                emailServicios.sendEmail(nuevoUsuarios.Token, nuevoUsuarios.Email);
                return (RedirectToAction("activarUsuario", "Registro", new { message = nuevoUsuarios.Email }));
            }
            else
            {
                Session["id"] = usuario.IdUsuario;
                Session["email"] = usuario.Email.ToString();
                Session["username"] = usuario.UserName;
                Session["nombre"] = usuario.Nombre;
                Session["apellido"] = usuario.Apellido;
                Session["fechaNacimiento"] = usuario.FechaNacimiento;
                Session["foto"] = usuario.Foto;
                Session["tipo"] = usuario.TipoUsuario;
                return RedirectToAction("Index", "Necesidades");
            }
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");

        }
    }
}