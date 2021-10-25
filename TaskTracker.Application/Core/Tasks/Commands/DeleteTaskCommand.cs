using MediatR;
using TaskTracker.Application.Core.Projects.Commands;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.Contracts.HandlersContracts;
using TaskTracker.Domain.DataTypes;

namespace TaskTracker.Application.Core.Tasks.Commands
{
    public class DeleteTaskCommand : IRequest<VoidType>, IStorageInt
    {
        public int Id { get; set; }
    }

    public class DeleteTaskCommandHandler : DeleteBaseCommandHandler<VoidType, TaskEntity, DeleteTaskCommand>
    {
        public DeleteTaskCommandHandler(IRepository<TaskEntity> repository, IMapper mapper, Domain.Contracts.INotification notification) : base(repository, mapper, notification)
        {
        }
    }
}

