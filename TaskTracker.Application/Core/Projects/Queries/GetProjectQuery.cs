using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.Contracts.HandlersContracts;

namespace TaskTracker.Application.Core.Projects.Queries
{
    public class GetProjectQuery : IRequest<ProjectViewModel>, IStorageInt
    {
        public int Id { get; set; }
    }

    public class GetProjectQueryHandler : GetBaseQueryHandler<ProjectViewModel, ProjectEntity, GetProjectQuery>
    {      
        private readonly IRepository<TaskEntity> _taskRepository;
      
        public GetProjectQueryHandler(IRepository<ProjectEntity> projectRepository, IMapper mapper, IRepository<TaskEntity> taskRepository)
            : base(projectRepository, mapper)
        {           
            _taskRepository = taskRepository;            
        }

        public override async Task<ProjectViewModel> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            ProjectViewModel projectViewModel = await base.Handle(request, cancellationToken);

            projectViewModel.Tasks = await _taskRepository.GetByPredicateAsync(x => x.ProjectId == projectViewModel.Id);

            return projectViewModel;
        }       
    }
}
