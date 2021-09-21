using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Storage.Contracts;

namespace TaskTracker.Storage.Repositories
{
    public class TaskRepository : IRepository<Entities.Task>
    {
        private readonly IFactory<TaskTrackerDbContext> _factory;
        public TaskRepository(IFactory<TaskTrackerDbContext> factory)
        {
            _factory = factory;
        }
        public Task<IEnumerable<Entities.Task>> GetAll()
        {
            using TaskTrackerDbContext dbContext = _factory.Create();

            return Task.FromResult(dbContext.Tasks.AsEnumerable());
        }
        public Task<IEnumerable<Entities.Task>> Find(Func<Entities.Task, bool> predicate)
        {
            using TaskTrackerDbContext dbContext = _factory.Create();

            return Task.FromResult(dbContext.Tasks.Where(predicate).AsEnumerable());
        }

        public Task<Entities.Task> Get(int id)
        {
            using TaskTrackerDbContext dbContext = _factory.Create();

            return Task.FromResult(dbContext.Tasks.FirstOrDefault(x => x.Id == id));
        }
        public async Task<bool> Create(Entities.Task item)
        {
            using TaskTrackerDbContext dbContext = _factory.Create();

            dbContext.Tasks.Add(item);

            try
            {
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                //place for log
                return false;
            }
        }
        public async Task<bool> Update(Entities.Task item)
        {
            using TaskTrackerDbContext dbContext = _factory.Create();

            dbContext.Tasks.Update(item);

            try
            {
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                //place for log
                return false;
            }
        }
        public async Task<bool> Delete(int id)
        {
            using TaskTrackerDbContext dbContext = _factory.Create();

            Entities.Project entity = dbContext.Tasks.FirstOrDefault(x => x.Id == id);

            if (entity == null)
            {
                return false;
            }

            dbContext.Projects.Remove(entity);

            try
            {
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                //place for log
                return false;
            }
        }
    }
}
