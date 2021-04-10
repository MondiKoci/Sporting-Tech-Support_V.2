using GBCSporting2021_TheDevelopers.Models;
using System.Collections.Generic;
namespace GBCSporting2021_TheDevelopers.IRepositories
{
    public interface IRegistrationRepository : IGenericRepository<Registration>
    {
        public List<Registration> GetAllRegistrations();
        public List<Registration> GetRegistrationsByCustomer(int id);
        public Registration GetRegistrationById(int id);
    }
}
