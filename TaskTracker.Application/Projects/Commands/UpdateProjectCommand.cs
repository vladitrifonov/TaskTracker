using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.Exceptions;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.DataTypes;

namespace TaskTracker.Application.Projects.Commands
{
    public class UpdateProjectCommand : IRequest<VoidType>
    {
        public int Id { get; set; }
        public ProjectViewModel ProjectViewModel { get; set; }
    }

    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, VoidType>
    {
        private readonly IRepository<ProjectEntity> _projectRepository;
        private readonly IMapper _mapper;

        public UpdateProjectCommandHandler(IRepository<ProjectEntity> projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<VoidType> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            ProjectEntity entity = await _projectRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProjectEntity), request.Id);
            }

            _mapper.Map(request.ProjectViewModel, entity);
        
            await _projectRepository.UpdateAsync(entity);

            return VoidType.Instance;
        }
    }
}
