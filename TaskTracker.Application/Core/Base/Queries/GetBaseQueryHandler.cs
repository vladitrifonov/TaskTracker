using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.Contracts.HandlersContracts;

namespace TaskTracker.Application.Core.Projects.Queries
{
   public abstract class GetBaseQueryHandler<TViewModel, TEntity, TRequest>
        : IRequestHandler<TRequest, TViewModel> 
        where TEntity : BaseEntity
        where TRequest : IRequest<TViewModel>, IStorageInt
    {
        private readonly IRepository<TEntity> _repository;     
        private readonly IMapper _mapper;

        public GetBaseQueryHandler(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<TViewModel> Handle(TRequest request, CancellationToken cancellationToken)
        {
            TEntity entity = await _repository.GetByIdAsync(request.Id);

            return _mapper.Map<TViewModel>(entity);
        }
    }
}
