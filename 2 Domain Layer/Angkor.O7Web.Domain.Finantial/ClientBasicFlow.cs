// O7ERP Web created by felix_dev
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Utility;
using Angkor.O7Web.Domain.Finantial.Base;

namespace Angkor.O7Web.Domain.Finantial
{
    public class ClientBasicFlow : ClientDomain
    {
        public ClientBasicFlow(string login, string password) : base(login, password)
        {
        }

        public override O7Response Clients(string companyId, string branchId, string filter)
        {
            var response = ClientDataService.Clients(companyId, branchId, filter);
            var serealizedResponse = O7JsonSerealizer.Serialize(response);
            return O7SuccessResponse.MakeResponse(serealizedResponse);
        }

        public override O7Response ClientChangeState(string companyId, string branchId, string clientId)
        {
            var response = ClientDataService.ClientChangeState(companyId, branchId, clientId);
            return O7SuccessResponse.MakeResponse($"{response}");
        }
    }
}