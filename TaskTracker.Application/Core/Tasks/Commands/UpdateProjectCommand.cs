using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.Exceptions;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Application.Core.Projects.Commands;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.DataTypes;

namespace TaskTracker.Application.Core.Tasks.Commands
{
    public class UpdateTaskCommand : UpdateBaseCommand<TaskViewModel, VoidType>
    {
    }

    public class UpdateTaskCommandHandler : UpdateBaseCommandHandler<TaskViewModel, VoidType, TaskEntity>
    {
        public UpdateTaskCommandHandler(IRepository<TaskEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
