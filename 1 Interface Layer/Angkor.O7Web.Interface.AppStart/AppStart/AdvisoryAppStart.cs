// Create by Felix A. Bueno

using System.Web.Mvc;
using System.Web.Routing;
using Angkor.O7Web.Interface.Advisory.Controller;

namespace Angkor.O7Web.Interface.AppStart.AppStart
{
    public class AdvisoryAppStart
    {
        public static void BuildRouteConfig(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Security", action = "Access", id = UrlParameter.Optional },
                namespaces: new[] { typeof(SecurityController).Namespace }
            );
        }
    }
}