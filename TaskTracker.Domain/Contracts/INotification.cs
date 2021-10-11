namespace TaskTracker.Domain.Contracts
{
    public interface INotification
    {
        void Info(string message);
        void Success(string message);
        void Warning(string message);
        void Error(string message);
    }
}
