using System.Threading.Tasks;

namespace TaskTracker.Domain.Contracts
{
    public interface INotification
    {
        Task Info(string message);
        Task Success(string message);
        Task Warning(string message);
        Task Error(string message);
    }
}
