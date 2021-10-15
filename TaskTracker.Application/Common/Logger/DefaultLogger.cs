using System.Threading.Tasks;
using TaskTracker.Domain.Contracts;

namespace TaskTracker.Application.Common.Logger
{
    public class DefaultLogger : ILogger
    {
        private readonly SimpleLogger.ILogger _logger;
        public DefaultLogger(SimpleLogger.ILogger logger)
        {
            _logger = logger;
        }
        public async Task Trace(string message)
        {
            await _logger.Trace(message);
        }
        public async Task Debug(string message)
        {
            await _logger.Debug(message);
        }
        public async Task Information(string message)
        {
            await _logger.Information(message);
        }
        public async Task Warning(string message)
        {
            await _logger.Warning(message);
        }
        public async Task Error(string message)
        {
            await _logger.Error(message);
        }
    }
}
