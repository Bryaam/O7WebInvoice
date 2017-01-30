namespace Angkor.O7Web.Common.Finantial.Entity
{
    public class AddressEnt
    {
        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public AddressEnt()
        {
        }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object" /> class.</summary>
        public AddressEnt(string address, string codPostal, string department, string province, string district, string city, string country, string zone, string route, string phone, string fax, string contact)
        {
            Address = address;
            CodPostal = codPostal;
            Department = department;
            Province = province;
            District = district;
            City = city;
            Country = country;
            Zone = zone;
            Route = route;
            Phone = phone;
            Fax = fax;
            Contact = contact;
        }

        public string CodDir { get; set; }
        public string Address { get; set; }
        public string CodPostal { get; set; }
        public string Department { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Zone { get; set; }
        public string Route { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Contact { get; set; }

    }
}
