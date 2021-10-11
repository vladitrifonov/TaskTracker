using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.DataTypes;

namespace TaskTracker.Application.Core.Projects.Commands
{
    public class CreateProjectCommand : CreateBaseCommand<ProjectViewModel, VoidType>
    {       
    }

    public class CreateProjectCommandHandler : CreateBaseCommandHandler<ProjectViewModel, VoidType, ProjectEntity>
    {
        public CreateProjectCommandHandler(IRepository<ProjectEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
