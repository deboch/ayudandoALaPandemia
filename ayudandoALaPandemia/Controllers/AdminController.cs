using Antlr.Runtime.Tree;
using Repositorios;
using Repositorios.Partials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ayudandoALaPandemia.Controllers
{
    public class AdminController : BaseController
    {
        // GET: Admin
        [HttpGet]
        public ActionResult verDenuncias()
        {
            List<Denuncias> listaDenuncias = denunciasServicio.listaDenuncias();
            ViewBag.Denuncias = listaDenuncias;
            return View();
        }

        [HttpPost]
        public ActionResult DesestimarDenuncia(Denuncias denuncia)
        {
            Denuncias miDenuncia = denunciasServicio.buscarPorId(denuncia.IdDenuncia);
            denunciasServicio.desestimarDenuncia(miDenuncia);
            return RedirectToAction("verDenuncias", "Admin");
        }

        [HttpPost]
        public ActionResult AceptarDenuncia(Denuncias denuncia)
        {
            Denuncias miDenuncia = denunciasServicio.buscarPorId(denuncia.IdDenuncia);
            denunciasServicio.aceptarDenuncia(miDenuncia);
            emailServicios.denunciaAceptada(miDenuncia.Usuarios.Email, miDenuncia.Necesidades.Descripcion, miDenuncia.Usuarios.UserName);

            return RedirectToAction("verDenuncias", "Admin");
        } 

        public ActionResult gestionDenuncia()
        {
            return View();
        }

        [HttpGet]
        public ActionResult linkDenucia(int id)
        {
            Denuncias miDenuncia = denunciasServicio.buscarPorId(id);
            return View(miDenuncia);
        }

        [HttpGet]
        public ActionResult DarAdminPermisos()
        {
            List<Usuarios> misUsuarios = registroServicios.obtengoUsuariosTipo1();
            return View(misUsuarios);
        }


        [HttpGet]
        public ActionResult hacerAdmin(int id)
        {
            Usuarios miUser = registroServicios.ObtenerPorId(id);
            registroServicios.hacerAdmin(id);
            return RedirectToAction("darAdminPermisos", "Admin");
        }

        [HttpGet]
        public ActionResult DetalleNecesidad(int id)
        {
            Necesidades miNecesidad = necesidadesServicios.ObtenerPorId(id);
            return View(miNecesidad);
        }

    }
}