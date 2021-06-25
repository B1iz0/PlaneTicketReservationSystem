using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Helpers;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Flight;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;

        private readonly Mapper _flightMapper;

        public FlightsController(IFlightService service, ApiMappingsConfiguration conf)
        {
            _flightService = service;
            _flightMapper = new Mapper(conf.FlightMapperConfiguration);
        }

        [HttpGet]
        public IActionResult Get(string departureCity, string arrivalCity, int offset, int limit = 16)
        {
            var response = _flightMapper.Map<IEnumerable<FlightResponseModel>>(_flightService.GetFilteredFlights(offset, limit, departureCity, arrivalCity));
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = _flightMapper.Map<FlightDetailsModel>(await _flightService.GetByIdAsync(id));
            return Ok(response);
        }

        [HttpGet("count")]
        public IActionResult GetCount(string departureCity, string arrivalCity)
        {
            var response = _flightService.GetFilteredFlightsCount(departureCity, arrivalCity);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Policy = ApiPolicies.AdminPolicy)]
        public async Task<IActionResult> Post([FromBody] FlightRegistrationModel value)
        {
            await _flightService.PostAsync(_flightMapper.Map<Flight>(value));
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Policy = ApiPolicies.AdminPolicy)]
        public async Task<IActionResult> Put(int id, [FromBody] FlightRegistrationModel value)
        {
            await _flightService.UpdateAsync(id, _flightMapper.Map<Flight>(value));
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = ApiPolicies.AdminPolicy)]
        public async Task<IActionResult> Delete(int id)
        {
            await _flightService.DeleteAsync(id);
            return Ok();
        }
    }
}
