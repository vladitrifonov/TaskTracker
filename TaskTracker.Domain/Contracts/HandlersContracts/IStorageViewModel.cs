namespace TaskTracker.Domain.Contracts.HandlersContracts
{
    public interface IStorageViewModel<TViewModel>
    {
        TViewModel ViewModel { get; set; }
    }
}
