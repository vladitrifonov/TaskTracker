using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace TaskTracker.Infrastructure.EFCore.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<TaskTrackerDbContext>
    {
        public TaskTrackerDbContext CreateDbContext(string[] args)
        {
            var builder = new ConfigurationBuilder()
                       .SetBasePath(Directory.GetCurrentDirectory())
                       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                       .AddEnvironmentVariables();

            IConfigurationRoot configuration = builder.Build();
            string connectionString = configuration.GetConnectionString(nameof(TaskTrackerDbContext));
            var optionsBuilder = new DbContextOptionsBuilder<TaskTrackerDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
        
            return new TaskTrackerDbContext(optionsBuilder.Options, configuration);
        }
    }
}
