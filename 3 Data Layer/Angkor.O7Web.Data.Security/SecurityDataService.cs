// Create by Felix A. Bueno
using System.Collections.Generic;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Data.Tool;
using Angkor.O7Framework.Infrastructure.Data;
using Angkor.O7Framework.Web.Model;
using Angkor.O7Web.Common.Security.Entity;
using Angkor.O7Web.Data.Security.DataMapper;

namespace Angkor.O7Web.Data.Security
{
    public class SecurityDataService : O7AbstractData
    {
        public SecurityDataService(string login, string password) : base(login, password)
        {
        }

        public virtual string ValidAccess(string companyId, string branchId, string menuId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_menu_id", menuId));
            return DataAccess.ExecuteFunction<string>("security.is_permited", parameters);
        }

        public virtual List<Company> Companies()
            => DataAccess.ExecuteFunction<Company>("security.companies", CompanyDataMapper.Class);

        public virtual List<Branch> Branches(string companyId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            return DataAccess.ExecuteFunction<Branch>("security.branches", parameters, BranchDataMapper.Class);
        }

        public virtual List<O7Module> AllModules(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            return DataAccess.ExecuteFunction<O7Module>("security.modules_installed", parameters, ModuleDataMapper.Class);
        }

        public virtual List<O7Module> AnotherModules(string companyId, string branchId, string moduleId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_module", moduleId));
            return DataAccess.ExecuteFunction<O7Module>("security.others_modules", parameters, ModuleDataMapper.Class);
        }

        public virtual List<Menu> Menus(string companyId, string branchId, string menuId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            parameters.Add(O7Parameter.Make("p_modulo", menuId));
            return DataAccess.ExecuteFunction<Menu>("security.menus", parameters, MenuDataMapper.Class);
        }

        public virtual string UserName(string companyId, string branchId)
        {
            var parameters = O7DbParameterCollection.Make;
            parameters.Add(O7Parameter.Make("p_company", companyId));
            parameters.Add(O7Parameter.Make("p_branch", branchId));
            return DataAccess.ExecuteFunction<string>("security.get_user_name", parameters);
        }
    }
}