using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Angkor.O7Framework.Web;
using Angkor.O7Framework.Web.WebResult;

namespace Angkor.O7Web.Domain.Common.ErrorResponseComponents
{
    public class ErrorResponse
    {
        public static O7RedirectResult Make(int code, string message)
        {
            //TODO Error log on db
            return O7HttpResult.MakeRedirectError(code, message);
        }
    }
}
