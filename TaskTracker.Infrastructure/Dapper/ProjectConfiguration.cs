using TaskTracker.Infrastructure.Dapper.Data;

namespace TaskTracker.Infrastructure.Dapper
{   
    public class ProjectConfiguration : DapperConfiguration
    {
        public ProjectConfiguration(string table, CommonHelper helper) : base(table, helper)
        {

        }   
    }
}
