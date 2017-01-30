// Create by Felix A. Bueno

using System.Collections.Generic;
using System.Web.Mvc;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Infrastructure;
using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.Base;
using Angkor.O7Framework.Web.HtmlHelper;
using Angkor.O7Framework.Web.Model;
using Angkor.O7Framework.Web.Security;
using Angkor.O7Web.Common.Utility;
using Angkor.O7Web.Domain.Common;
using Angkor.O7Web.Domain.Security;
using Angkor.O7Web.Interface.Security.Controllers.Transfer;

namespace Angkor.O7Web.Interface.Advisory.Controller
{    
    public class SecurityController : O7Controller
    {
        private O7Authentication _authentication;
        private readonly O7Cryptography _cryptography;
        
        public SecurityController()
        {
            _cryptography = new O7Cryptography(Constant.CRYPTO_KEY);
        }

        public ActionResult Access(string menuId, string credential)
        {
            if (string.IsNullOrEmpty(credential)) return null;

            _authentication = new O7Authentication(Session);

            var credentialCookie = make_credential_cookie(credential);
            authenticate_user(credentialCookie);

            var argDomain = new object[] { credentialCookie.Login, credentialCookie.Password };
            var argFlow = new object[] { credentialCookie.Login };

            var domain = O7DomainInstanceMaker.MakeInstance<SecurityFlow, BasicFlow>(argDomain, argFlow);
            var menus = domain.Menus(credentialCookie.CompanyId, credentialCookie.BranchId, menuId);

            var menusResult = menus as O7SuccessResponse<List<O7Menu>>;
            if (menusResult == null) return null;

            _authentication.SetMenu(menusResult.Value1);
            
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            _authentication.RemoveUser();
            _authentication.RemoveMenus();
            return Redirect(LinkHelper.SourceLink("Security", "Signout"));
        }

        private O7User make_user(CredentialCookie cookie)
        {
            return new O7User(cookie.CompanyId, cookie.BranchId, cookie.Login, cookie.Name, cookie.Password);
        }

        private CredentialCookie make_credential_cookie(string credential)
        {
            var dencryptedValue = _cryptography.Decrypt(credential);
            return O7JsonSerealizer.Deserialize<CredentialCookie>(dencryptedValue);
        }

        private void authenticate_user(CredentialCookie credential)
        {
            var user = make_user(credential);
            _authentication.SetUser(user);
        }
    }
}