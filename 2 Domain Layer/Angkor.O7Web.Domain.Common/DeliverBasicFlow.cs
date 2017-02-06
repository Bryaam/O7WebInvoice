// O7ERP Web created by felix_dev
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Utility;
using Angkor.O7Web.Domain.Common.Base;

namespace Angkor.O7Web.Domain.Common
{
    public class DeliverBasicFlow : DeliverDomain
    {
        public DeliverBasicFlow(string login, string password) : base(login, password)
        {
        }

        public override O7Response Routes(string companyId, string branchId)
        {
            var response = DeliverDataService.Routes(companyId, branchId);
            var serealizedResponse = O7JsonSerealizer.Serialize(response);
            return O7SuccessResponse.MakeResponse(serealizedResponse);
        }

        public override O7Response Postals
        {
            get
            {
                var response = DeliverDataService.Postals;
                var serealizedResponse = O7JsonSerealizer.Serialize(response);
                return O7SuccessResponse.MakeResponse(serealizedResponse);
            }
        }

        public override O7Response Zones(string countryId)
        {
            var response = DeliverDataService.Zones(countryId);
            var serealizedResponse = O7JsonSerealizer.Serialize(response);
            return O7SuccessResponse.MakeResponse(serealizedResponse);
        }

        public override O7Response Countries(string companyId, string branchId)
        {
            var response = DeliverDataService.Countries(companyId, branchId);
            var serealizedResponse = O7JsonSerealizer.Serialize(response);
            return O7SuccessResponse.MakeResponse(serealizedResponse);
        }
               
        public override O7Response Deparments(string countryId)
        {
            var response = DeliverDataService.Deparments(countryId);
            var serealizedResponse = O7JsonSerealizer.Serialize(response);
            return O7SuccessResponse.MakeResponse(serealizedResponse);
        }

        public override O7Response Provinces(string countryId, string deparmentId)
        {
            var response = DeliverDataService.Provinces(countryId, deparmentId);
            var serealizedResponse = O7JsonSerealizer.Serialize(response);
            return O7SuccessResponse.MakeResponse(serealizedResponse);
        }

        public override O7Response Districts(string countryId, string deparmentId, string provinceId)
        {
            var response = DeliverDataService.Districts(countryId, deparmentId, provinceId);
            var serealizedResponse = O7JsonSerealizer.Serialize(response);
            return O7SuccessResponse.MakeResponse(serealizedResponse);
        }
    }
}