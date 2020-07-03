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
            // carga la vista que esta en la carpeta Home
            return View();
        }

        [HttpPost]
        public ActionResult Index(Usuarios user)
        {
            // esto es feo!!
   
            Usuarios usuario = loginServicios.logear(user);
            if (usuario == null)
            {
                return View(user);
            }
            else if (usuario.TipoUsuario == 0) 
            {
                return RedirectToAction("Administrador", "Login");
                
            }
            else if (!usuario.Activo)
            {
                Usuarios nuevoUsuarios = loginServicios.obtenerPorMail(usuario.Email);
                nuevoUsuarios.Token = registroServicios.generoToken();
                registroServicios.generoTokenNuevo(nuevoUsuarios, nuevoUsuarios.Token);
                emailServicios.sendEmail(nuevoUsuarios.Token, nuevoUsuarios.Email);
                return (RedirectToAction("activarUsuario", "Login", new { email = nuevoUsuarios.Email }));
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
        public ActionResult activarUsuario(string email)
        {
            ViewBag.email = email;
            return View();
        }

        [HttpGet]
        public ActionResult Administrador(string email)
        {   
            return View();
        }

        [HttpGet]
        public ActionResult verDenunciasAdmin()
        {
            List<Denuncias> listDenuncias = denunciasServicio.listaDenuncias();

            return View(listDenuncias);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");

        }
    }
}