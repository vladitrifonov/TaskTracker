using AspNetCoreHero.ToastNotification.Abstractions;
using System.Threading.Tasks;
using TaskTracker.Domain.Contracts;

namespace TaskTracker.Application.Common.Notifications
{
    public class ToastifyNotification : INotification
    {
        private readonly IToastifyService _notifyService;
        public ToastifyNotification(IToastifyService notifyService)
        {
            _notifyService = notifyService;
        }
        public Task Info(string message)
        {
            _notifyService.Information(message);
            return Task.CompletedTask;
        }
        public Task Success(string message)
        {
            _notifyService.Success(message);
            return Task.CompletedTask;
        }
        public Task Warning(string message)
        {
            _notifyService.Warning(message);
            return Task.CompletedTask;
        }
        public Task Error(string message)
        {
            _notifyService.Error(message);
            return Task.CompletedTask;
        }
    }
}
