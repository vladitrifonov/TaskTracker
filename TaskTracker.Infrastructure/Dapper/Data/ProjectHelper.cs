using System.Collections.Generic;
using TaskTracker.Contracts.Entities;

namespace TaskTracker.Infrastructure.Dapper.Data
{
    public class ProjectHelper : CommonHelper
    {
        protected override IEnumerable<string> GetFields()
        {
            yield return nameof(ProjectEntity.Name);
            yield return nameof(ProjectEntity.StartDate);
            yield return nameof(ProjectEntity.CompletionDate);
            yield return nameof(ProjectEntity.Status);
            yield return nameof(ProjectEntity.Priority);
        }
    }
}
