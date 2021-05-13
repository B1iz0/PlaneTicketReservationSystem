using System;
using System.Collections.Generic;
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
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _account.Authenticate(_authMapper.Map<Authenticate>(model));

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            SetTokenCookie(response.RefreshToken);

            return Ok(_authMapper.Map<AuthenticateResponse>(response));
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public IActionResult RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            var response = _account.RefreshToken(refreshToken);

            if (response == null)
                return Unauthorized(new { message = "Invalid token" });

            SetTokenCookie(response.RefreshToken);

            return Ok(response);
        }

        [HttpPost("revoke-token")]
        public IActionResult RevokeToken([FromBody] RevokeTokenRequest model)
        {
            // accept token from request body or cookie
            var token = model.Token ?? Request.Cookies["refreshToken"];

            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });

            var response = _account.RevokeToken(token);

            if (!response)
                return NotFound(new { message = "Token not found" });

            return Ok(new { message = "Token revoked" });
        }

        // GET: api/<UsersController>
        [Authorize(Policy = "AdminApp")]
        [HttpGet]
        //Will use mapping soon
        public IActionResult Get()
        {
            try
            {
                var users = _userMapper.Map<IEnumerable<UserResponse>>(_userService.GetAll());
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
        [Authorize(Policy = "AdminApp")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var response = _userMapper.Map<UserDetails>(_userService.GetById(id));
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
        public IActionResult Post([FromBody] UserRegistration user)
        {
            try
            {
                _userService.Post(_userMapper.Map<User>(user));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<UsersController>
        [HttpPost("registration")]
        public IActionResult Registration([FromBody] UserRegistration user)
        {
            try
            {
                _userService.Post(_userMapper.Map<User>(user));
                return Authenticate(new AuthenticateRequest() {Email = user.Email, Password = user.Password});
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<UsersController>/5
        [Authorize(Policy = "AdminApp")]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserRegistration value)
        {
            try
            {
                _userService.Update(id, _userMapper.Map<User>(value));
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
        public IActionResult Delete(int id)
        {
            try
            {
                _userService.Delete(id);
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
