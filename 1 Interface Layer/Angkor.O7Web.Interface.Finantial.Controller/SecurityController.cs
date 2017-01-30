// Create by Felix A. Bueno
using System.Collections.Generic;
using System.Web.Mvc;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.Base;
using Angkor.O7Framework.Web.Model;
using Angkor.O7Framework.Web.Security;
using Angkor.O7Web.Common.Utility;
using Angkor.O7Web.Comunication;
using Angkor.O7Web.Interface.Security.Controllers.Transfer;

namespace Angkor.O7Web.Interface.Finantial.Controller
{
    public class SecurityController : O7Controller
    {
        private O7Authentication _authentication;
        private O7Cryptography _cryptography;
        
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

            var domain = ProxyDomain.Instance.SecurityDomain(credentialCookie.Login, credentialCookie.Password);
            var menus = domain.Menus(credentialCookie.CompanyId, credentialCookie.BranchId, menuId);

            var menusResult = menus as O7SuccessResponse<List<O7Menu>>;
            if (menusResult == null) return null;            

            _authentication.SetMenu(menusResult.Value1);

            var modules = domain.AnotherModules(credentialCookie.CompanyId, credentialCookie.BranchId, menuId);
            var modulesResult = modules as O7SuccessResponse<List<O7Module>>;
            if (modulesResult == null) return null;

            modulesResult.Value1.Append("Url", credential.ToUriPath());
            _authentication.SetModule(modulesResult.Value1);
            
            return RedirectToAction("Index", "Home");
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