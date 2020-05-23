using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servicios;

namespace ayudandoALaPandemia.Controllers
{
    public class HomeController : BaseController
    {
        //public string Index()
        //{
        // return "hola";
        //}


        private HomeServicios HomeServicios = new HomeServicios();

        [HttpGet]
        public ActionResult Index()
        {
            try
            {

                //return Json(HomeServicios.GetMasValorados(), JsonRequestBehavior.AllowGet);
                return View(HomeServicios.GetMasValorados());

            }
            catch
            {
                return null;
            }
        }

    }
}