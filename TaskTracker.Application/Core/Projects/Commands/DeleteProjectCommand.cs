using MediatR;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.Contracts.HandlersContracts;
using TaskTracker.Domain.DataTypes;

namespace TaskTracker.Application.Core.Projects.Commands
{
    public class DeleteProjectCommand : IRequest<VoidType>, IStorageInt
    {
        public int Id { get; set; }
    }

    public class DeleteProjectCommandHandler : DeleteBaseCommandHandler<VoidType, ProjectEntity, DeleteProjectCommand>
    {
        public DeleteProjectCommandHandler(IRepository<ProjectEntity> repository, IMapper mapper, Domain.Contracts.INotification notification) : base(repository, mapper, notification)
        {
        }
    }
}

