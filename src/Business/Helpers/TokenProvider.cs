using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PlaneTicketReservationSystem.Business.Constants;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Business.Helpers
{
    public class TokenProvider : ITokenProvider
    {
        private readonly TokenSettings _tokenSettings;

        private readonly IRoleRepository _roles;

        private readonly IUserRepository _users;

        private readonly Mapper _userMapper;

        public TokenProvider(IOptions<TokenSettings> tokenSettings, IUserRepository users, IRoleRepository roles, BusinessMappingsConfiguration conf)
        {
            _tokenSettings = tokenSettings.Value;
            _roles = roles;
            _users = users;
            _userMapper = new Mapper(conf.AirlineConfiguration);
        }

        public async Task<string> GenerateJwtTokenAsync(User user)
        {
            if (user == null)
            {
                return null;
            }

            var role = await _roles.GetAsync(user.RoleId);

            var roleName = role?.Name;
            if (roleName == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_tokenSettings.Key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = _tokenSettings.Audience,
                Issuer = _tokenSettings.Issuer,
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(Claims.Id, user.Id.ToString()),
                    new Claim(Claims.Email, user.Email),
                    new Claim(Claims.Role, roleName)
                }),
                Expires = DateTime.UtcNow.AddMinutes(_tokenSettings.LifeTime),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            string tokenResponse = tokenHandler.WriteToken(token);
            return tokenResponse;
        }

        public RefreshToken GenerateRefreshToken()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[_tokenSettings.RefreshTokenBytesAmount];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            var refreshTokenResponse = new RefreshToken
            {
                Token = Convert.ToBase64String(randomBytes),
                Expires = DateTime.UtcNow.AddMinutes(_tokenSettings.RefreshTokenLifeTime),
                Created = DateTime.UtcNow,
            };
            return refreshTokenResponse;
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
