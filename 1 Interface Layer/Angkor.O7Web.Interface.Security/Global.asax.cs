using System.Web.Mvc;
using System.Web.Routing;
using Angkor.O7Web.Interface.AppStart.AppStart;

namespace Angkor.O7Web.Interface.Security
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();            
            SecurityAppStart.BuildRouteConfig(RouteTable.Routes);
        }
    }
}
