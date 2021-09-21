using System;
using TaskTracker.Storage.Contracts;
using TaskTracker.Storage.Repositories;

namespace TaskTracker.Storage
{
    public class UnitOfWork : IDisposable
    {
        public UnitOfWork(IFactory<TaskTrackerDbContext> factory)
        {
            _factory = factory;
        }
        private readonly IFactory<TaskTrackerDbContext> _factory;
        private TaskRepository _taskRepository;
        private ProjectRepository _projectRepository;

        public TaskRepository Tasks
        {
            get
            {
                if (_taskRepository == null)
                    _taskRepository = new TaskRepository(db);
                return _taskRepository;
            }
        }

        public ProjectRepository Projects
        {
            get
            {
                if (_projectRepository == null)
                    _projectRepository = new ProjectRepository(db);
                return _projectRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
