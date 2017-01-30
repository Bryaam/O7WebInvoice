// Create by Felix A. Bueno

using Angkor.O7Framework.Data;
using Angkor.O7Framework.Data.Utility;

namespace Angkor.O7Web.Data.Service
{
    public abstract class DataService
    {
        protected string DatabaseConnection;
        protected O7DataAccess DataAccess;

        protected DataService(string login, string password)
        {
            DatabaseConnection = O7Provider.DataBaseConection(login, password);
        }
    }
}