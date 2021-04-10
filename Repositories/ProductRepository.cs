using GBCSporting2021_TheDevelopers.Models;
using GBCSporting2021_TheDevelopers.IRepositories;
using System.Collections.Generic;
using System.Linq;

namespace GBCSporting2021_TheDevelopers.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(SportContext context) : base(context)
        {

        }

        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return context.Products.Find(id);
        }
    }
}
