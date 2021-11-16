using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Infrastructure.Dapper.Data;

namespace TaskTracker.Infrastructure.Dapper
{
    //!!!prefer composition over inheritance!!!
    public class TaskConfiguration : DapperConfiguration
    {
        //private readonly string Tasks = nameof(Tasks);
        //private readonly CommonHelper _projectHelper = new TaskHelper();

        public TaskConfiguration(string table, CommonHelper helper) : base(table, helper)
        {

        }
    }
}
