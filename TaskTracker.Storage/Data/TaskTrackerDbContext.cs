using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskTracker.Contracts.DataTypes;
using Task = TaskTracker.Contracts.DataTypes.Task;

namespace TaskTracker.Storage.Data
{
    public class TaskTrackerDbContext : DbContext
    {
        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Task>().HasKey(e => e.Id);
            modelBuilder.Entity<Task>().Property(x => x.Name).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Project>().HasKey(e => e.Id);
            modelBuilder.Entity<Project>().Property(x => x.Name).HasMaxLength(50).IsRequired();
        }

        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
    }
}
