using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.FlightModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IDataService<Flight> _flightService;
        private readonly Mapper _flightMapper;

        public FlightsController(IDataService<Flight> service, ApiMappingsConfiguration conf)
        {
            _flightService = service;
            _flightMapper = new Mapper(conf.FlightMapperConfiguration);
        }

        // GET: api/<FlightsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = _flightMapper.Map<IEnumerable<FlightResponse>>(await _flightService.GetAllAsync());
            if (response == null)
                throw new NullReferenceException();
            return Ok(response);
        }

        // GET api/<FlightsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = _flightMapper.Map<FlightDetails>(await _flightService.GetByIdAsync(id));
            if (response == null)
                throw new NullReferenceException();
            return Ok(response);
        }

        // GET api/<FlightsController>/count
        [HttpGet("count")]
        public async Task<IActionResult> GetCount()
        {
            var response = _flightMapper.Map<IEnumerable<FlightResponse>>(await _flightService.GetAllAsync());
            if (response == null)
                throw new NullReferenceException();
            return Ok(response.Count());
        }

        // POST api/<FlightsController>
        [HttpPost]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Post([FromBody] FlightRegistration value)
        {
            await _flightService.PostAsync(_flightMapper.Map<Flight>(value));
            return Ok();
        }

        // PUT api/<FlightsController>/5
        [HttpPut("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Put(int id, [FromBody] FlightRegistration value)
        {
            await _flightService.UpdateAsync(id, _flightMapper.Map<Flight>(value));
            return Ok();
        }

        // DELETE api/<FlightsController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _flightService.DeleteAsync(id);
            return Ok();
        }
    }
}
