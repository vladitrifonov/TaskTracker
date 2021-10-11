using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using System.Collections.Generic;

namespace TaskTracker.Application.Projects.Queries
{
    public class GetProjectsQuery : IRequest<List<ProjectViewModel>>
    {
    }

    public class GetProjectsQueryHandler : IRequestHandler<GetProjectsQuery, List<ProjectViewModel>>
    {
        private readonly IRepository<ProjectEntity> _projectRepository;
        private readonly IRepository<TaskEntity> _taskRepository;
        private readonly IMapper _mapper;

        public GetProjectsQueryHandler(IRepository<ProjectEntity> projectRepository, IRepository<TaskEntity> taskRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<List<ProjectViewModel>> Handle(GetProjectsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<ProjectEntity> projectsEntity = await _projectRepository.GetAsync();

            var projectsViewModel = projectsEntity.OrderBy(x => x.Id).Select(x => _mapper.Map<ProjectViewModel>(x)).AsEnumerable();

            foreach (ProjectViewModel projectViewModel in projectsViewModel)
            {
                projectViewModel.Tasks = await _taskRepository.GetByPredicateAsync(x => x.ProjectId == projectViewModel.Id);
            }

            return projectsViewModel.ToList();
        }
    }
}
