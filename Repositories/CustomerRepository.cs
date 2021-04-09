using GBCSporting2021_TheDevelopers.Models;
using GBCSporting2021_TheDevelopers.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace GBCSporting2021_TheDevelopers.Repositories
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SportContext context) : base(context)
        {

        }

        public List<Customer> GetAllCustomers()
        {
            return context.Customers.ToList();
        }
    }
}
