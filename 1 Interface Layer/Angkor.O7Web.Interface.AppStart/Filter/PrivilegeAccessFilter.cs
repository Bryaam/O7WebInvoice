// Create by Felix A. Bueno
using System.Web;
using System.Web.Mvc;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Web.HtmlHelper;
using Angkor.O7Framework.Web.Model;
using Angkor.O7Web.Comunication;

namespace Angkor.O7Web.Interface.AppStart.Filter
{
    public class PrivilegeAccessFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var menuId = (string) filterContext.ActionParameters["menuId"];
            var user = (O7Principal) HttpContext.Current.User;
            var domain = ProxyDomain.Instance.SecurityDomain(user.Name, user.Password);
            var response = domain.ValidAccess(user.Company, user.Branch, menuId);
            if (response is O7ErrorResponse)
                filterContext.Result = new RedirectResult(LinkHelper.SourceLink("Error", "AuthorizationError"));
            var responseAction = (O7SuccessResponse<string>) response;
            if (responseAction.Value1 == "false")
                filterContext.Result = new RedirectResult(LinkHelper.SourceLink("Error", "AuthorizationError"));
            filterContext.Result.ExecuteResult(filterContext.Controller.ControllerContext);
        }
    }
}