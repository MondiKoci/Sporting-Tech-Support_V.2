using GBCSporting2021_TheDevelopers.Models;
using System.Collections.Generic;

namespace GBCSporting2021_TheDevelopers.IRepositories
{
    public interface ICountryRepository : IGenericRepository<Country>
    {

        public List<Country> GetAllCountries();
    }
}
