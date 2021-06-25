using System;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IPasswordProvider _passwordProvider;

        private readonly IUserRepository _users;

        private readonly ITokenProvider _tokenProvider;

        private readonly IMapper _userMapper;

        public AccountService(
            IPasswordProvider passwordProvider, 
            IUserRepository users,
            ITokenProvider tokenProvider,
            IMapper mapper)
        {
            _passwordProvider = passwordProvider;
            _users = users;
            _tokenProvider = tokenProvider;
            _userMapper = mapper;
        }

        public async Task<Authenticate> AuthenticateAsync(Authenticate model)
        {
            var userEntity = await _users.GetByEmailAsync(model.Email);
            if (userEntity == null)
            {
                throw new Exception("User with such email doesn't exist.");
            }

            bool isPasswordConfirmed = _passwordProvider.CheckHash(model.Password, userEntity.Password);
            if (!isPasswordConfirmed)
            {
                throw new Exception("Password is not correct.");
            }

            var user = _userMapper.Map<User>(userEntity);
            var token = await _tokenProvider.GenerateJwtTokenAsync(user);
            var refreshToken = _tokenProvider.GenerateRefreshToken();

            var refreshTokenEntity = _userMapper.Map<RefreshTokenEntity>(refreshToken);
            userEntity.RefreshTokens.Add(refreshTokenEntity);
            await _users.UpdateAsync(userEntity);

            var authenticateResponse = new Authenticate(_userMapper.Map<User>(userEntity), token, refreshToken.Token);
            return authenticateResponse;
        }
    }
}
