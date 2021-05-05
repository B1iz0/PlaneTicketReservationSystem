using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Mappers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories;

namespace PlaneTicketReservationSystem.Business.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly UserRepository _users;
        private readonly AppSettings _appSettings;
        private readonly UserMapper<UserEntity, User> _mapper;

        public UserService(IOptions<AppSettings> appSettings, ReservationSystemContext context)
        {
            _users = new UserRepository(context);
            _appSettings = appSettings.Value;
            _mapper = new UserMapper<UserEntity, User>();
        }

        public string Authenticate(Authenticate model)
        {
            var user = _users.Find(x => x.Email == model.Email && PasswordHasher.CheckHash(model.Password, x.Password))
                .ToList()
                .First();
            if (user == null) return null;
            User result = _mapper.FromEntityToModel(user);
            var token = GenerateJwtToken(result);
            return token;
        }

        public IEnumerable<User> GetAll()
        {
            return _mapper.FromEntitiesToModels(_users.GetAll());
        }

        public User GetById(int id)
        {
            User user = _mapper.FromEntityToModel(_users.Get(id));
            if (user == null) return null;
            return user;
        }

        public void Post(User user)
        {
            user.Password = PasswordHasher.GenerateHash(user.Password, PasswordHasher.Salt, SHA256.Create());
            _users.Create(_mapper.FromModelToEntity(user));
        }

        public void Delete(int id)
        {
            _users.Delete(id);
        }

        private string GenerateJwtToken(User user)
        {
            var roleName = _users.Get(user.Id).Role.Name;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _appSettings.Audience,
                Issuer = _appSettings.Issuer,
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("id", user.Id.ToString()),
                    new Claim("email", user.Email),
                    new Claim("role", roleName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.LifeTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
