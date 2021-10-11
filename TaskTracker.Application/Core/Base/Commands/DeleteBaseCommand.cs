using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.Exceptions;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;

namespace TaskTracker.Application.Core.Projects.Commands
{
    public abstract class DeleteBaseCommand<TResult>
        : IRequest<TResult>
    {
        public int Id { get; set; }
    }

    public abstract class DeleteBaseCommandHandler<TResult, TEntity> 
        : IRequestHandler<DeleteBaseCommand<TResult>, TResult> 
        where TEntity : BaseEntity
        where TResult : new()
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public DeleteBaseCommandHandler(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<TResult> Handle(DeleteBaseCommand<TResult> request, CancellationToken cancellationToken)
        {
            TEntity entity = await _repository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TEntity), request.Id);
            }

            await _repository.DeleteAsync(entity);

            return new TResult();
        }
    }
}
