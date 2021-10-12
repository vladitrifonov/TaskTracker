using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;

namespace TaskTracker.Application.Core.Projects.Queries
{
    public class GetProjectQuery : GetBaseQuery<ProjectViewModel>
    {      
    }

    public class GetProjectQueryHandler : GetBaseQueryHandler<ProjectViewModel, ProjectEntity>
    {      
        private readonly IRepository<TaskEntity> _taskRepository;
      
        public GetProjectQueryHandler(IRepository<ProjectEntity> projectRepository, IMapper mapper, IRepository<TaskEntity> taskRepository)
            : base(projectRepository, mapper)
        {           
            _taskRepository = taskRepository;            
        }

        public override async Task<ProjectViewModel> Handle(GetBaseQuery<ProjectViewModel> request, CancellationToken cancellationToken)
        {
            ProjectViewModel projectViewModel = await base.Handle(request, cancellationToken);

            projectViewModel.Tasks = await _taskRepository.GetByPredicateAsync(x => x.ProjectId == projectViewModel.Id);

            return projectViewModel;
        }       
    }
}
