using GBCSporting2021_TheDevelopers.Models;
using GBCSporting2021_TheDevelopers.IRepositories;
using System.Linq;
using System.Collections.Generic;

namespace GBCSporting2021_TheDevelopers.Repositories
{
    public class RegistrationRepository : GenericRepository<Registration>, IRegistrationRepository
    {
        public RegistrationRepository(SportContext context) : base(context)
        {

        }

        public List<Registration> GetAllRegistrations()
        {
            return context.Registrations.ToList();
        }

        public List<Registration> GetRegistrationsByCustomer(int id)
        {
            return context.Registrations.Where(r => r.CustomerId == id).ToList();
        }
    }
}
