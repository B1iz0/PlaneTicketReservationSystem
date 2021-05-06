using System;
using System.Collections.Generic;
using System.Text;

namespace PlaneTicketReservationSystem.Business.Mappers
{
    public interface IBaseMapper<T, U>
    {
        public U FromEntityToModel(T entity);
        public T FromModelToEntity(U model);
        public IEnumerable<U> FromEntitiesToModels(IEnumerable<T> entities);
        public IEnumerable<T> FromModelsToEntities(IEnumerable<U> models);
    }
}
