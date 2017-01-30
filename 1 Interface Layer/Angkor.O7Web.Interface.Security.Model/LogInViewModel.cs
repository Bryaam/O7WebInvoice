// Create by Felix A. Bueno

using Angkor.O7Framework.Web.Base;

namespace Angkor.O7Web.Interface.Security.Model
{
    public class LogInViewModel : O7ViewModel
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public string CompanyId { get; set; }
        public string BranchId { get; set; }

        public override bool ValidViewModel
        {
            get
            {
                if (string.IsNullOrEmpty(Login))
                {
                    ValidationErrorMessages.Add("El campo de login es requerido");                    
                }
                if (string.IsNullOrEmpty(Password))
                {
                    ValidationErrorMessages.Add("El campo password es requerido");                    
                }
                if (string.IsNullOrEmpty(CompanyId))
                {
                    ValidationErrorMessages.Add("No se eligio correctamente la compañia");                    
                }
                if (string.IsNullOrEmpty(BranchId))
                {
                    ValidationErrorMessages.Add("No se eligio correctamente la sucursal");
                }
                return ValidationErrorMessages.Count <= 0;
            }
        }
    }
}