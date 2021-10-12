using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;

namespace TaskTracker.Application.Core.Projects.Commands
{
    //public interface ICreateBaseCommandHandler<TResult, TViewModel>
    //{
    //    Task<TResult> Handle(CreateBaseCommand<TViewModel, TResult> request, CancellationToken cancellationToken);
    //}

    //public class CreateBaseCommandHandlerTest<TViewModel, TResult, TEntity>: IRequestHandler<CreateBaseCommand<TViewModel, TResult>, TResult> where TResult : new()
    //   where TEntity : BaseEntity
    //{
    //    private readonly IRepository<TEntity> _repository;
    //    private readonly IMapper _mapper;

    //    public CreateBaseCommandHandlerTest(IRepository<TEntity> repository, IMapper mapper)
    //    {
    //        _repository = repository;
    //        _mapper = mapper;
    //    }

    //    public virtual async Task<TResult> Handle(CreateBaseCommand<TViewModel, TResult> request, CancellationToken cancellationToken)
    //    {
    //        await _repository.CreateAsync(_mapper.Map<TEntity>(request.ViewModel));

    //        return new TResult();
    //    }
    //}
    public abstract class CreateBaseCommand<TViewModel, TResult> 
        : IRequest<TResult>
    {
        public TViewModel ViewModel { get; set; }
    }

    public abstract class CreateBaseCommandHandler<TViewModel, TResult, TEntity> 
        : IRequestHandler<CreateBaseCommand<TViewModel, TResult>, TResult> 
        where TResult : new() 
        where TEntity : BaseEntity
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public CreateBaseCommandHandler(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual async Task<TResult> Handle(CreateBaseCommand<TViewModel, TResult> request, CancellationToken cancellationToken)
        {                
            await _repository.CreateAsync(_mapper.Map<TEntity>(request.ViewModel));

            return new TResult();
        }
    }
}
