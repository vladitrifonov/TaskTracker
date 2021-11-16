using TaskTracker.Infrastructure.Dapper.Data;

namespace TaskTracker.Infrastructure.Dapper
{
    //!!!prefer composition over inheritance!!!
    public class ProjectConfiguration : DapperConfiguration
    {
        //private readonly string Projects = nameof(Projects);
        //private readonly CommonHelper _projectHelper = new ProjectHelper();
                
        public ProjectConfiguration(string table, CommonHelper helper) : base(table, helper)
        {

        }   
    }
}
