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
            Entidades.Necesidad necesidad1 = new Entidades.Necesidad(1, "uno", "", true, 5);
            Entidades.Necesidad necesidad2 = new Entidades.Necesidad(2, "ds", "", true, 4);
            Entidades.Necesidad necesidad3 = new Entidades.Necesidad(3, "fdfh", "", true, 2);
            Entidades.Necesidad necesidad4 = new Entidades.Necesidad(4, "fghfg", "", true, 5);
            Entidades.Necesidad necesidad5 = new Entidades.Necesidad(5, "ufhghno", "", true, 4);
            Entidades.Necesidad necesidad6 = new Entidades.Necesidad(6, "fgfj", "", true, 2);

            List<Entidades.Necesidad> necesidades = new List<Entidades.Necesidad>();
            List<Entidades.Necesidad> masValoradas = new List<Entidades.Necesidad>();
            necesidades.Add(necesidad1);
            necesidades.Add(necesidad2);
            necesidades.Add(necesidad3);
            necesidades.Add(necesidad4);
            necesidades.Add(necesidad5);
            necesidades.Add(necesidad6);

            var listaOrdenada = necesidades.OrderByDescending(x => x.Valoracion).ToList();
            
            return View(listaOrdenada);
        }
        
    }
}