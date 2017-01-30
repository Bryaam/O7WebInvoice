// Create by Felix A. Bueno
using System;
using Angkor.O7Framework.Common.Model;
using Angkor.O7Framework.Infrastructure.Domain;
using Oracle.ManagedDataAccess.Client;

namespace Angkor.O7Web.Domain.Common
{
    public class BasicFlow : O7AbstractDomain
    {
        public BasicFlow(string userName) : base(userName)
        {
        }

        public override void OnException(Exception exception)
        {
            var oracleException = exception.InnerException as OracleException;
            var errorMessage = oracleException?.Message ?? exception.Message;
            MakeLogger(GetType());
            Logger.AppendError(errorMessage);
            SetReturnValue(O7ErrorResponse.Make(errorMessage));
        }
    }
}