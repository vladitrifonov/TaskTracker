using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;
using TaskTracker.Contracts.Entities;

namespace TaskTracker.Infrastructure.EFCore.Data
{
    public class TaskTrackerDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {           
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString(nameof(TaskTrackerDbContext)), builder =>
            {
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
            base.OnConfiguring(optionsBuilder);
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
