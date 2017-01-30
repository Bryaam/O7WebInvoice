using System.Web.Mvc;
using System.Web.Routing;
using Angkor.O7Web.Interface.AppStart;
using Angkor.O7Web.Interface.AppStart.AppStart;

namespace Angkor.O7Web.Interface.SharedSource
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteTable.Routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            SharedAppStart.BuildRouteConfig(RouteTable.Routes);

        }
    }
}
