using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Services.UserService;
using PlaneTicketReservationSystem.ReservationSystemApi.Mappers;
using PlaneTicketReservationSystem.ReservationSystemApi.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.UserModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly Mapper _userMapper;
        private readonly Mapper _authMapper;

        public UsersController(IUserService userService, ApiMappingsConfiguration conf)
        {
            _userService = userService;
            _userMapper = new Mapper(conf.UserMapperConfiguration);
            _authMapper = new Mapper(conf.AuthMapperConfiguration);
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(_authMapper.Map<Authenticate>(model));

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
            var users =  _userMapper.Map<UserDetails>(_userService.GetAll());
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
        [Authorize]
        [HttpPost("registration")]
        public void Registration([FromBody] UserRegistration user)
        {
            _userService.Post(_userMapper.Map<User>(user));
        }

        // PUT api/<UsersController>/5
        [Authorize(Policy = "AdminApp")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
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
