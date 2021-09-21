using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Contracts.Contracts;
using TaskTracker.Contracts.DataTypes;
using TaskTracker.Storage.Data;
using Task = System.Threading.Tasks.Task;

namespace TaskTracker.Core
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IFactory<TaskTrackerDbContex> _dbFactory;

        public EfRepository(IFactory<TaskTrackerDbContex> dbFactory)
        {
            _dbFactory = dbFactory;
        }

        public async Task<List<T>> ListAsync()
        {
            using TaskTrackerDbContex dbContext = _dbFactory.Create();

            return await dbContext.Set<T>().ToListAsync();
        }

        public Task<IEnumerable<T>> GetByPredicateAsync(Func<T, bool> predicaste)
        {
            using TaskTrackerDbContex dbContext = _dbFactory.Create();

            return Task.FromResult(dbContext.Set<T>().Where(predicaste).AsEnumerable());
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using TaskTrackerDbContex dbContext = _dbFactory.Create();

            return await dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> AddAsync(T entity)
        {
            using TaskTrackerDbContex dbContext = _dbFactory.Create();

            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            using TaskTrackerDbContex dbContext = _dbFactory.Create();

            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            using TaskTrackerDbContex dbContext = _dbFactory.Create();

            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
