using GBCSporting2021_TheDevelopers.IRepositories;
using GBCSporting2021_TheDevelopers.Models;

namespace GBCSporting2021_TheDevelopers.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
       
        public CountryRepository(SportContext context) : base(context)
        {

        }

    }
}
