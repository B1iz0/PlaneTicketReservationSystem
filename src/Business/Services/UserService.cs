using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Exceptions;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordProvider _passwordProvider;

        private readonly IUserRepository _users;

        private readonly IMapper _userMapper;

        public UserService(IPasswordProvider passwordProvider, IUserRepository users, IMapper mapper)
        {
            _passwordProvider = passwordProvider;
            _users = users;
            _userMapper = mapper;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var users = _userMapper.Map<IEnumerable<User>>(await _users.GetAllAsync());
            return users;
        }

        public IEnumerable<User> GetFilteredUsers(int offset, int limit, string email, string firstName, string lastName)
        {
            var result = _users.FindWithLimitAndOffset(x => (string.IsNullOrEmpty(email) || x.Email.Contains(email))
                                                              && (string.IsNullOrEmpty(firstName) || x.FirstName.Contains(firstName))
                                                                && (string.IsNullOrEmpty(lastName) || x.LastName.Contains(lastName)), offset, limit);
            var flight = _userMapper.Map<IEnumerable<User>>(result);
            return flight;
        }

        public int GetFilteredUsersCount(string email, string firstName, string lastName)
        {
            int count = _users.Find(x => (string.IsNullOrEmpty(email) || x.Email.Contains(email))
                                           && (string.IsNullOrEmpty(firstName) || x.FirstName.Contains(firstName))
                                           && (string.IsNullOrEmpty(lastName) || x.LastName.Contains(lastName))).Count();
            return count;
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
            user.Password = _passwordProvider.GenerateHash(user.Password, SHA256.Create());
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
            user.Id = id;
            user.Password = _passwordProvider.GenerateHash(user.Password, SHA256.Create());
            await _users.UpdateAsync(_userMapper.Map<UserEntity>(user));
        }
    }
}
