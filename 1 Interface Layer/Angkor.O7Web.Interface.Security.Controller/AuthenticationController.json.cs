// Create by Felix A. Bueno
using System.Web.Mvc;
using Angkor.O7Framework.Web.WebResult;
using Angkor.O7Web.Comunication;

namespace Angkor.O7Web.Interface.Security.Controllers
{
    public partial class AuthenticationController
    {
        [HttpPost]
        public JsonResult GetCompanies(string login, string password)
        {
            var domain = ProxyDomain.Instance.SecurityDomain(login, password);
            var companies = domain.Companies();
            return new O7JsonResult(companies);
        }

        [HttpPost]
        public JsonResult GetBranches(string login, string password, string companyId)
        {
            var domain = ProxyDomain.Instance.SecurityDomain(login, password);
            var branches = domain.Branches(companyId);
            return new O7JsonResult(branches);
        }
    }
}