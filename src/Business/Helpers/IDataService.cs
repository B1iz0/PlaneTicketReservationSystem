using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Helpers
{
    public interface IDataService<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Post(T item);
        void Delete(int id);
        void Update(int id, T item);
    }
}
