// O7ERP Web created by felix_dev
using System.Web.Mvc;
using Angkor.O7Framework.Web.Base;
using Angkor.O7Framework.Web.WebResult;
using Angkor.O7Web.Comunication;

namespace Angkor.O7Web.Interface.Finantial.Controller
{
    public class DeliverController : O7Controller
    {
        [HttpGet]
        public JsonResult Routes()
        {
            var domain = ProxyDomain.Instance.DeliverDomain(User.Identity.Name, User.Password);
            var response = domain.Routes(User.Company, User.Branch);
            return new O7JsonResult(response);
        }

        [HttpGet]
        public JsonResult Postals()
        {
            var domain = ProxyDomain.Instance.DeliverDomain(User.Identity.Name, User.Password);
            var response = domain.Postals;
            return new O7JsonResult(response);
        }

        [HttpGet]
        public JsonResult Departments(string countryId)
        {
            var domain = ProxyDomain.Instance.DeliverDomain(User.Identity.Name, User.Password);
            var response = domain.Deparments(countryId);
            return new O7JsonResult(response);
        }

        [HttpGet]
        public JsonResult Provinces(string countryId, string departmentId)
        {
            var domain = ProxyDomain.Instance.DeliverDomain(User.Identity.Name, User.Password);
            var response = domain.Provinces(countryId, departmentId);
            return new O7JsonResult(response);
        }

        [HttpGet]
        public JsonResult Districts(string countryId, string departmentId, string provinceId)
        {
            var domain = ProxyDomain.Instance.DeliverDomain(User.Identity.Name, User.Password);
            var response = domain.Districts(countryId, departmentId, provinceId);
            return new O7JsonResult(response);
        }

        [HttpGet]
        public JsonResult Countries()
        {
            var domain = ProxyDomain.Instance.DeliverDomain(User.Identity.Name, User.Password);
            var response = domain.Countries(User.Company, User.Branch);
            return new O7JsonResult(response);
        }









        public JsonResult AllClientZones(string countryId)
        {
            var domain = ProxyDomain.Instance.FinantialDomain(User.Identity.Name, User.Password);
            var response = domain.AllClientZones(countryId);
            return new O7JsonResult(response);
        }

        

        
    }
}