using TaskTracker.Infrastructure.Dapper.Data;

namespace TaskTracker.Infrastructure.Dapper
{
    public class TaskConfiguration : DapperConfiguration
    {
        public TaskConfiguration(string table, CommonHelper helper) : base(table, helper)
        {

        }
    }
}
