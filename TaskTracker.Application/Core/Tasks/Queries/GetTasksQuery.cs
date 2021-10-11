using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using System.Collections.Generic;

namespace TaskTracker.Application.Core.Projects.Queries
{
    public class GetTasksQuery : GetBasesQuery<TaskViewModel>
    {
    }

    public class GetTasksQueryHandler : GetBasesQueryHandler<TaskViewModel, TaskEntity>
    {
        public GetTasksQueryHandler(IRepository<TaskEntity> taskRepository, IMapper mapper) : base(taskRepository, mapper)
        {
        }
    }    
}
