using System.Threading.Tasks;

namespace TaskTracker.Domain.Contracts
{
    public interface ILogger
    {
        Task Trace(string message);
        Task Debug(string message);
        Task Information(string message);
        Task Warning(string message);
        Task Error(string message);
    }
}