using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.Exceptions;
using TaskTracker.Application.Common.Helpers;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.Contracts.HandlersContracts;
using INotification = TaskTracker.Domain.Contracts.INotification;

namespace TaskTracker.Application.Core.Projects.Commands
{    
    public abstract class DeleteBaseCommandHandler<TResult, TEntity, TRequest> 
        : IRequestHandler<TRequest, TResult> 
        where TEntity : BaseEntity
        where TResult : new()
        where TRequest : IRequest<TResult>, IStorageInt
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;
        private readonly INotification _notification;

        public DeleteBaseCommandHandler(IRepository<TEntity> repository, IMapper mapper, INotification notification)
        {
            _repository = repository;
            _mapper = mapper;
            _notification = notification;
        }

        public async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken)
        {
            TEntity entity = await _repository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(TEntity), request.Id);
            }

            await _repository.DeleteAsync(entity);

            await _notification.Info(TextHelper.Deleted(typeof(TEntity).Name));

            return new TResult();
        }
    }
}
