using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTracker.Storage.Contracts;


namespace TaskTracker.Storage.Repositories
{
    public class ProjectRepository : IRepository<Entities.Project>
    {
        private readonly IFactory<TaskTrackerDbContext> _factory;
        public ProjectRepository(IFactory<TaskTrackerDbContext> factory)
        {
            _factory = factory;
        }
        public Task<IEnumerable<Entities.Project>> GetAll()
        {
            using TaskTrackerDbContext dbContext = _factory.Create();

            return Task.FromResult(dbContext.Projects.AsEnumerable());
        }
        public Task<IEnumerable<Entities.Project>> Find(Func<Entities.Project, bool> predicate)
        {
            using TaskTrackerDbContext dbContext = _factory.Create();

            return Task.FromResult(dbContext.Projects.Where(predicate).AsEnumerable());
        }

        public Task<Entities.Project> Get(int id)
        {
            using TaskTrackerDbContext dbContext = _factory.Create();

            return Task.FromResult(dbContext.Projects.FirstOrDefault(x => x.Id == id));
        }
        public async Task<bool> Create(Entities.Project item)
        {
            using TaskTrackerDbContext dbContext = _factory.Create();

            dbContext.Projects.Add(item);

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
        public async Task<bool> Update(Entities.Project item)
        {
            using TaskTrackerDbContext dbContext = _factory.Create();

            dbContext.Projects.Update(item);

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

            Entities.Project entity = dbContext.Projects.FirstOrDefault(x => x.Id == id);

            if(entity == null)
            {
                return false;
            }

            dbContext.Projects.Remove(entity);

            try
            {
                await dbContext.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                //place for log
                return false;
            }
        }
    }
}
