﻿using System.Web.Mvc;
using System.Web.Routing;

namespace ayudandoALaPandemia
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ApiNecesidades",
                url: "api/{action}",
                defaults: new { controller = "ApiNecesidades", action = "necesidades" }
            );

            routes.MapRoute(
                name: "Necesidades",
                url: "necesidades/{action}/{id}/",
                defaults: new { controller = "Necesidades", action = "Index", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "Necesidad",
                url: "necesidad/{id}/{action}",
                defaults: new { controller = "Necesidad", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Login",
                url: "login/{action}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
               name: "Registro",
               url: "registro/{action}",
               defaults: new { controller = "Registro", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Home",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
