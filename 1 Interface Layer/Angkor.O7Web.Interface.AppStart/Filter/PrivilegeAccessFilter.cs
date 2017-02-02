// Create by Felix A. Bueno

using System.Linq;
using System.Web;
using System.Web.Mvc;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.Attributes;
using Angkor.O7Framework.Web.HtmlHelper;
using Angkor.O7Framework.Web.Model;
using Angkor.O7Framework.Web.Utility;
using Angkor.O7Web.Comunication;

namespace Angkor.O7Web.Interface.AppStart.Filter
{
    public class PrivilegeAccessFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(ExcludeFilterAttribute), false).Any())            
                return;

            var ActionInfo = filterContext.ActionDescriptor;
            var pars = ActionInfo.GetParameters();

            var menuId = (string)filterContext.RouteData.Values["menuId"];
            var session = HttpContext.Current.Session[WebConstant.USER_COOKIE];

            if (session == null)
            {
                filterContext.Result = new RedirectResult(LinkHelper.SourceLink("Error", "AuthorizationError"));
                filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
                return;
            }
                
            var currentUser = O7JsonSerealizer.Deserialize<O7User>((string)session);
            var domain = ProxyDomain.Instance.SecurityDomain(currentUser.Name, currentUser.Password);

            var response = domain.ValidAccess(currentUser.Company, currentUser.Branch, menuId);
            if (response is O7ErrorResponse)
            {
                filterContext.Result = new RedirectResult(LinkHelper.SourceLink("Error", "AuthorizationError"));
                filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
                return;
            }
            var responseAction = (O7SuccessResponse<string>) response;
            if (responseAction.Value1 == "false")
                filterContext.Result = new RedirectResult(LinkHelper.SourceLink("Error", "AuthorizationError"));            
            filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
        }
    }
}