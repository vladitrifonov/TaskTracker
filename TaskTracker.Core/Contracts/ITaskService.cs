using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTracker.Core.Dto;

namespace TaskTracker.Core.Contracts
{
    public interface TaskService
    {
        Task MakeTask(TaskDto taskDto);
        Task<TaskDto> GetTask(int? id);
        Task<IEnumerable<TaskDto>> GetTasks();
    }
}
