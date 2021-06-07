using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using PlaneTicketReservationSystem.Business.Helpers;
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

        private readonly Mapper _userMapper;

        private readonly Mapper _authMapper;

        public UsersController(IUserService userService, IAccountService account, ApiMappingsConfiguration conf)
        {
            _userService = userService;
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

            SetTokenCookie(response.RefreshToken);

            return Ok(_authMapper.Map<AuthenticateResponse>(response));
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest model)
        {
            var refreshToken = model.RefreshToken;
            var response = await _account.RefreshTokenAsync(refreshToken);

            if (response == null)
            {
                return Unauthorized(new {message = "Invalid token"});
            }

            SetTokenCookie(response.RefreshToken);

            return Ok(response);
        }

        [HttpPost("revoke-token")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenRequest model)
        {
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
            {
                return BadRequest(new {message = "Token is required"});
            }

            var response = await _account.RevokeTokenAsync(token);

            if (!response)
            {
                return NotFound(new {message = "Token not found"});
            }

            return Ok(new { message = "Token revoked" });
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
            var role = User.Claims.FirstOrDefault(x =>
                x.Type.Equals(ClaimTypes.Role))?.Value;
            switch (role)
            {
                case null: return BadRequest();
                case "Admin":
                    user.RoleId = 2;
                    break;
                case "User":
                    user.RoleId = 3;
                    break;
            }
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

        private void SetTokenCookie(string token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = DateTime.UtcNow.AddMinutes(10)
            };
            Response.Cookies.Append("refreshToken", token, cookieOptions);
        }
    }
}
