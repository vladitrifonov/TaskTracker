using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using System.Collections.Generic;

namespace TaskTracker.Application.Core.Projects.Queries
{
    public class GetBasesQuery<TViewModel> : IRequest<List<TViewModel>>
    {
    }

    public class GetBasesQueryHandler<TViewModel, TEntity> 
        : IRequestHandler<GetBasesQuery<TViewModel>, List<TViewModel>> 
        where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> _repository;      
        private readonly IMapper _mapper;

        public GetBasesQueryHandler(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;         
            _mapper = mapper;
        }

        public virtual async Task<List<TViewModel>> Handle(GetBasesQuery<TViewModel> request, CancellationToken cancellationToken)
        {
            IEnumerable<TEntity> projectsEntity = await _repository.GetAsync();

            return projectsEntity.OrderBy(x => x.Id).Select(x => _mapper.Map<TViewModel>(x)).ToList();
        }
    }
}
