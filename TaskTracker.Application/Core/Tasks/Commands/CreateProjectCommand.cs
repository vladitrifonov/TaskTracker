using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Application.Core.Projects.Commands;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.DataTypes;

namespace TaskTracker.Application.Core.Tasks.Commands
{
    public class CreateTaskCommand : CreateBaseCommand<TaskViewModel, VoidType>
    {       
    }

    public class CreateTaskCommandHandler : CreateBaseCommandHandler<TaskViewModel, VoidType, TaskEntity>
    {
        public CreateTaskCommandHandler(IRepository<TaskEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
