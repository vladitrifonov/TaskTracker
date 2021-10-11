using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.DataTypes;

namespace TaskTracker.Application.Core.Projects.Commands
{
    public class DeleteProjectCommand : DeleteBaseCommand<VoidType>
    {
    }

    public class DeleteProjectCommandHandler : DeleteBaseCommandHandler<VoidType, ProjectEntity>
    {
        public DeleteProjectCommandHandler(IRepository<ProjectEntity> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}

