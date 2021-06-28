using System;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class AccountService : IAccountService
    {
        private readonly IPasswordService _passwordService;

        private readonly IUserRepository _users;

        private readonly ITokenProvider _tokenProvider;

        private readonly IMapper _userMapper;

        public AccountService(
            IPasswordService passwordService, 
            IUserRepository users,
            ITokenProvider tokenProvider,
            IMapper mapper)
        {
            _passwordService = passwordService;
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

            bool isPasswordConfirmed = _passwordService.CheckHash(model.Password, userEntity.Password);
            if (!isPasswordConfirmed)
            {
                throw new Exception("Password is not correct.");
            }

            var user = _userMapper.Map<User>(userEntity);
            var token = await _tokenProvider.GenerateJwtTokenAsync(user);
            var refreshToken = _tokenProvider.GenerateRefreshToken();

            var refreshTokenEntity = _userMapper.Map<RefreshTokenEntity>(refreshToken);
            userEntity.RefreshToken = refreshTokenEntity;
            await _users.UpdateAsync(userEntity);

            var authenticateResponse = new Authenticate(_userMapper.Map<User>(userEntity), token, refreshToken.Token);
            return authenticateResponse;
        }
    }
}
