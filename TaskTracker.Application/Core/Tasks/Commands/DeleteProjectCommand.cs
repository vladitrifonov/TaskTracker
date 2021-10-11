using TaskTracker.Application.Core.Projects.Commands;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.DataTypes;

namespace TaskTracker.Application.Core.Tasks.Commands
{
    public class DeleteTaskCommand : DeleteBaseCommand<VoidType>
    {
    }

    public class DeleteTaskCommandHandler : DeleteBaseCommandHandler<VoidType, TaskEntity>
    {
        public DeleteTaskCommandHandler(IRepository<TaskEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

