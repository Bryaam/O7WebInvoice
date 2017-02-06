// O7ERP Web created by felix_dev
using Angkor.O7Framework.Data.Model;

namespace Angkor.O7Web.Data.Finantial.Entity
{
    public class ClientDbEntity : O7DbEntity
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string DocumentCode { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
    }
}