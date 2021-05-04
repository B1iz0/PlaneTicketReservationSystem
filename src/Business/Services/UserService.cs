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
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _users;
        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings, ReservationSystemContext context)
        {
            _users = new UserRepository(context);
            _appSettings = appSettings.Value;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var users = _users.Find(x => x.Email == model.Email && PasswordHasher.CheckHash(model.Password, x.Password)).ToList();

            // return null if user not found
            if (!users.Any()) return null;

            UserEntity user = users.First();
            User result = new User()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                RoleId = user.RoleId,
                Password = user.Password
            };

            // authentication successful so generate jwt token
            var token = GenerateJwtToken(result);

            return new AuthenticateResponse(result, token);
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return _users.GetAll();
        }

        public User GetById(int id)
        {
            UserEntity user = _users.Get(id);

            if (user == null) return null;
            User result = new User()
            {
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                RoleId = user.RoleId,
                Password = user.Password
            };
            return result;
        }

        public void Post(User user)
        {
            _users.Create(
                new UserEntity()
                {
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Password = PasswordHasher.GenerateHash(user.Password, PasswordHasher.Salt, SHA256.Create()),
                    RoleId = user.RoleId
                });
        }

        public void Delete(int id)
        {
            _users.Delete(id);
        }

        // helper methods

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _appSettings.Audience,
                Issuer = _appSettings.Issuer,
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.LifeTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
