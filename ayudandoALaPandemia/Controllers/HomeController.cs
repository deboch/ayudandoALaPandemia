using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ayudandoALaPandemia.Controllers
{
    public class HomeController : Controller
    {
        //public string Index()
        //{
        // return "hola";
        //}

        [HttpGet]
        public ActionResult Index()
        {
            Entidades.Necesidad necesidad1 = new Entidades.Necesidad(1, "uno", "");
            Entidades.Necesidad necesidad2 = new Entidades.Necesidad(1, "uno", "");
            Entidades.Necesidad necesidad3 = new Entidades.Necesidad(1, "uno", "");

            List<Entidades.Necesidad> necesidades = new List<Entidades.Necesidad>();
            necesidades.Add(necesidad1);
            necesidades.Add(necesidad2);
            necesidades.Add(necesidad3);
          
            return View(necesidades);
        }
        
    }
}