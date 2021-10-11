using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.Exceptions;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.DataTypes;

namespace TaskTracker.Application.Core.Projects.Commands
{
    public class UpdateProjectCommand : UpdateBaseCommand<ProjectViewModel, VoidType>
    {
    }

    public class UpdateProjectCommandHandler : UpdateBaseCommandHandler<ProjectViewModel, VoidType, ProjectEntity>
    {
        public UpdateProjectCommandHandler(IRepository<ProjectEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
