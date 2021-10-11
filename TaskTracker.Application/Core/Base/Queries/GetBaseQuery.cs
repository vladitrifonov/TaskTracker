using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.ViewModels;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;

namespace TaskTracker.Application.Core.Projects.Queries
{
    public abstract class GetBaseQuery<TViewModel> : IRequest<TViewModel>
    {
        public int Id { get; set; }
    }

    public class GetBaseQueryHandler<TViewModel, TEntity>
        : IRequestHandler<GetBaseQuery<TViewModel>, TViewModel> 
        where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> _repository;     
        private readonly IMapper _mapper;

        public GetBaseQueryHandler(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<TViewModel> Handle(GetBaseQuery<TViewModel> request, CancellationToken cancellationToken)
        {
            TEntity entity = await _repository.GetByIdAsync(request.Id);

            return _mapper.Map<TViewModel>(entity);
        }
    }
}
