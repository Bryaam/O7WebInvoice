// Create by Felix A. Bueno
using System.Collections.Generic;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Framework.Infrastructure.Data;
using Angkor.O7Web.Common.Advisory.Entity;
using Angkor.O7Web.Data.Advisory.DataMapper;

namespace Angkor.O7Web.Data.Advisory
{
    public class ActivityDataService : O7AbstractData
    {
        public ActivityDataService(string login, string password) : base(login, password)
        {
        }
        
        public bool InsertActivity(string companyId, string branchId, string centerCostId, string periodId, string activityStart, string activityDescription)
        {            
            var parameter = O7DbParameterCollection.Make;
            parameter.Add(O7Parameter.Make("p_company", companyId));
            parameter.Add(O7Parameter.Make("p_branch", branchId));
            parameter.Add(O7Parameter.Make("p_cost_center", centerCostId));
            parameter.Add(O7Parameter.Make("p_period_id", periodId));
            parameter.Add(O7Parameter.Make("p_activity_start", activityStart));
            parameter.Add(O7Parameter.Make("p_description", activityDescription));
            return DataAccess.ExecuteFunction<int>("advisory_activity.insert_activity", parameter) != 0;            
        }

        public List<Activity> ListActivities(string companyId, string branchId, string startDate, string endDate)
        {            
            var parameter = O7DbParameterCollection.Make;
            parameter.Add(O7Parameter.Make("p_company", companyId));
            parameter.Add(O7Parameter.Make("p_branch", branchId));
            parameter.Add(O7Parameter.Make("p_start_date", startDate));
            parameter.Add(O7Parameter.Make("p_end_date", endDate));                
            return DataAccess.ExecuteFunction<Activity>("advisory_activity.list_activities", parameter, ActivityDataMapper.Class);
        }

        public List<ActivityReport> ListActivityReports(string companyId, string branchId, string workerId, string workerName, 
            string workerLastName, string workerSecondLastName, string costCenterId, string startActivity, string endActivity)
        {            
            var parameter = O7DbParameterCollection.Make;
            parameter.Add(O7Parameter.Make("p_company", companyId));
            parameter.Add(O7Parameter.Make("p_branch", branchId));
            parameter.Add(O7Parameter.Make("p_worker_id", workerId));
            parameter.Add(O7Parameter.Make("p_worker_name", workerName));
            parameter.Add(O7Parameter.Make("p_worker_last_name", workerLastName));
            parameter.Add(O7Parameter.Make("p_worker_second_last_name", workerSecondLastName));
            parameter.Add(O7Parameter.Make("p_cost_center_id", costCenterId));
            parameter.Add(O7Parameter.Make("p_start_date", startActivity));
            parameter.Add(O7Parameter.Make("p_end_date", endActivity));
            return DataAccess.ExecuteFunction<ActivityReport>("advisory_activity.list_activities_by_worker", parameter, ActivityReportDataMapper.Class);
        }
    }
}