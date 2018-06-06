using Global.Web.Controllers;
using System.Web.Mvc;
using System.Web.Routing;

namespace Global.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = FolderController.ControllerName, action = FolderController.IndexAction, id = UrlParameter.Optional }
            );
        }
    }
}