// Create by Felix A. Bueno

using System.Web.Mvc;
using Angkor.O7Web.Interface.AppStart.Filter;

namespace Angkor.O7Web.Interface.AppStart.AppStart
{
    public class CommonAppStart
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new PrivilegeAccessFilter());
        }
    }
}