using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
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
        private const int RefreshTokenBytesAmount = 64;

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

        public async Task<Authenticate> AuthenticateAsync(Authenticate model)
        {
            var userEntity = await _users.GetByEmailAsync(model.Email);
            if (userEntity == null)
            {
                throw new Exception("User with such email doesn't exist.");
            }

            bool isPasswordConfirmed = PasswordHasher.CheckHash(model.Password, userEntity.Password);
            if (!isPasswordConfirmed)
            {
                throw new Exception("Password is not correct.");
            }

            var user = _userMapper.Map<User>(userEntity);
            var token = await GenerateJwtTokenAsync(user);
            var refreshToken = GenerateRefreshToken();

            userEntity.RefreshTokens.Add(_userMapper.Map<RefreshTokenEntity>(refreshToken));
            await _users.UpdateAsync(userEntity);

            var authenticateResponse = new Authenticate(_userMapper.Map<User>(userEntity), token, refreshToken.Token);
            return authenticateResponse;
        }

        public async Task<string> GenerateJwtTokenAsync(User user)
        {
            var roleName = (await _roles.GetAsync(user.RoleId)).Name;
            if (roleName == null)
            {
                return null;
            }

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
            string tokenResponse = tokenHandler.WriteToken(token);
            return tokenResponse;
        }

        public RefreshToken GenerateRefreshToken()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[RefreshTokenBytesAmount];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            var refreshTokenResponse = new RefreshToken
            {
                Token = Convert.ToBase64String(randomBytes),
                Expires = DateTime.UtcNow.AddMinutes(_appSettings.RefreshTokenLifeTime),
                Created = DateTime.UtcNow,
            };
            return refreshTokenResponse;
        }

        public async Task<bool> RevokeTokenAsync(string token)
        {
            var user = _users.Find(u => u.RefreshTokens.Any(t => t.Token == token)).First();
            if (user == null)
            {
                return false;
            }

            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);
            if (!refreshToken.IsActive)
            {
                return false;
            }

            refreshToken.Revoked = DateTime.UtcNow;
            await _users.UpdateAsync(user);
            return true;
        }

        public async Task<Authenticate> RefreshTokenAsync(string token)
        {
            var user = _users.Find(x => x.RefreshTokens.Any(t => t.Token == token)).First();
            if (user == null)
            {
                return null;
            }
            var refreshToken = user.RefreshTokens.Single(x => x.Token == token);
            if (!refreshToken.IsActive)
            {
                return null;
            }

            var newRefreshToken = GenerateRefreshToken();
            refreshToken.Revoked = DateTime.UtcNow;
            refreshToken.ReplacedByToken = newRefreshToken.Token;
            user.RefreshTokens.Add(_userMapper.Map<RefreshTokenEntity>(newRefreshToken));
            await _users.UpdateAsync(user);

            var jwtToken = await GenerateJwtTokenAsync(_userMapper.Map<User>(user));

            var authenticateResponse = new Authenticate(_userMapper.Map<User>(user), jwtToken, newRefreshToken.Token);
            return authenticateResponse;
        }
    }
}
