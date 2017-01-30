// Create by Felix A. Bueno

using System.Collections.Generic;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Framework.Infrastructure.Data;
using Angkor.O7Web.Common.Advisory.Entity;
using Angkor.O7Web.Data.Advisory.DataMapper;

namespace Angkor.O7Web.Data.Advisory
{
    public class PeriodDataService : O7AbstractData
    {
        public PeriodDataService(string login, string password) : base(login, password)
        {
        }

        public List<Period> ListPeriods(string companyId, string branchId)
        {            
            var parameter = O7DbParameterCollection.Make;
            parameter.Add(O7Parameter.Make("COMPANY", companyId));
            parameter.Add(O7Parameter.Make("BRANCH", branchId));
            return DataAccess.ExecuteFunction<Period>("ADVISORY_PERIOD.LIST_PERIODS", parameter, PeriodDataMapper.Class);            
        }

        public List<Year> ListAvalibleYears(string companyId, string branchId)
        {            
            var parameter = O7DbParameterCollection.Make;
            parameter.Add(O7Parameter.Make("p_company", companyId));
            parameter.Add(O7Parameter.Make("p_branch", branchId));
            return DataAccess.ExecuteFunction<Year>("ADVISORY_PERIOD.list_avalible_year", parameter, PeriodStateDataMapper.Class);
        }

        public bool ValidPeriod(string companyId, string branchId, string month, string year)
        {            
            var parameter = O7DbParameterCollection.Make;
            parameter.Add(O7Parameter.Make("p_company", companyId));
            parameter.Add(O7Parameter.Make("p_branch", branchId));
            parameter.Add(O7Parameter.Make("p_month", month));
            parameter.Add(O7Parameter.Make("p_year", year));
            return DataAccess.ExecuteFunction<int>("ADVISORY_PERIOD.valid_period_id", parameter) > 0;
        }

        public bool ActivateYear(string companyId, string branchId, string periodId)
        {            
            var parameter = O7DbParameterCollection.Make;
            parameter.Add(O7Parameter.Make("COMPANY", companyId));
            parameter.Add(O7Parameter.Make("BRANCH", branchId));
            parameter.Add(O7Parameter.Make("YEAR", periodId));
            return DataAccess.ExecuteFunction<int>("ADVISORY_PERIOD.ACTIVATE_YEAR", parameter) != 0;         
        }

        public bool OpenPeriod(string companyId, string branchId, string periodId)
        {            
            var parameter = O7DbParameterCollection.Make;
            parameter.Add(O7Parameter.Make("p_company", companyId));
            parameter.Add(O7Parameter.Make("p_branch", branchId));
            parameter.Add(O7Parameter.Make("p_period_id", periodId));
            return DataAccess.ExecuteFunction<int>("ADVISORY_PERIOD.active_period", parameter) != 0;
        }

        public bool ClosePeriod(string companyId, string branchId, string periodId)
        {
            var parameter = O7DbParameterCollection.Make;
            parameter.Add(O7Parameter.Make("p_company", companyId));
            parameter.Add(O7Parameter.Make("p_branch", branchId));
            parameter.Add(O7Parameter.Make("p_period_id", periodId));
            return DataAccess.ExecuteFunction<int>("ADVISORY_PERIOD.close_period", parameter) != 0;         
        }
    }
}