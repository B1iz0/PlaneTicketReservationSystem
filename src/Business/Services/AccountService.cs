using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserRepository _users;
        private readonly RoleRepository _roles;
        private readonly AppSettings _appSettings;
        private readonly Mapper _userMapper;

        public AccountService(IOptions<AppSettings> appSettings, ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _users = new UserRepository(context);
            _roles = new RoleRepository(context);
            _appSettings = appSettings.Value;
            _userMapper = new Mapper(conf.AirlineConfiguration);
        }

        public Authenticate Authenticate(Authenticate model)
        {
            var userEntity = _users.Find(x => x.Email == model.Email && PasswordHasher.CheckHash(model.Password, x.Password))
                .ToList()
                .First();
            if (userEntity == null) return null;

            var user = _userMapper.Map<User>(userEntity);
            var token = GenerateJwtToken(user);
            var refreshToken = GenerateRefreshToken();

            userEntity.RefreshTokens.Add(_userMapper.Map<RefreshTokenEntity>(refreshToken));
            _users.Update(userEntity.Id, userEntity);

            return new Authenticate(_userMapper.Map<User>(userEntity), token, refreshToken.Token);
        }

        public string GenerateJwtToken(User user)
        {
            var roleName = _roles.Get(user.RoleId).Name;
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
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public RefreshToken GenerateRefreshToken()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[64];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            return new RefreshToken
            {
                Token = Convert.ToBase64String(randomBytes),
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.RefreshTokenLifeTime),
                Created = DateTime.UtcNow,
            };
        }

        public bool RevokeToken(string token)
        {
            var user = _users.Find(u => u.RefreshTokens.Any(t => t.Token == token)).First();
            if (user == null) return false;

            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);
            if (!refreshToken.IsActive) return false;

            refreshToken.Revoked = DateTime.UtcNow;
            _users.Update(user.Id, user);
            return true;
        }

        public Authenticate RefreshToken(string token)
        {
            var user = _users.Find(x => x.RefreshTokens.Any(t => t.Token == token)).First();
            if (user == null) return null;

            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);
            if (!refreshToken.IsActive) return null;

            var newRefreshToken = GenerateRefreshToken();
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.ReplacedByToken = newRefreshToken.Token;
            user.RefreshTokens.Add(_userMapper.Map<RefreshTokenEntity>(newRefreshToken));
            _users.Update(user.Id, user);

            var jwtToken = GenerateJwtToken(_userMapper.Map<User>(user));

            return new Authenticate(_userMapper.Map<User>(user), jwtToken, newRefreshToken.Token);
        }
    }
}
