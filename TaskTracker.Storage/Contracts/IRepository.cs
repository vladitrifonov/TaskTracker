using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskTracker.Storage.Contracts
{
    interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<bool> Create(T item);
        Task<bool> Update(T item);
        Task<bool> Delete(int id);
    }
}
