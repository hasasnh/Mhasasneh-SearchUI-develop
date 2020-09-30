using System.Web.Mvc;
using System.Web.Routing;

namespace TripleM.Web.App_Start
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //register MVC/AJAX route(s)
            routes.MapRoute("SearchUI", "SearchUI/SearchUI", new { controller = "SearchUI", action = "SearchUI" });
        }
    }
}