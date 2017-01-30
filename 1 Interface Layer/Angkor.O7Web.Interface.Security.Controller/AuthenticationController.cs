// Create by Felix A. Bueno
using System;
using System.Collections.Specialized;
using System.Web;
using Angkor.O7Framework.Utility;
using Angkor.O7Framework.Web.Base;
using Angkor.O7Web.Common.Utility;
using Angkor.O7Web.Interface.Security.Controllers.Transfer;

namespace Angkor.O7Web.Interface.Security.Controllers
{
    public partial class AuthenticationController : O7Controller
    {
        private HttpCookie make_cookie(string value)
        {
            var cookie = Response.Cookies[Constant.TEMP_COOKIE] ?? new HttpCookie(Constant.TEMP_COOKIE);
            cookie.Value = value;
            cookie.Expires = DateTime.Now.AddMinutes(2);
            return cookie;
        }

        private string serialize_cookie(string login, string password, string companyId, string branchId, string name)
        {
            var cookieValue = new CredentialCookie(login, password, companyId, branchId, name);
            var serializedValue = O7JsonSerealizer.Serialize(cookieValue);

            var cryptography = new O7Cryptography(Constant.CRYPTO_KEY);
            return cryptography.Encrypt(serializedValue);
        }

        private CredentialCookie deserialize_cookie(string value)
        {
            var cryptography = new O7Cryptography(Constant.CRYPTO_KEY);
            var dencryptedValue = cryptography.Decrypt(value);
            return O7JsonSerealizer.Deserialize<CredentialCookie>(dencryptedValue);
        }


        private Tuple<string, string, string, string> get_values_login_post(NameValueCollection formCollection)
        {
            var login = formCollection["logIn"];
            var password = formCollection["password"];
            var company = formCollection["company"];
            var branch = formCollection["branch"];
            return Tuple.Create(login, password, company, branch);
        }
    }
}