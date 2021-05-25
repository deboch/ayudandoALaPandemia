using System.Collections.Generic;
using System.Web.Mvc;
using Repositorios;

namespace ayudandoALaPandemia.Controllers
{
    public class HomeController : BaseController
    {

        [HttpGet]
        public ActionResult Index()
        {
            try
            {
                List<Necesidades> necesidadesMasValoradas = homeServicios.GetMasValorados();
                ViewBag.Necesidades = necesidadesMasValoradas;
                return View();
            }
            catch
            {
                return null;
            }
        }

        [ActionName("acerca-de")]
        public ActionResult AcercaDe() {
            return View();
        }

    }
}