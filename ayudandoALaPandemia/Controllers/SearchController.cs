using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Servicios;

namespace ayudandoALaPandemia.Controllers
{
    public class SearchController : Controller
    {
        private HttpContextBase Context { get; set; }
        private SearchS
        public string Index()
        {
            return "search";
        }
        
        [HttpGet]
        public void Search()
        {
            string userId = this.Context.Session["id"].ToString();
            string keyword = this.Context.Request["keyword"];
            string date = this.Context.Request["date"];
        }
    }
}