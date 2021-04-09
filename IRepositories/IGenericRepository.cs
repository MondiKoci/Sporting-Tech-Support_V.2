using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GBCSporting2021_TheDevelopers.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {
 
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        void Insert(T entity);
        Task<bool> Add(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        void Save();
    }
}
