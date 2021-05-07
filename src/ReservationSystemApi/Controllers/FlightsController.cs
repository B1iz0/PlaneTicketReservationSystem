using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Services;
using PlaneTicketReservationSystem.ReservationSystemApi.Mappers;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<FlightsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FlightsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FlightsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FlightsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
