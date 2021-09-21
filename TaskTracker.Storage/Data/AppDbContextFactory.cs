using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TaskTracker.Storage.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<TaskTrackerDbContext>
    {
        public TaskTrackerDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaskTrackerDbContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDb;Initial Catalog=TaskTrackerDB;Integrated Security=true");

            return new TaskTrackerDbContext(optionsBuilder.Options);
        }
    }
}
