// Create by Felix A. Bueno

using System.Web.Mvc;
using System.Web.Routing;
using Angkor.O7Web.Interface.Security.Controllers;

namespace Angkor.O7Web.Interface.AppStart.AppStart
{
    public class SecurityAppStart
    {
        public static void BuildRouteConfig(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Authentication", action = "LogIn", id = UrlParameter.Optional },
                namespaces: new[] { typeof(AuthenticationController).Namespace }
            );
        }
    }
}