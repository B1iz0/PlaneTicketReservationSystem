using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Repositories;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserRepository _users;
        private readonly AppSettings _appSettings;
        private readonly Mapper _userMapper;

        public AccountService(IOptions<AppSettings> appSettings, ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _users = new UserRepository(context);
            _appSettings = appSettings.Value;
            _userMapper = new Mapper(conf.UserConfiguration);
        }

        public string Authenticate(Authenticate model)
        {
            var user = _users.Find(x => x.Email == model.Email && PasswordHasher.CheckHash(model.Password, x.Password))
                .ToList()
                .First();
            if (user == null) return null;
            User result = _userMapper.Map<User>(user);
            var token = GenerateJwtToken(result);
            return token;
        }

        public string GenerateJwtToken(User user)
        {
            var roleName = _users.Get(user.Id).Role.Name;
            if (roleName == null) return null;
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
