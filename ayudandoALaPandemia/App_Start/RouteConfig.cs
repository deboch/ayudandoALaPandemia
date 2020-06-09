using System.Web.Mvc;
using System.Web.Routing;

namespace ayudandoALaPandemia
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Search",
                url: "api/{action}",
                defaults: new { controller = "Search", action = "Search" }
            );

            routes.MapRoute(
                name: "Necesidades",
                url: "necesidades/{action}/{id}",
                defaults: new { controller = "Necesidades", action = "Index", id = UrlParameter.Optional }
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
