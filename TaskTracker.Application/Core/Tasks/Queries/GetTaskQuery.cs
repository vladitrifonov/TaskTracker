using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;

namespace TaskTracker.Application.Core.Projects.Queries
{
    public class GetTaskQuery : GetBaseQuery<TaskViewModel>
    {
    }

    public class GetTaskQueryHandler : GetBaseQueryHandler<TaskViewModel, TaskEntity>
    { 
        public GetTaskQueryHandler(IRepository<TaskEntity> taskRepository, IMapper mapper) : base(taskRepository, mapper)
        {           
            
        }
    }
}
