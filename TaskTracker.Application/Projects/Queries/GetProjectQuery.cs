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
    public class GetProjectQuery : IRequest<ProjectViewModel>
    {
        public int Id { get; set; }
    }

    public class GetProjectHandler : IRequestHandler<GetProjectQuery, ProjectViewModel>
    {
        private readonly IRepository<ProjectEntity> _projectRepository;
        private readonly IRepository<TaskEntity> _taskRepository;
        private readonly IMapper _mapper;

        public GetProjectHandler(IRepository<ProjectEntity> projectRepository, IRepository<TaskEntity> taskRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<ProjectViewModel> Handle(GetProjectQuery request, CancellationToken cancellationToken)
        {
            ProjectEntity projectEntity = await _projectRepository.GetByIdAsync(request.Id);

            var projectViewModel = _mapper.Map<ProjectViewModel>(projectEntity);
                       
            projectViewModel.Tasks = await _taskRepository.GetByPredicateAsync(x => x.ProjectId == projectViewModel.Id);
            
            return projectViewModel;
        }
    }
}
