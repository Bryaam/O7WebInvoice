// O7ERP Web created by 

using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Infrastructure;
using Angkor.O7Web.Data.Security;

namespace Angkor.O7Web.Domain.Security.Base
{
    public abstract class SecurityDomain
    {
        public SecurityDataService SecurityDataService { get; private set; }

        protected SecurityDomain(string login, string password)
        {
            SecurityDataService = O7DataInstanceMaker.MakeInstance<SecurityDataService>(new object[] {login, password});
        }

        public abstract O7Response Companies();

        public abstract O7Response Branches(string companyId);

        public abstract O7Response Menus(string companyId, string branchId, string menuId);

        public abstract O7Response ValidAccess(string companyId, string branchId, string menuId);

        public abstract O7Response UserName(string companyId, string branchId);

        public abstract O7Response AllModules(string companyId, string branchId);
        public abstract O7Response AnotherModules(string companyId, string branchId, string moduleId);
    }
}