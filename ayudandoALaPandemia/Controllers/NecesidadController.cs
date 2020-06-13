using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositorios;

namespace ayudandoALaPandemia.Controllers
{
    public class NecesidadController : BaseController
    {
        // GET: NecesidadAction
        public ActionResult Index()
        {
            return View();
        }

        // necesidad/{id}/detalle
        [HttpGet]
        public ActionResult Detalle()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Donaciones()
        {
            return View();
        }


        [HttpPost]
        public DonacionesMonetarias donacionMonetaria(DonacionesMonetarias donacionesMonetarias)
        {
            return necesidadesServicios.donacionMonetaria(donacionesMonetarias);
        }

        [HttpPost]
        public DonacionesInsumos donacionInsumos(DonacionesInsumos donacionesInsumos)
        {
            return necesidadesServicios.donacionInsumo(donacionesInsumos);
        }

        [HttpPost]
        public int Eliminar(int id)
        {
            return necesidadesServicios.Borrar(id);
        }

        [HttpPost]
        public Necesidades Modificar(Necesidades necesidad)
        {
            return necesidadesServicios.Modificar(necesidad);
        }

    }
}