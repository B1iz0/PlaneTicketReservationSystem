﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public IEnumerable<User> GetFilteredUsers(int offset, int limit, string email, string firstName, string lastName)
        {
            Expression<Func<UserEntity, bool>> predicate = u =>
                (string.IsNullOrEmpty(email) || u.Email.Contains(email))
                && (string.IsNullOrEmpty(firstName) || u.FirstName.Contains(firstName))
                && (string.IsNullOrEmpty(lastName) || u.LastName.Contains(lastName));
            var result = _users.FindWithLimitAndOffset(predicate, offset, limit);
            var flight = _userMapper.Map<IEnumerable<User>>(result);
            return flight;
        }

        public int GetFilteredUsersCount(string email, string firstName, string lastName)
        {
            Expression<Func<UserEntity, bool>> predicate = u =>
                (string.IsNullOrEmpty(email) || u.Email.Contains(email))
                && (string.IsNullOrEmpty(firstName) || u.FirstName.Contains(firstName))
                && (string.IsNullOrEmpty(lastName) || u.LastName.Contains(lastName));
            IQueryable<UserEntity> userEntities = _users.Find(predicate);
            int count = userEntities.Count();
            return count;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            UserEntity userEntity = await _users.GetAsync(id);
            if (userEntity == null)
            {
                throw new ElementNotFoundException($"User with id:{id} is not found");
            }
            var user = _userMapper.Map<User>(userEntity);
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
            var userEntity = _userMapper.Map<UserEntity>(user);
            await _users.CreateAsync(userEntity);
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
            var userEntity = _userMapper.Map<UserEntity>(user);
            await _users.UpdateAsync(userEntity);
        }
    }
}
