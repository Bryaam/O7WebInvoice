using System.Web.Mvc;
using System.Web.Routing;
using Angkor.O7Web.Interface.AppStart.AppStart;

namespace Angkor.O7Web.Interface.Finantial
{
    public class MvcApplication : System.Web.HttpApplication
    {        
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FinantialAppStart.BuildRouteConfig(RouteTable.Routes);
        }
    }
}
