// Create by Felix A. Bueno

using System.Collections.Generic;
using System.Linq;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Framework.Infrastructure.Data;
using Angkor.O7Web.Common.Entity;
using Angkor.O7Web.Data.Common.DataMapper;

namespace Angkor.O7Web.Data.Common
{
    public class CommonDataService : O7AbstractData
    {
        public CommonDataService(string login, string password) : base(login, password)
        {
        }

        public Supervisor GetSupervisor(string companyId, string branchId)
        {            
            var parameter = O7DbParameterCollection.Make;
            parameter.Add(O7Parameter.Make("COMPANY", companyId));
            parameter.Add(O7Parameter.Make("BRANCH", branchId));
            return DataAccess.ExecuteFunction<Supervisor>("SUPPORT.GET_SUPERVISOR", parameter, SupervisorDataMapper.Class).FirstOrDefault();   
        }

        public List<CentroCosto> GetCentroCostos(string companyId, string branchId)
        {            
            var parameter = O7DbParameterCollection.Make;
            parameter.Add(O7Parameter.Make("p_company", companyId));
            parameter.Add(O7Parameter.Make("p_branch", branchId));
            return DataAccess.ExecuteFunction<CentroCosto>("common_function.list_cost_center", parameter, CentroCostoDataMapper.Class);
        }
    }
}