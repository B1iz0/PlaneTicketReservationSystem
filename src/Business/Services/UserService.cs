using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class UserService : IDataService<User>
    {
        private readonly UserRepository _users;
        private readonly Mapper _userMapper;

        public UserService(ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _users = new UserRepository(context);
            _userMapper = new Mapper(conf.AirlineConfiguration);
        }

        public IEnumerable<User> GetAll()
        {
            return _userMapper.Map<IEnumerable<User>>(_users.GetAll());
        }

        public User GetById(int id)
        {
            User user = _userMapper.Map<User>(_users.Get(id));
            return user;
        }

        public void Post(User user)
        {
            user.Password = PasswordHasher.GenerateHash(user.Password, PasswordHasher.Salt, SHA256.Create());
            _users.Create(_userMapper.Map<UserEntity>(user));
        }

        public void Delete(int id)
        {
            _users.Delete(id);
        }

        public void Update(int id, User user)
        {
            _users.Update(id, _userMapper.Map<UserEntity>(user));
        }
    }
}
