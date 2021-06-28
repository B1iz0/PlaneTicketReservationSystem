using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PlaneTicketReservationSystem.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetAsync(Guid id);

        IQueryable<T> Find(Expression<Func<T, bool>> predicate);

        IQueryable<T> FindWithLimitAndOffset(Expression<Func<T, bool>> predicate, int offset, int limit);

        Task CreateAsync(T item);

        Task UpdateAsync(T item);

        Task DeleteAsync(Guid id);

        Task<bool> IsExistingAsync(Guid id);
    }
}
