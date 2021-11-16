using System.Collections.Generic;
using TaskTracker.Contracts.Entities;

namespace TaskTracker.Infrastructure.Dapper.Data
{
    public class TaskHelper : CommonHelper
    {
        protected override IEnumerable<string> GetFields()
        {
            yield return nameof(TaskEntity.ProjectId);
            yield return nameof(TaskEntity.Name);
            yield return nameof(TaskEntity.Status);
            yield return nameof(TaskEntity.Description);
            yield return nameof(TaskEntity.Priority);
        }
    }
}
