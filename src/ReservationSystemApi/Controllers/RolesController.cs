using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
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
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = _roleMapper.Map<IEnumerable<RoleResponse>>(await _roleService.GetAllAsync());
                if (response == null)
                    return BadRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<RolesController>/5
        [Authorize(Policy = "AdminApp")]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = _roleMapper.Map<RoleResponse>(await _roleService.GetByIdAsync(id));
                if (response == null)
                    return BadRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<RolesController>
        [Authorize(Policy = "AdminApp")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RoleRequest value)
        {
            try
            {
                await _roleService.PostAsync(_roleMapper.Map<Role>(value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<RolesController>/5
        [Authorize(Policy = "AdminApp")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] RoleRequest value)
        {
            try
            {
                await _roleService.UpdateAsync(id, _roleMapper.Map<Role>(value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<RolesController>/5
        [Authorize(Policy = "AdminApp")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _roleService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
