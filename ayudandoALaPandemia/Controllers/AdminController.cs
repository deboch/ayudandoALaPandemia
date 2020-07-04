using Antlr.Runtime.Tree;
using Repositorios;
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
            List<Denuncias> listDenuncias = denunciasServicio.listaDenuncias();
            return View(listDenuncias);
        }

        [HttpPost]
        public ActionResult DesestimarDenuncia(int id)
        {
            Denuncias miDenuncia = denunciasServicio.buscarPorId(id);
            denunciasServicio.desestimarDenuncia(miDenuncia);
            
            return RedirectToAction("verDenuncias", "Admin");
        }

        [HttpPost]
        public ActionResult AceptarDenuncia(int id)
        {
            Denuncias miDenuncia = denunciasServicio.buscarPorId(id);
            denunciasServicio.aceptarDenuncia(miDenuncia);

            return RedirectToAction("verDenuncias", "Admin");
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


    }
}