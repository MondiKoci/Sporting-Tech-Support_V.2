using GBCSporting2021_TheDevelopers.IRepositories;
using GBCSporting2021_TheDevelopers.Models;
using System.Collections.Generic;
using System.Linq;

namespace GBCSporting2021_TheDevelopers.Repositories
{
    public class CountryRepository : GenericRepository<Country>, ICountryRepository
    {
       
        public CountryRepository(SportContext context) : base(context)
        {

        }

        public List<Country> GetAllCountries()
        {
            return context.Countries.ToList();
        }

    }
}
