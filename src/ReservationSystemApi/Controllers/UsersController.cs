using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.UserModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IAccountService _account;

        private readonly ITokenProvider _tokenProvider;

        private readonly Mapper _userMapper;

        private readonly Mapper _authMapper;

        public UsersController(IUserService userService, ITokenProvider tokenProvider, IAccountService account, ApiMappingsConfiguration conf)
        {
            _userService = userService;
            _tokenProvider = tokenProvider;
            _account = account;
            _userMapper = new Mapper(conf.UserMapperConfiguration);
            _authMapper = new Mapper(conf.AuthMapperConfiguration);
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequest model)
        {
            var response = await _account.AuthenticateAsync(_authMapper.Map<Authenticate>(model));

            if (response == null)
            {
                return BadRequest(new {message = "Username or password is incorrect"});
            }

            return Ok(_authMapper.Map<AuthenticateResponse>(response));
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest model)
        {
            var refreshToken = model.RefreshToken;
            var response = await _tokenProvider.RefreshTokenAsync(refreshToken);

            if (response == null)
            {
                return Unauthorized(new {message = "Invalid token"});
            }

            return Ok(response);
        }

        [Authorize(Policy = "AdminApp")]
        [HttpGet]
        public IActionResult Get(int offset, int limit, string email, string firstName, string lastName)
        {
            var users = _userMapper.Map<IEnumerable<UserResponse>>(_userService.GetFilteredUsers(offset, limit, email, firstName, lastName));
            return Ok(users);
        }

        [Authorize(Policy = "AdminApp")]
        [HttpGet("count")]
        public IActionResult GetCount(string email, string firstName, string lastName)
        {
            var response = _userService.GetFilteredUsersCount(email, firstName, lastName);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = _userMapper.Map<UserDetails>(await _userService.GetByIdAsync(id));
            if (response == null)
            {
                throw new NullReferenceException();
            }
            return Ok(response);
        }

        [Authorize(Policy = "AdminApp")]
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] UserRegistration user)
        {
            await _userService.PostAsync(_userMapper.Map<User>(user));
            return Ok();
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] UserRegistration user)
        {
            user.RoleId = 3;
            await _userService.PostAsync(_userMapper.Map<User>(user));
            IActionResult registrationResult = await Authenticate(new AuthenticateRequest() { Email = user.Email, Password = user.Password });
            return registrationResult;
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserRegistration user)
        {
            await _userService.UpdateAsync(id, _userMapper.Map<User>(user));
            return Ok();
        }

        [Authorize(Policy = "AdminApp")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
    }
}
