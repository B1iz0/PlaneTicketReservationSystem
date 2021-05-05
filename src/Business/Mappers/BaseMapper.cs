using System.Collections.Generic;
using AutoMapper;

namespace PlaneTicketReservationSystem.Business.Mappers
{
    public class BaseMapper<T, U> : IBaseMapper<T, U>
    {
        private readonly Mapper _mapper;

        public BaseMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, U>();
                cfg.CreateMap<U, T>();
            });
            _mapper = new Mapper(configuration);
        }

        public U Map<T, U>(T item)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<T, U>();
            });
            var mapper = configuration.CreateMapper();
            return mapper.Map<T, U>(item);
        }

        public U FromEntityToModel(T entity)
        {
            return _mapper.Map<T, U>(entity);
        }

        public T FromModelToEntity(U model)
        {
            return _mapper.Map<U, T>(model);
        }

        public IEnumerable<U> FromEntitiesToModels(IEnumerable<T> entities)
        {
            return _mapper.Map<IEnumerable<U>>(entities);
        }

        public IEnumerable<T> FromModelsToEntities(IEnumerable<U> models)
        {
            return _mapper.Map<IEnumerable<T>>(models);
        }
    }
}
