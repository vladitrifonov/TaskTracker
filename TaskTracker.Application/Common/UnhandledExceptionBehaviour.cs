using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using INotification = TaskTracker.Domain.Contracts.INotification;

namespace TaskTracker.Application.Common
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly INotification _notification;

        public UnhandledExceptionBehaviour(INotification notification)
        {
            _notification = notification;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;

                _notification.Error($"Unhandled Exception for Request {requestName} {request}");
                //_logger.LogError(ex, "Unhandled Exception for Request {Name} {@Request}", requestName, request);

                throw;
            }
        }
    }
}
