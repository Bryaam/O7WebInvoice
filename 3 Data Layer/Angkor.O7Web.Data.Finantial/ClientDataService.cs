// O7ERP Web created by felix_dev
using System.Collections.Generic;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Framework.Infrastructure.Data;
using Angkor.O7Web.Data.Finantial.Entity;

namespace Angkor.O7Web.Data.Finantial
{
    public class ClientDataService : O7AbstractData
    {
        
        public ClientDataService(string user, string password) : base(user, password)
        {
        }

        public virtual IEnumerable<ClientDbEntity> Clients(string companyId, string branchId, string filter)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_filter", filter));
            return DataAccess.Execute<ClientDbEntity>("pkg_client_managment.get_clients", parameters);
        }

        public virtual bool ClientChangeState(string companyId, string branchId, string clientId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_client_id", clientId));
            return DataAccess.ExecuteFunction<int>("pkg_client_managment.change_state_client", parameters) == 1;
        }
    }
}