using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Services;
using PlaneTicketReservationSystem.Business.Services.UserService;
using PlaneTicketReservationSystem.ReservationSystemApi.Mappers;
using PlaneTicketReservationSystem.ReservationSystemApi.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.UserModels;
using UserDetails = PlaneTicketReservationSystem.ReservationSystemApi.Models.UserModels.UserDetails;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserMapper _userMapper;
        private readonly AuthenticateMapper _authMapper;

        public UsersController(IUserService userService)
        {
            _userService = userService;
            _userMapper = new UserMapper();
            _authMapper = new AuthenticateMapper();
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(_authMapper.AuthenticateRequestToAuthenticate(model));

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
            var users = _userService.GetAll();
            return Ok(users);
        }

        // GET api/<UsersController>/5
        [Authorize]
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
            _userService.Post(_userMapper.UserRegistrationToUser(user));
        }

        // POST api/<UsersController>
        [Authorize]
        [HttpPost("registration")]
        public void Registration([FromBody] UserRegistration user)
        {
            _userService.Post(_userMapper.UserRegistrationToUser(user));
        }

        // PUT api/<UsersController>/5
        [Authorize]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UsersController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.Delete(id);
        }
    }
}
