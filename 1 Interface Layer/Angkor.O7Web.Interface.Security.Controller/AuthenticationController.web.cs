//Create by Felix A. Bueno
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.HtmlHelper;
using Angkor.O7Framework.Web.Model;
using Angkor.O7Web.Common.Utility;
using Angkor.O7Web.Comunication;

namespace Angkor.O7Web.Interface.Security.Controllers
{
    public partial class AuthenticationController
    {        
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ActionName("LogIn")]
        public ActionResult LogInPost()
        {
            var model = get_values_login_post(Request.Form);
            var domain = ProxyDomain.Instance.SecurityDomain(model.Item1, model.Item2);

            var userResponse = domain.UserName(model.Item3, model.Item4);

            var successResponse = userResponse as O7SuccessResponse<string>;            
            if (successResponse == null) return Redirect(LinkHelper.SourceLink("Error", "ServerError"));

            var encryptedValue = serialize_cookie(model.Item1, model.Item2, model.Item3, model.Item4, successResponse.Value1);
            var cookie = make_cookie(encryptedValue);
            
            Response.Cookies.Add(cookie);
            
            return RedirectToAction("SwitchModule");
        }        

        public ActionResult SwitchModule()
        {
            var cookie = Request.Cookies[Constant.TEMP_COOKIE];
            if (cookie == null) return RedirectToAction("LogIn");
            
            var serializedCookie = deserialize_cookie(cookie.Value);
            var domain = ProxyDomain.Instance.SecurityDomain(serializedCookie.Login, serializedCookie.Password);
            var modules = domain.AllModules(serializedCookie.CompanyId, serializedCookie.BranchId);

            var currentSource = modules as O7SuccessResponse<List<O7Module>>;
            if (currentSource == null) return Redirect(LinkHelper.SourceLink("Error", "ServerError", Tuple.Create("credential", cookie.Value)));

            currentSource.Value1.Append("Url", cookie.Value.ToUriPath());
            ViewData["modules"] = currentSource.Value1;
            return View();
        }
    }
}