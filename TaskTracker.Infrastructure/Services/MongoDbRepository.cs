using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;

namespace TaskTracker.Infrastructure.Services
{
    public class MongoDbRepository<T> : IRepository<T> where T : BaseEntity
    {
        public async Task<IEnumerable<T>> GetAsync()
        {
            using TaskTrackerDbContext dbContext = _dbFactory.Create();

            return await dbContext.Set<T>().ToListAsync();
        }

        public Task<IEnumerable<T>> GetByPredicateAsync(Expression<Func<T, bool>> predicate)
        {
            using TaskTrackerDbContext dbContext = _dbFactory.Create();

            return Task.FromResult(dbContext.Set<T>().Where(predicate).AsEnumerable());
        }

        public async Task<T> GetByIdAsync(int id)
        {
            using TaskTrackerDbContext dbContext = _dbFactory.Create();
            var qwer = await dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
            return await dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> CreateAsync(T entity)
        {
            using TaskTrackerDbContext dbContext = _dbFactory.Create();

            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> UpdateAsync(T entity)
        {
            using TaskTrackerDbContext dbContext = _dbFactory.Create();

            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            using TaskTrackerDbContext dbContext = _dbFactory.Create();

            dbContext.Set<T>().Remove(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
