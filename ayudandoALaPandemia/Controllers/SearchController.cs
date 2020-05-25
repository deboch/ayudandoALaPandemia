using System.Collections.Generic;
using Newtonsoft.Json;
using Repositorios;


namespace ayudandoALaPandemia.Controllers
{
    public class SearchController : BaseController
    {
        public string Search(string k)
        {
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