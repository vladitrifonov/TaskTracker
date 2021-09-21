using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTracker.Storage.Contracts;
using TaskTracker.Storage.Entities;

namespace TaskTracker.Storage.Repositories
{
    public class ProjectRepository : IRepository<Project>
    {
        private readonly TaskTrackerDbContext _dbContext;
        public ProjectRepository(TaskTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<IEnumerable<Project>> GetAll()
        {
            throw new System.NotImplementedException();
        }
        public Task<Project> Get(int id)
        {
            throw new System.NotImplementedException();
        }
        public Task<bool> Create(Project item)
        {
            throw new System.NotImplementedException();
        }
        public Task<bool> Update(Project item)
        {
            throw new System.NotImplementedException();
        }
        public Task<bool> Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
