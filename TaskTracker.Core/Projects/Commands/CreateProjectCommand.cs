using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.DataTypes;

namespace TaskTracker.Application.Projects.Commands
{
    public class CreateProjectCommand : IRequest<VoidType>
    {
        public ProjectViewModel ProjectViewModel { get; set; }
    }

    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, VoidType>
    {
        private readonly IRepository<ProjectEntity> _projectRepository;
        private readonly IMapper _mapper;

        public CreateProjectCommandHandler(IRepository<ProjectEntity> projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<VoidType> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {                
            await _projectRepository.CreateAsync(_mapper.Map<ProjectEntity>(request.ProjectViewModel));

            return VoidType.Instance;
        }
    }
}
