using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TaskTracker.Domain.Contracts;
using INotification = TaskTracker.Domain.Contracts.INotification;

namespace TaskTracker.Application.Common
{
    public class TestBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly INotification _notification;
        private readonly ILogger _logger;

        public TestBehaviour(INotification notification, ILogger logger)
        {
            _notification = notification;
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            TResponse response = default;
         
            response = await next();    
            string requestName = typeof(TRequest).Name;

            await _notification.Info($"Created {requestName}");
            await _logger.Information($"Created {requestName}");

            return response;
        }
    }
}
