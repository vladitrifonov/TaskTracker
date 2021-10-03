using AspNetCoreHero.ToastNotification.Abstractions;
using TaskTracker.Domain.Contracts;

namespace askTracker.Host.Common
{
    public class ToastifyNotification : INotification
    {
        private readonly IToastifyService _notifyService;
        public ToastifyNotification(IToastifyService notifyService)
        {
            _notifyService = notifyService;
        }
        public void Info(string message)
        {
            _notifyService.Information(message);
        }
        public void Success(string message)
        {
            _notifyService.Success(message);
        }
        public void Warning(string message)
        {
            _notifyService.Warning(message);
        }
        public void Error(string message)
        {
            _notifyService.Error(message);
        }
    }
}
