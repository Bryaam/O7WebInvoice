// Create by Felix A. Bueno
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Utility;
using Angkor.O7Web.Domain.Security.Base;
using Angkor.O7Web.Domain.Security.Tools;

namespace Angkor.O7Web.Domain.Security
{
    public class SecurityFlow : SecurityDomain
    {
        public SecurityFlow(string login, string password) : base(login, password)
        {            
        }

        public override O7Response Companies()
        {            
            var companies = SecurityDataService.Companies();
            var companiesSerialized = O7JsonSerealizer.Serialize(companies);
            return O7SuccessResponse.MakeResponse(companiesSerialized);    
        }

        public override O7Response Branches(string companyId)
        {
            var companies = SecurityDataService.Branches(companyId);
            var companiesSerialized = O7JsonSerealizer.Serialize(companies);
            return O7SuccessResponse.MakeResponse(companiesSerialized);
        }

        public override O7Response Menus(string companyId, string branchId, string menuId)
        {
            var menus = SecurityDataService.Menus(companyId, branchId, menuId);
            var sortedMenus = Algorithm.SortMenus(menus, menuId);
            return O7SuccessResponse.MakeResponse(sortedMenus);
        }

        public override O7Response ValidAccess(string companyId, string branchId, string menuId)
        {
            var result = SecurityDataService.ValidAccess(companyId, branchId, menuId);
            return O7SuccessResponse.MakeResponse(result);
        }

        public override O7Response UserName(string companyId, string branchId)
        {
            var userName = SecurityDataService.UserName(companyId, branchId);
            return O7SuccessResponse.MakeResponse(userName);
        }

        public override O7Response AllModules(string companyId, string branchId)
        {
            var modules = SecurityDataService.AllModules(companyId, branchId);
            return O7SuccessResponse.MakeResponse(modules);
        }

        public override O7Response AnotherModules(string companyId, string branchId, string moduleId)
        {
            var modules = SecurityDataService.AnotherModules(companyId, branchId, moduleId);
            return O7SuccessResponse.MakeResponse(modules);
        }        
    }
}