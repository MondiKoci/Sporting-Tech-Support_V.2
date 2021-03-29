using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GBCSporting2021_TheDevelopers.Models
{
    public class RegistrationSession
    {
        private const string CustomersKey = "myCustomer";

        private ISession session { get; set; }
        public RegistrationSession(ISession session)
        {
            this.session = session;
        }

        public void SetCustomer(Customer customer)
        {
            session.SetObject(CustomersKey, customer);
        }

        public Customer GetCustomer()
        {
            return session.GetObject<Customer>(CustomersKey) ?? new Customer();
        }

        public void RemoveCustomer()
        {
            session.Remove(CustomersKey);
        }
    }
}
