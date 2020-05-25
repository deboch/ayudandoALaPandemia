using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositorios;
using Servicios;

namespace ayudandoALaPandemia.Controllers
{
    public class HomeController : BaseController
    {

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                //return Json(HomeServicios.GetMasValorados(), JsonRequestBehavior.AllowGet);
                List<Necesidades> necesidadesMasValoradas = homeServicios.GetMasValorados();
                ViewBag.Necesidades = necesidadesMasValoradas;
                return View();
            }
            catch
            {
                return null;
            }
        }

    }
}