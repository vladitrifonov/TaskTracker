using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Domain.Contracts;
using INotification = TaskTracker.Domain.Contracts.INotification;

namespace TaskTracker.Application.Common
{
    public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly INotification _notification;
        private readonly ILogger _logger;

        public UnhandledExceptionBehaviour(INotification notification, ILogger logger)
        {
            _notification = notification;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response = default;
            try
            {               
                response = await next();
            }
            catch (Exception ex)
            {
                string requestName = typeof(TRequest).Name;

                await _notification.Error($"Unhandled Exception for {requestName} {ex.Message}");
                await _logger.Error($"Unhandled Exception for {requestName}");
            }
            return response;
        }
    }
}
