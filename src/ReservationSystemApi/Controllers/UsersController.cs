using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
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
        private readonly IDataService<User> _userService;
        private readonly IAccountService _account;
        private readonly Mapper _userMapper;
        private readonly Mapper _authMapper;

        public UsersController(IDataService<User> userService, IAccountService account, ApiMappingsConfiguration conf)
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
                return BadRequest(new { message = "Username or password is incorrect" });

            SetTokenCookie(response.RefreshToken);

            return Ok(_authMapper.Map<AuthenticateResponse>(response));
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = await _account.RefreshTokenAsync(refreshToken);

            if (response == null)
                return Unauthorized(new { message = "Invalid token" });

            SetTokenCookie(response.RefreshToken);

            return Ok(response);
        }

        [HttpPost("revoke-token")]
        public async Task<IActionResult> RevokeToken([FromBody] RevokeTokenRequest model)
        {
            // accept token from request body or cookie
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });

            var response = await _account.RevokeTokenAsync(token);

            if (!response)
                return NotFound(new { message = "Token not found" });

            return Ok(new { message = "Token revoked" });
        }

        // GET: api/<UsersController>
        [Authorize(Policy = "AdminApp")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var users = _userMapper.Map<IEnumerable<UserResponse>>(await _userService.GetAllAsync());
                if (users == null)
                    return BadRequest();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<UsersController>/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = _userMapper.Map<UserDetails>(await _userService.GetByIdAsync(id));
                if (response == null)
                    return BadRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        // POST api/<UsersController>
        [Authorize(Policy = "AdminApp")]
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] UserRegistration user)
        {
            try
            {
                await _userService.PostAsync(_userMapper.Map<User>(user));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<UsersController>
        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] UserRegistration user)
        {
            try
            {
                user.RoleId = 3;
                await _userService.PostAsync(_userMapper.Map<User>(user));
                return await Authenticate(new AuthenticateRequest() {Email = user.Email, Password = user.Password});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsersController>/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UserRegistration user)
        {
            try
            {
                var role = User.Claims.FirstOrDefault(x =>
                    x.Type.Equals(ClaimTypes.Role))?.Value;
                switch (role)
                {
                    case null: return BadRequest();
                    case "Admin": user.RoleId = 2;
                        break;
                    case "User": user.RoleId = 3;
                        break;
                }
                await _userService.UpdateAsync(id, _userMapper.Map<User>(user));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<UsersController>/5
        [Authorize(Policy = "AdminApp")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _userService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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
