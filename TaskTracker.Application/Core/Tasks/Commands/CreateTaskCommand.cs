using MediatR;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Application.Core.Projects.Commands;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.Contracts.HandlersContracts;
using TaskTracker.Domain.DataTypes;

namespace TaskTracker.Application.Core.Tasks.Commands
{
    public class CreateTaskCommand : IRequest<VoidType>, IStorageViewModel<TaskViewModel>
    {
        public TaskViewModel ViewModel { get; set; }
    }

    public class CreateTaskCommandHandler : CreateBaseCommandHandler<TaskViewModel, VoidType, TaskEntity, CreateTaskCommand>
    {
        public CreateTaskCommandHandler(IRepository<TaskEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
