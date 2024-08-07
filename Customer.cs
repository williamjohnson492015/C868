using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C868
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public int AddressID { get; set; }
        public int OrganizationID { get; set; }
        public string Email { get; set; }
        public string Notes { get; set; }

        public Customer(int customerId, string customerName, string phone, string address, string address2, string city, string postalCode, string country, int addressId, int orgId, string email, string notes = "")
        {
            CustomerID = customerId;
            CustomerName = customerName;
            Phone = phone;
            Address = address;
            Address2 = address2;
            City = city;
            PostalCode = postalCode;
            Country = country;
            AddressID = addressId;
            OrganizationID = orgId;
            Email = email;
            Notes = notes;
        }
    }
}
