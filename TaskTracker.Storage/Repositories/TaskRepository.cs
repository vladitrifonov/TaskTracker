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
        private readonly TaskTrackerDbContext _dbContext;
        public TaskRepository(TaskTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<IEnumerable<Entities.Task>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Entities.Task> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Create(Entities.Task item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(Entities.Task item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
