using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
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
            try
            {
                var response = _airportMapper.Map<IEnumerable<AirportResponse>>(_airportService.GetAll());
                if (response == null)
                    return BadRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<AirportsController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var response = _airportMapper.Map<AirportDetails>(_airportService.GetById(id));
                if (response == null)
                    return BadRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AirportsController>
        [HttpPost]
        [Authorize(Policy = "Admin")]
        public IActionResult Post([FromBody] AirportRegistration value)
        {
            try
            {
                _airportService.Post(_airportMapper.Map<Airport>(value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AirportsController>/5
        [HttpPut("{id}")]
        [Authorize(Policy = "Admin")]
        public IActionResult Put(int id, [FromBody] AirportRegistration value)
        {
            try
            {
                _airportService.Update(id, _airportMapper.Map<Airport>(value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AirportsController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                _airportService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
