using Microsoft.EntityFrameworkCore;
using TaskTracker.Storage.Entities;

namespace TaskTracker.Storage
{
    public class TaskTrackerDbContext : DbContext
    {
        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasOne(x => x.Project).WithMany(x => x.Tasks);
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Project> Projects { get; set; }       
    }
}
