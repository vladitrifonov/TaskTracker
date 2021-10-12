using MediatR;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.Contracts.HandlersContracts;
using TaskTracker.Domain.DataTypes;
using INotification = TaskTracker.Domain.Contracts.INotification;

namespace TaskTracker.Application.Core.Projects.Commands
{
    public class CreateProjectCommand : IRequest<VoidType>, IStorageViewModel<ProjectViewModel>
    {
        public ProjectViewModel ViewModel { get; set; }
    }

    public class CreateProjectCommandHandler : CreateBaseCommandHandler<ProjectViewModel, VoidType, ProjectEntity, CreateProjectCommand>
    {
        public CreateProjectCommandHandler(IRepository<ProjectEntity> repository, IMapper mapper, INotification notification) : base(repository, mapper, notification)
        {
        }
    }
}
