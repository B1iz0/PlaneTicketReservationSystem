using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Helpers;
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

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return _userMapper.Map<IEnumerable<User>>(await _users.GetAllAsync());
        }

        public async Task<User> GetByIdAsync(int id)
        {
            if (!_users.Find(x => x.Id == id).Any())
                throw new Exception("No such user");
            return _userMapper.Map<User>(await _users.GetAsync(id));
        }

        public async Task PostAsync(User user)
        {
            if (_users.Find(x => x.Email == user.Email).Any())
                throw new Exception("This email is already registered");
            user.Password = PasswordHasher.GenerateHash(user.Password, PasswordHasher.Salt, SHA256.Create());
            await _users.CreateAsync(_userMapper.Map<UserEntity>(user));
        }

        public async Task DeleteAsync(int id)
        {
            if (!_users.Find(x => x.Id == id).Any())
                throw new Exception("No such user");
            await _users.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, User user)
        {
            if (!(await _users.IsExistingAsync(id)))
                throw new Exception("No such user");
            user.Password = PasswordHasher.GenerateHash(user.Password, PasswordHasher.Salt, SHA256.Create());
            await _users.UpdateAsync(id, _userMapper.Map<UserEntity>(user));
        }
    }
}
