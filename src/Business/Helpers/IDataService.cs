using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlaneTicketReservationSystem.Business.Helpers
{
    public interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T> GetByIdAsync(int id);

        Task PostAsync(T item);

        Task DeleteAsync(int id);

        Task UpdateAsync(int id, T item);
    }
}
