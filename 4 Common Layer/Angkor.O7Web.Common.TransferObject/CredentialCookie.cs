// Create by Felix A. Bueno
namespace Angkor.O7Web.Interface.Security.Controllers.Transfer
{
    public class CredentialCookie
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }
        public string Name { get; set; }

        public CredentialCookie()
        {
        }

        public CredentialCookie(string login, string password, string companyId, string branchId, string name)
        {
            Login = login;
            Password = password;
            CompanyId = companyId;
            BranchId = branchId;
            Name = name;
        }
    }
}