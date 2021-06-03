using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplanesController : ControllerBase
    {
        private readonly IDataService<Airplane> _airplaneService;

        private readonly Mapper _airplaneMapper;

        public AirplanesController(IDataService<Airplane> service, ApiMappingsConfiguration conf)
        {
            _airplaneService = service;
            _airplaneMapper = new Mapper(conf.AirplaneMapperConfiguration);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = _airplaneMapper.Map<IEnumerable<AirplaneResponse>>(await _airplaneService.GetAllAsync());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = _airplaneMapper.Map<AirplaneResponse>(await _airplaneService.GetByIdAsync(id));
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Post([FromBody] AirplaneRegistration value)
        {
            await _airplaneService.PostAsync(_airplaneMapper.Map<Airplane>(value));
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Put(int id, [FromBody] AirplaneRegistration value)
        {
            await _airplaneService.UpdateAsync(id, _airplaneMapper.Map<Airplane>(value));
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _airplaneService.DeleteAsync(id);
            return Ok();
        }
    }
}
