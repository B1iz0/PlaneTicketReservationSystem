using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Exceptions;
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
            var users = _userMapper.Map<IEnumerable<User>>(await _users.GetAllAsync());
            return users;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            bool isUserExisting = await _users.IsExistingAsync(id);
            if (!isUserExisting)
            {
                throw new ElementNotFoundException($"User with id:{id} is not found");
            }
            var user = _userMapper.Map<User>(await _users.GetAsync(id));
            return user;
        }

        public async Task PostAsync(User user)
        {
            bool isUserExisting = _users.Find(x => x.Email == user.Email).Any();
            if (isUserExisting)
            {
                throw new ElementAlreadyExistException($"User with email: {user.Email} is already registered");
            }
            user.Password = PasswordHasher.GenerateHash(user.Password, PasswordHasher.Salt, SHA256.Create());
            await _users.CreateAsync(_userMapper.Map<UserEntity>(user));
        }

        public async Task DeleteAsync(int id)
        {
            bool isUserExisting = await _users.IsExistingAsync(id);
            if (!isUserExisting)
            {
                throw new ElementNotFoundException($"User with id:{id} is not found");
            }
            await _users.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, User user)
        {
            bool isUserExisting = await _users.IsExistingAsync(id);
            if (!isUserExisting)
            {
                throw new ElementNotFoundException($"User with id:{id} is not found");
            }
            user.Password = PasswordHasher.GenerateHash(user.Password, PasswordHasher.Salt, SHA256.Create());
            await _users.UpdateAsync(id, _userMapper.Map<UserEntity>(user));
        }
    }
}
