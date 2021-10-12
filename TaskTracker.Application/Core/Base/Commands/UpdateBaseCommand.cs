using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.Exceptions;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.Contracts.HandlersContracts;

namespace TaskTracker.Application.Core.Projects.Commands
{
    public abstract class UpdateBaseCommandHandler<TViewModel, TResult, TEntity, TRequest>
          : IRequestHandler<TRequest, TResult>
        where TResult : new()
        where TEntity : BaseEntity
        where TRequest : IRequest<TResult>, IStorageIntAndViewModel<TViewModel>
    {
        private readonly IRepository<TEntity> _projectRepository;
        private readonly IMapper _mapper;

        public UpdateBaseCommandHandler(IRepository<TEntity> projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public virtual async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken)
        {
            TEntity entity = await _projectRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(ProjectEntity), request.Id);
            }

            _mapper.Map(request.ViewModel, entity);
        
            await _projectRepository.UpdateAsync(entity);

            return new TResult();
        }
    }
}
