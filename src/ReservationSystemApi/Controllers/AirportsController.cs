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
    public class AirportsController : ControllerBase
    {
        private readonly IDataService<Airport> _airportService;
        private readonly Mapper _airportMapper;

        public AirportsController(IDataService<Airport> service, ApiMappingsConfiguration conf)
        {
            _airportService = service;
            _airportMapper = new Mapper(conf.AirportConfiguration);
        }

        // GET: api/<AirportsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AirportsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AirportsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AirportsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AirportsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
