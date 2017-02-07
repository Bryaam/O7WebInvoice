// O7ERP Web created by felix_dev

using Angkor.O7Framework.Data.Model;

namespace Angkor.O7Web.Data.Finantial.Entity
{
    public class ClientDetailDbEntity : O7DbEntity
    {
        public string Id { get; set; }
        public string Origin { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Ruc { get; set; }
        public string Country { get; set; }
        public string Zone { get; set; }
        public string Address { get; set; }
        public string Postale { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string DocumentIdentifier { get; set; }
        public string DocumentIdentifierType { get; set; }
        public string EntryDate { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
    }
}