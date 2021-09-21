namespace TaskTracker.Storage.Contracts
{
    public interface IFactory<out T>
    {
        T Create();
    }
}
