using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.Exceptions;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.Contracts.HandlersContracts;
using TaskTracker.Domain.DataTypes;

namespace TaskTracker.Application.Core.Projects.Commands
{
    public class UpdateProjectCommand : IRequest<VoidType>, IStorageIntAndViewModel<ProjectViewModel>
    {
        public int Id { get; set; }
        public ProjectViewModel ViewModel { get; set; }
    }

    public class UpdateProjectCommandHandler : UpdateBaseCommandHandler<ProjectViewModel, VoidType, ProjectEntity, UpdateProjectCommand>
    {
        public UpdateProjectCommandHandler(IRepository<ProjectEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
