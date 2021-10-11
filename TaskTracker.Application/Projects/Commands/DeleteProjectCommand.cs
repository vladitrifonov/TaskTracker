using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.Exceptions;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.DataTypes;

namespace TaskTracker.Application.Projects.Commands
{
    public class DeleteProjectCommand : IRequest<VoidType>
    {
        public int Id { get; set; }
    }

    public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, VoidType>
    {
        private readonly IRepository<ProjectEntity> _projectRepository;
        private readonly IMapper _mapper;

        public DeleteProjectCommandHandler(IRepository<ProjectEntity> projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<VoidType> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            ProjectEntity entity = await _projectRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProjectEntity), request.Id);
            }

            await _projectRepository.DeleteAsync(entity);

            return VoidType.Instance;
        }
    }
}
