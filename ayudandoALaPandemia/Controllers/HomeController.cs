using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servicios;

namespace ayudandoALaPandemia.Controllers
{
    public class HomeController : Controller
    {
        //public string Index()
        //{
        // return "hola";
        //}


        private Servicios.HomeServicios searchServicios = new HomeServicios();

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                string keyword = Request.QueryString["keyword"];
                string date = Request.QueryString["date"];
                return Json(searchServicios.GetMasValorados(), JsonRequestBehavior.AllowGet);

            }
            catch
            {
                return null;
            }
        }
        
    }
}