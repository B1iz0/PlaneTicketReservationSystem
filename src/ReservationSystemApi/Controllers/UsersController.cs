using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Services;
using PlaneTicketReservationSystem.ReservationSystemApi.Mappers;
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

            return Ok(response);
        }

        // GET: api/<UsersController>
        [Authorize(Policy = "AdminApp")]
        [HttpGet]
        //Will use mapping soon
        public IActionResult Get()
        {
            var users =  _userMapper.Map<IEnumerable<UserDetails>>(_userService.GetAll());
            if (users == null)
                return BadRequest();
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [Authorize(Policy = "AdminApp")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        // POST api/<UsersController>
        [Authorize(Policy = "AdminApp")]
        [HttpPost()]
        public void Post([FromBody] UserRegistration user)
        {
            _userService.Post(_userMapper.Map<User>(user));
        }

        // POST api/<UsersController>
        [HttpPost("registration")]
        public IActionResult Registration([FromBody] UserRegistration user)
        {
            _userService.Post(_userMapper.Map<User>(user));

            return Authenticate(new AuthenticateRequest() {Email = user.Email, Password = user.Password});
        }

        // PUT api/<UsersController>/5
        [Authorize(Policy = "AdminApp")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserRegistration value)
        {
            _userService.Update(id, _userMapper.Map<User>(value));
        }

        // DELETE api/<UsersController>/5
        [Authorize(Policy = "AdminApp")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.Delete(id);
        }
    }
}
