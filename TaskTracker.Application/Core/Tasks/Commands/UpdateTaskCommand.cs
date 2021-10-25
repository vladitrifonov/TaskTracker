using MediatR;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Application.Core.Projects.Commands;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.Contracts.HandlersContracts;
using TaskTracker.Domain.DataTypes;

namespace TaskTracker.Application.Core.Tasks.Commands
{
    public class UpdateTaskCommand : IRequest<VoidType>, IStorageIntAndViewModel<TaskViewModel>
    {
        public int Id { get; set; }
        public TaskViewModel ViewModel { get; set; }
    }

    public class UpdateTaskCommandHandler : UpdateBaseCommandHandler<TaskViewModel, VoidType, TaskEntity, UpdateTaskCommand>
    {
        public UpdateTaskCommandHandler(IRepository<TaskEntity> repository, IMapper mapper, Domain.Contracts.INotification notification) : base(repository, mapper, notification)
        {
        }
    }
}
