using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Services;
using PlaneTicketReservationSystem.ReservationSystemApi.Mappers;
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
        [Authorize]
        public IActionResult Get()
        {
            var response = _flightMapper.Map<IEnumerable<FlightResponse>>(_flightService.GetAll());
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        // GET api/<FlightsController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var response = _flightMapper.Map<FlightDetails>(_flightService.GetById(id));
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        // POST api/<FlightsController>
        [HttpPost]
        [Authorize]
        public void Post([FromBody] FlightRegistration value)
        {
            _flightService.Post(_flightMapper.Map<Flight>(value));
        }

        // PUT api/<FlightsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public void Put(int id, [FromBody] FlightRegistration value)
        {
            _flightService.Update(id, _flightMapper.Map<Flight>(value));
        }

        // DELETE api/<FlightsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
            _flightService.Delete(id);
        }
    }
}
