using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TaskTracker.Contracts.Entities;

namespace TaskTracker.Infrastructure.EFCore.Data
{
    public class TaskTrackerDbContext : DbContext
    {
        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<TaskEntity> Tasks { get; set; }
        public virtual DbSet<ProjectEntity> Projects { get; set; }
    }
}
