using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTracker.Contracts.Entities;
using Task = System.Threading.Tasks.Task;

namespace TaskTracker.Domain.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAsync();
        Task<IEnumerable<T>> GetByPredicateAsync(Func<T, bool> predicate);
        Task<T> GetByIdAsync(int id);     
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
