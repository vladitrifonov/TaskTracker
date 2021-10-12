using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using System.Collections.Generic;

namespace TaskTracker.Application.Core.Projects.Queries
{    public abstract class GetBasesQueryHandler<TViewModel, TEntity, TRequest> 
        : IRequestHandler<TRequest, List<TViewModel>> 
        where TEntity : BaseEntity
        where TRequest : IRequest<List<TViewModel>>
    {
        private readonly IRepository<TEntity> _repository;      
        private readonly IMapper _mapper;

        public GetBasesQueryHandler(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;         
            _mapper = mapper;
        }

        public virtual async Task<List<TViewModel>> Handle(TRequest request, CancellationToken cancellationToken)
        {
            IEnumerable<TEntity> projectsEntity = await _repository.GetAsync();

            return projectsEntity.OrderBy(x => x.Id).Select(x => _mapper.Map<TViewModel>(x)).ToList();
        }
    }
}
