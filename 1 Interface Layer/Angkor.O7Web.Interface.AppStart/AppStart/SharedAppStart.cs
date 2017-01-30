// Create by Felix A. Bueno

using System.Web.Mvc;
using System.Web.Routing;
using Angkor.O7Web.Interface.SharedSource.Controller;

namespace Angkor.O7Web.Interface.AppStart.AppStart
{
    public class SharedAppStart
    {
        public static void BuildRouteConfig(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Security", action = "Signout", id = UrlParameter.Optional },
                namespaces: new[] { typeof(SecurityController).Namespace }
            );
        }
    }
}