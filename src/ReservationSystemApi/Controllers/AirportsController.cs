using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Services;
using PlaneTicketReservationSystem.ReservationSystemApi.Mappers;
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

        // GET: api/<AirportsController>
        [HttpGet]
        public IActionResult Get()
        {
            var response = _airportMapper.Map<IEnumerable<AirportResponse>>(_airportService.GetAll());
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        // GET api/<AirportsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = _airportMapper.Map<AirportDetails>(_airportService.GetById(id));
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        // POST api/<AirportsController>
        [HttpPost]
        [Authorize(Policy = "Admin")]
        public void Post([FromBody] AirportRegistration value)
        {
            _airportService.Post(_airportMapper.Map<Airport>(value));
        }

        // PUT api/<AirportsController>/5
        [HttpPut("{id}")]
        [Authorize(Policy = "Admin")]
        public void Put(int id, [FromBody] AirportRegistration value)
        {
            _airportService.Update(id, _airportMapper.Map<Airport>(value));
        }

        // DELETE api/<AirportsController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
        public void Delete(int id)
        {
            _airportService.Delete(id);
        }
    }
}
