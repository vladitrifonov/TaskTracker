using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using System.Collections.Generic;

namespace TaskTracker.Application.Core.Projects.Queries
{
    public class GetProjectsQuery : IRequest<List<ProjectViewModel>>
    {
    }

    public class GetProjectsQueryHandler : GetBasesQueryHandler<ProjectViewModel, ProjectEntity, GetProjectsQuery> 
    {
        //private readonly IRepository<TaskEntity> _taskRepository;
        public GetProjectsQueryHandler(IRepository<ProjectEntity> projectRepository, IMapper mapper, IRepository<TaskEntity> taskRepository) 
            : base(projectRepository, mapper)
        {
            //_taskRepository = taskRepository;
        }

        //public override async Task<List<ProjectViewModel>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        //{
        //    List<ProjectViewModel> projects = await base.Handle(request, cancellationToken);

        //    foreach (ProjectViewModel projectViewModel in projects)
        //    {
        //        int projectViewModelId = projectViewModel.Id;
        //        projectViewModel.Tasks = await _taskRepository.GetByPredicateAsync(x => x.ProjectId == projectViewModelId);
        //    }

        //    return projects;
        //}
    }
    
}
