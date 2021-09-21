using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTracker.Contracts.DataTypes;
using Task = System.Threading.Tasks.Task;

namespace TaskTracker.Contracts.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<List<T>> ListAsync();
        Task<IEnumerable<T>> GetByPredicateAsync(Func<T, bool> predicate);
        Task<T> GetByIdAsync(int id);     
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
