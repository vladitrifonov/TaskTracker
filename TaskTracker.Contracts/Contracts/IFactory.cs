namespace TaskTracker.Domain.Contracts
{
    public interface IFactory<out T>
    {
        T Create();
    }
}
