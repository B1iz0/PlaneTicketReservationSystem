using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data.Entities;

namespace PlaneTicketReservationSystem.Business.Mappers
{
    public class UserMapper
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

        public User FromEntityToModel(UserEntity user)
        {
            return _mapper.Map<UserEntity, User>(user);
        }

        public UserEntity FromModelToEntity(User user)
        {
            return _mapper.Map<User, UserEntity>(user);
        }

        public IEnumerable<User> FromEntitiesToModels(IEnumerable<UserEntity> users)
        {
            return _mapper.Map<IEnumerable<User>>(users);
        }
    }
}
