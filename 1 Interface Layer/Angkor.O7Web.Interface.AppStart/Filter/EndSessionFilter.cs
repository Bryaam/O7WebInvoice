// O7ERP Web created by felix_dev
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Angkor.O7Framework.Web.Attributes;
using Angkor.O7Framework.Web.Utility;

namespace Angkor.O7Web.Interface.AppStart.Filter
{
    public class EndSessionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(ExcludeFilterAttribute), false).Any())
                return;

            var session = HttpContext.Current.Session[WebConstant.USER_COOKIE];
            if (session != null) return;

            filterContext.Result = new RedirectResult("http://localhost:120/Security", false);
            filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
        }
    }
}