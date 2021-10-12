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
    public class GetTasksQuery : IRequest<List<TaskViewModel>>
    {
    }

    public class GetTasksQueryHandler : GetBasesQueryHandler<TaskViewModel, TaskEntity, GetTasksQuery>
    {
        public GetTasksQueryHandler(IRepository<TaskEntity> taskRepository, IMapper mapper) : base(taskRepository, mapper)
        {
        }
    }
}
