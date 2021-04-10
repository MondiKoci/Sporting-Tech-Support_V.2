using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GBCSporting2021_TheDevelopers.IRepositories;
using GBCSporting2021_TheDevelopers.Models;
using Microsoft.EntityFrameworkCore;

namespace GBCSporting2021_TheDevelopers.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected SportContext context { get; set; }
        private DbSet<T> dbset { get; set; }

        public GenericRepository(SportContext scx)
        {
            context = scx;
            dbset = context.Set<T>();
        }


        public async Task<T> Get(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }


        public async Task<bool> Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            return true;
        }


        public bool Delete(T entity)
        {
            context.Set<T>().Remove(entity);
            return true;
        }

        public bool Update(T entity)
        {
            context.Set<T>().Update(entity);
            return true;
        }

        public virtual void Insert(T entity) => dbset.Add(entity);
        public virtual void Save() => context.SaveChanges();
    }
}
