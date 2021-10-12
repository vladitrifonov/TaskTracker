using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.Contracts.HandlersContracts;

namespace TaskTracker.Application.Core.Projects.Queries
{
    public class GetTaskQuery : IRequest<TaskViewModel>, IStorageInt
    {
        public int Id { get ; set; }
    }

    public class GetTaskQueryHandler : GetBaseQueryHandler<TaskViewModel, TaskEntity, GetTaskQuery>
    { 
        public GetTaskQueryHandler(IRepository<TaskEntity> taskRepository, IMapper mapper) : base(taskRepository, mapper)
        {           
            
        }
    }
}
