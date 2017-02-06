// O7ERP Web created by felix_dev
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Infrastructure;
using Angkor.O7Web.Data.Finantial;

namespace Angkor.O7Web.Domain.Finantial.Base
{
    public abstract class ClientDomain
    {
        public ClientDataService ClientDataService { get; private set; }

        protected ClientDomain(string login, string password)
        {
            ClientDataService = O7DataInstanceMaker.MakeInstance<ClientDataService>(new object[] { login, password });
        }

        public abstract O7Response Clients(string companyId, string branchId, string filter);

        public abstract O7Response ClientChangeState(string companyId, string branchId, string clientId);
    }
}