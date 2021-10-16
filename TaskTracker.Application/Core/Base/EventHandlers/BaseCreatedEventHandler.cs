
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Application.Common.Helpers;
using TaskTracker.Application.Common.Models;
using TaskTracker.Domain.Contracts;
using TaskTracker.Domain.Events;
using INotification = TaskTracker.Domain.Contracts.INotification;

namespace TaskTracker.Application.Core.Base.EventHandlers
{   
    public abstract class BaseCreatedEventHandler<TEntity> : INotificationHandler<DomainEventNotification<BaseCreatedEvent<TEntity>>>
    {
        //private readonly ILogger<TodoItemCreatedEventHandler> _logger;
        private readonly INotification _notification;
        public BaseCreatedEventHandler(/*ILogger<TodoItemCreatedEventHandler> logger*/INotification notification)
        {
            //_logger = logger;
            _notification = notification;
        }

        public Task Handle(DomainEventNotification<BaseCreatedEvent<TEntity>> command, CancellationToken cancellationToken)
        {
            //var domainEvent = notification.DomainEvent;
            _notification.Success(TextHelper.Created(typeof(TEntity).Name));
            //_logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", domainEvent.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
