using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.Helpers;
using TaskTracker.Contracts.Entities;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.Contracts.HandlersContracts;
using INotification = TaskTracker.Domain.Contracts.INotification;

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
        private readonly INotification _notification;

        public CreateBaseCommandHandler(IRepository<TEntity> repository, IMapper mapper, INotification notification)
        {
            _repository = repository;
            _mapper = mapper;
            _notification = notification;
        }

        public async Task<TResult> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                await _repository.CreateAsync(_mapper.Map<TEntity>(request.ViewModel));
            }
            catch (Exception ex)
            {
                _notification.Error(TextHelper.CouldNotCreated(typeof(TEntity).Name));
                Console.WriteLine(ex);//log ex
            }
            

            _notification.Success(TextHelper.Created(typeof(TEntity).Name));

            return new TResult();
        }
    }
}
