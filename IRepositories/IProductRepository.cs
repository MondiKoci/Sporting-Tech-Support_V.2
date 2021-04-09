using GBCSporting2021_TheDevelopers.Models;
using System.Collections.Generic;

namespace GBCSporting2021_TheDevelopers.IRepositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public List<Product> GetAllProducts();
    }
}
