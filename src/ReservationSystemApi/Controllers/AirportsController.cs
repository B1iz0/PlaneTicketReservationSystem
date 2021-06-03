using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirportModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly IDataService<Airport> _airportService;

        private readonly Mapper _airportMapper;

        public AirportsController(IDataService<Airport> service, ApiMappingsConfiguration conf)
        {
            _airportService = service;
            _airportMapper = new Mapper(conf.AirportConfiguration);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = _airportMapper.Map<IEnumerable<AirportResponse>>(await _airportService.GetAllAsync());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = _airportMapper.Map<AirportDetails>(await _airportService.GetByIdAsync(id));
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Post([FromBody] AirportRegistration value)
        {
            await _airportService.PostAsync(_airportMapper.Map<Airport>(value));
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Put(int id, [FromBody] AirportRegistration value)
        {
            await _airportService.UpdateAsync(id, _airportMapper.Map<Airport>(value));
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _airportService.DeleteAsync(id);
            return Ok();
        }
    }
}
