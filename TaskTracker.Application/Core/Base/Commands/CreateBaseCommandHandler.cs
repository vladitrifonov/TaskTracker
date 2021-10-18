using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.Contracts.HandlersContracts;

namespace TaskTracker.Application.Core.Projects.Commands
{
    public abstract class CreateBaseCommandHandler<TViewModel, TResult, TEntity, TRequest> 
        : IRequestHandler<TRequest, TResult> 
        where TResult : new() 
        where TEntity : BaseEntity
        where TRequest : IRequest<TResult>, IStorageViewModel<TViewModel>
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;       

        public CreateBaseCommandHandler(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken)
        {
            TEntity entity = _mapper.Map<TEntity>(request.ViewModel);

            await _repository.CreateAsync(entity);

            //entity.DomainEvents.Add(new BaseCreatedEvent<TEntity>(entity));

            return new TResult();
        }
    }
}
