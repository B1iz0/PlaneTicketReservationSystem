using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneTypeModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplaneTypesController : ControllerBase
    {
        private readonly IDataService<AirplaneType> _airplaneTypeService;
        private readonly Mapper _airplaneTypeMapper;

        public AirplaneTypesController(IDataService<AirplaneType> service, ApiMappingsConfiguration conf)
        {
            _airplaneTypeService = service;
            _airplaneTypeMapper = new Mapper(conf.AirplaneTypeMapperConfiguration);
        }

        // GET: api/<AirplaneTypesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = _airplaneTypeMapper.Map<IEnumerable<AirplaneTypeResponse>>(await _airplaneTypeService.GetAllAsync());
            if (response == null)
                throw new NullReferenceException();
            return Ok(response);
        }

        // GET api/<AirplaneTypesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = _airplaneTypeMapper.Map<AirplaneTypeDetails>(await _airplaneTypeService.GetByIdAsync(id));
            if (response == null)
                throw new NullReferenceException();
            return Ok(response);
        }

        // POST api/<AirplaneTypesController>
        [HttpPost]
        [Authorize(Policy = "AdminApp")]
        public async Task<IActionResult> Post([FromBody] AirplaneTypeRegistration value)
        {
            await _airplaneTypeService.PostAsync(_airplaneTypeMapper.Map<AirplaneType>(value));
            return Ok();
        }

        // PUT api/<AirplaneTypesController>/5
        [HttpPut("{id}")]
        [Authorize(Policy = "AdminApp")]
        public async Task<IActionResult> Put(int id, [FromBody] AirplaneTypeRegistration value)
        {
            await _airplaneTypeService.UpdateAsync(id, _airplaneTypeMapper.Map<AirplaneType>(value));
            return Ok();
        }

        // DELETE api/<AirplaneTypesController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminApp")]
        public async Task<IActionResult> Delete(int id)
        {
            await _airplaneTypeService.DeleteAsync(id);
            return Ok();
        }
    }
}
