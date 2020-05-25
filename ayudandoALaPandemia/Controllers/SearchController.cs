using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;
using Repositorios;
using Servicios;
using Newtonsoft.Json;


namespace ayudandoALaPandemia.Controllers
{
    public class SearchController : BaseController
    {
        public string Search()
        {

            Session.Add("id", 1);
            int userId = ((int)Session["id"]);
            string keyword = Request.QueryString["keyword"];
            List<Necesidades> necesidades = searchServicios.ObtenerNecesidades(userId, keyword);
            return JsonConvert.SerializeObject(necesidades, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
        }
    }
}