using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Services;
using PlaneTicketReservationSystem.ReservationSystemApi.Mappers;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.RoleModels;


namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IDataService<Role> _roleService;
        private readonly Mapper _roleMapper;

        public RolesController(IDataService<Role> roleService, ApiMappingsConfiguration conf)
        {
            _roleService = roleService;
            _roleMapper = new Mapper(conf.RoleMapperConfiguration);
        }

        // GET: api/<RolesController>
        [Authorize(Policy = "AdminApp")]
        [HttpGet]
        public IActionResult Get()
        {
            var response = _roleMapper.Map<IEnumerable<RoleResponse>>(_roleService.GetAll());
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        // GET api/<RolesController>/5
        [Authorize(Policy = "AdminApp")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = _roleMapper.Map<RoleResponse>(_roleService.GetById(id));
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        // POST api/<RolesController>
        [Authorize(Policy = "AdminApp")]
        [HttpPost]
        public void Post([FromBody] RoleRequest value)
        {
            _roleService.Post(_roleMapper.Map<Role>(value));
        }

        // PUT api/<RolesController>/5
        [Authorize(Policy = "AdminApp")]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] RoleRequest value)
        {
            _roleService.Update(id, _roleMapper.Map<Role>(value));
        }

        // DELETE api/<RolesController>/5
        [Authorize(Policy = "AdminApp")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _roleService.Delete(id);
        }
    }
}
