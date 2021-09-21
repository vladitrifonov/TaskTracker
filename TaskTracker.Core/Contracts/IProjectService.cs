using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTracker.Core.Dto;

namespace TaskTracker.Core.Contracts
{
    public interface IProjectService
    {
        Task MakeProject(ProjectDto projectDto);
        Task<TaskDto> GetProject(int? id);
        Task<IEnumerable<ProjectDto>> GetProjects();
    }
}
