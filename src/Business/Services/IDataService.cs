using System;
using System.Collections.Generic;
using System.Text;

namespace PlaneTicketReservationSystem.Business.Services
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
