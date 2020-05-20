using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;
using Servicios;

namespace ayudandoALaPandemia.Controllers
{
    public class SearchController : Controller
    {
        private Servicios.SearchServicios searchServicios = new SearchServicios();

        [HttpGet]
        public ActionResult Search()
        {
            try
            {
                Session.Add("id", 1);
                string userId = Session["id"].ToString();
                string keyword = Request.QueryString["keyword"];
                string date = Request.QueryString["date"];
                return Json(searchServicios.ObtenerNecesidades(), JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return null;
            }
        }
    }
}