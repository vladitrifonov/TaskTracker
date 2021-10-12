namespace TaskTracker.Domain.Contracts.HandlersContracts
{
    public interface IStorageIntAndViewModel<TViewModel> : IStorageInt, IStorageViewModel<TViewModel>
    {
    }
}
