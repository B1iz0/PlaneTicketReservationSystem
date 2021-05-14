using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlaneTicketReservationSystem.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        Task CreateAsync(T item);
        Task UpdateAsync(int id, T item);
        Task DeleteAsync(int id);
        Task<bool> IsExistingAsync(int id);
    }
}
