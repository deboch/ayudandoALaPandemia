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
            string userId = Session["id"].ToString();
            string keyword = Request.QueryString["keyword"];
            string date = Request.QueryString["date"];
            List<Repositorios.Necesidades> necesidades = searchServicios.ObtenerNecesidades();
            return JsonConvert.SerializeObject(necesidades, Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
            
        }
    }
}