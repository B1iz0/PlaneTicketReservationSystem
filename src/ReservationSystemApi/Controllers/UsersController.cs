using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Constants;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Models.SearchFilters;
using PlaneTicketReservationSystem.Business.Models.SearchHints;
using PlaneTicketReservationSystem.ReservationSystemApi.Helpers;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Authenticate;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.SearchFilters;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.SearchHints;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.User;

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

        private readonly IMapper _mapper;

        public UsersController(IUserService userService, ITokenProvider tokenProvider, IAccountService account, ApiMappingsConfiguration conf, IMapper mapper)
        {
            _userService = userService;
            _tokenProvider = tokenProvider;
            _account = account;
            _userMapper = new Mapper(conf.UserMapperConfiguration);
            _authMapper = new Mapper(conf.AuthMapperConfiguration);
            _mapper = mapper;
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateRequestModel model)
        {
            var response = await _account.AuthenticateAsync(_authMapper.Map<Authenticate>(model));

            if (response == null)
            {
                return BadRequest(new {message = "Username or password is incorrect"});
            }

            return Ok(_authMapper.Map<AuthenticateResponseModel>(response));
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestModel model)
        {
            var refreshToken = model.RefreshToken;
            var response = await _tokenProvider.RefreshTokenAsync(refreshToken);

            if (response == null)
            {
                return Unauthorized(new {message = "Invalid token"});
            }

            return Ok(response);
        }

        [Authorize(Policy = ApiPolicies.AdminAppPolicy)]
        [HttpGet("free")]
        public IActionResult GetFreeUsers()
        {
            IEnumerable<User> users = _userService.GetFreeUsers();
            var usersResponse = _userMapper.Map<IEnumerable<UserResponseModel>>(users);
            return Ok(usersResponse);
        }

        [Authorize(Policy = ApiPolicies.AdminAppPolicy)]
        [HttpGet]
        public IActionResult Get([FromQuery] UserFilterModel filter, int offset, int limit)
        {
            IEnumerable<User> users = _userService.GetFilteredUsers(_mapper.Map<UserFilter>(filter), offset, limit);
            var response = _userMapper.Map<IEnumerable<UserResponseModel>>(users);
            return Ok(response);
        }

        [Authorize(Policy = ApiPolicies.AdminAppPolicy)]
        [HttpGet("count")]
        public IActionResult GetCount([FromQuery] UserFilterModel filter)
        {
            var response = _userService.GetFilteredUsersCount(_mapper.Map<UserFilter>(filter));
            return Ok(response);
        }

        [Authorize]
        [HttpGet("myself")]
        public async Task<IActionResult> Get()
        {
            var userId = HttpContext.User.Claims.FirstOrDefault(c => c.Type == Claims.Id);
            if (userId == null)
            {
                return BadRequest("Server problems");
            }
            var response = _userMapper.Map<UserDetailsModel>(await _userService.GetByIdAsync(Guid.Parse(userId.Value)));
            if (response == null)
            {
                return BadRequest();
            }
            return Ok(response);
        }

        [Authorize(Policy = ApiPolicies.AdminAppPolicy)]
        [HttpGet("managers")]
        public IActionResult GetManagers([FromQuery] Guid companyId)
        {
            IEnumerable<User> users = _userService.GetManagers(companyId);
            var usersResponse = _userMapper.Map<IEnumerable<UserResponseModel>>(users);
            return Ok(usersResponse);
        }

        [Authorize(Policy = ApiPolicies.AdminAppPolicy)]
        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] UserRegistrationModel user)
        {
            await _userService.PostAsync(_userMapper.Map<User>(user));
            return Ok();
        }

        [HttpPost("registration")]
        public async Task<IActionResult> Registration([FromBody] UserRegistrationModel user)
        {
            await _userService.PostAsync(_userMapper.Map<User>(user));
            IActionResult registrationResult = await Authenticate(new AuthenticateRequestModel() { Email = user.Email, Password = user.Password });
            return registrationResult;
        }

        [Authorize]
        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UserRegistrationModel user)
        {
            await _userService.UpdateAsync(id, _userMapper.Map<User>(user));
            return Ok();
        }

        [Authorize(Policy = ApiPolicies.AdminAppPolicy)]
        [HttpPost("{id:guid}/assignCompany")]
        public async Task<IActionResult> AssignCompany(Guid id, [FromQuery] Guid? companyId)
        {
            await _userService.AssignCompanyAsync(id, companyId);
            return Ok();
        }

        [Authorize(Policy = ApiPolicies.AdminAppPolicy)]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("hints")]
        public IActionResult GetHints([FromQuery] UserFilterModel filter, int offset = 0, int limit = 6)
        {
            IEnumerable<UserHint> hints = _userService.GetHints(_mapper.Map<UserFilter>(filter), offset, limit);
            var response = _mapper.Map<IEnumerable<UserHintModel>>(hints);
            return Ok(response);
        }
    }
}
