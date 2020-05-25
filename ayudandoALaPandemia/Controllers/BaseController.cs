using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servicios;

namespace ayudandoALaPandemia.Controllers
{
    public class BaseController : Controller
    {
        // Instanciar los servicios
        public SearchServicios searchServicios;
        public LoginServicios loginServicios;
        public HomeServicios homeServicios;
        
        public BaseController ()
        {
            this.searchServicios = new SearchServicios();
            this.loginServicios = new LoginServicios();
            this.homeServicios = new HomeServicios();
        }
    }
}