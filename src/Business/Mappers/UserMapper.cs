using AutoMapper;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data.Entities;
using System.Collections.Generic;

namespace PlaneTicketReservationSystem.Business.Mappers
{
    public class UserMapper : IBaseMapper<UserEntity, User>
    {
        private readonly Mapper _mapper;

        public UserMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserEntity, User>();
                cfg.CreateMap<User, UserEntity>();
            });
            _mapper = new Mapper(configuration);
        }

        public IEnumerable<User> FromEntitiesToModels(IEnumerable<UserEntity> entities)
        {
            return _mapper.Map<IEnumerable<User>>(entities);
        }

        public User FromEntityToModel(UserEntity entity)
        {
            return _mapper.Map<UserEntity, User>(entity);
        }

        public IEnumerable<UserEntity> FromModelsToEntities(IEnumerable<User> models)
        {
            return _mapper.Map<IEnumerable<UserEntity>>(models);
        }

        public UserEntity FromModelToEntity(User model)
        {
            return _mapper.Map<User, UserEntity>(model);
        }
    }
}
