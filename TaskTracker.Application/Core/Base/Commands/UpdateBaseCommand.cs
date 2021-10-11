using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.Exceptions;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;

namespace TaskTracker.Application.Core.Projects.Commands
{
    public abstract class UpdateBaseCommand <TViewModel, TResult> 
        : IRequest<TResult>
    {
        public int Id { get; set; }
        public TViewModel ViewModel { get; set; }
    }

    public abstract class UpdateBaseCommandHandler<TViewModel, TResult, TEntity>
        : IRequestHandler<UpdateBaseCommand<TViewModel, TResult>, TResult>
        where TResult : new()
        where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> _projectRepository;
        private readonly IMapper _mapper;

        public UpdateBaseCommandHandler(IRepository<TEntity> projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public virtual async Task<TResult> Handle(UpdateBaseCommand<TViewModel, TResult> request, CancellationToken cancellationToken)
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
