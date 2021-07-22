using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Helpers;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Airport;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportService _airportService;

        private readonly Mapper _airportMapper;

        public AirportsController(IAirportService service, ApiMappingsConfiguration conf)
        {
            _airportService = service;
            _airportMapper = new Mapper(conf.AirportConfiguration);
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var response = _airportMapper.Map<IEnumerable<AirportResponseModel>>(await _airportService.GetAllAsync());
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetFilteredAirports(string company, string airportName, string city, string country, int offset, int limit)
        {
            var airports = _airportService.GetFilteredAirports(company, airportName, city, country, offset, limit);
            var response = _airportMapper.Map<IEnumerable<AirportResponseModel>>(airports);
            return Ok(response);
        }

        [HttpGet("count")]
        public IActionResult GetFilteredAirportsCount(string company, string airportName, string city, string country)
        {
            var airportsCount = _airportService.GetFilteredAirportsCount(company, airportName, city, country);
            return Ok(airportsCount);
        }

        [HttpPost]
        [Authorize(Policy = ApiPolicies.AdminPolicy)]
        public async Task<IActionResult> Post([FromBody] AirportRegistrationModel value)
        {
            await _airportService.PostAsync(_airportMapper.Map<Airport>(value));
            return Ok();
        }

        [HttpPut("{id:guid}")]
        [Authorize(Policy = ApiPolicies.AdminPolicy)]
        public async Task<IActionResult> Put(Guid id, [FromBody] AirportRegistrationModel value)
        {
            await _airportService.UpdateAsync(id, _airportMapper.Map<Airport>(value));
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Policy = ApiPolicies.AdminPolicy)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _airportService.DeleteAsync(id);
            return Ok();
        }
    }
}
