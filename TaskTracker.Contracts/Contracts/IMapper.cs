namespace TaskTracker.Contracts.Contracts
{
    public interface IMapper
    {
        T Map<T>(object source);
        TDest Map<TSource, TDest>(TSource source);
    }
}
