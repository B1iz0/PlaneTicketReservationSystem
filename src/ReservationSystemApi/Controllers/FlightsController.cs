using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Models.SearchFilters;
using PlaneTicketReservationSystem.Business.Models.SearchHints;
using PlaneTicketReservationSystem.ReservationSystemApi.Helpers;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Flight;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.SearchFilters;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.SearchHints;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightsController : ControllerBase
    {
        private readonly IFlightService _flightService;

        private readonly Mapper _flightMapper;

        private readonly IMapper _mapper;

        public FlightsController(IFlightService service, ApiMappingsConfiguration conf, IMapper mapper)
        {
            _flightService = service;
            _flightMapper = new Mapper(conf.FlightMapperConfiguration);
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] FlightFilterModel filter, int offset, int limit = 16)
        {
            IEnumerable<Flight> flights =
                _flightService.GetFilteredFlights(_mapper.Map<FlightFilter>(filter), offset, limit);
            var response = _flightMapper.Map<IEnumerable<FlightResponseModel>>(flights);
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = _flightMapper.Map<FlightDetailsModel>(await _flightService.GetByIdAsync(id));
            return Ok(response);
        }

        [HttpGet("count")]
        public IActionResult GetCount([FromQuery] FlightFilterModel filter)
        {
            var response = _flightService.GetFilteredFlightsCount(_mapper.Map<FlightFilter>(filter));
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Policy = ApiPolicies.AdminPolicy)]
        public async Task<IActionResult> Post([FromBody] FlightRegistrationModel value)
        {
            await _flightService.PostAsync(_flightMapper.Map<Flight>(value));
            return Ok();
        }

        [HttpPut("{id:guid}")]
        [Authorize(Policy = ApiPolicies.AdminPolicy)]
        public async Task<IActionResult> Put(Guid id, [FromBody] FlightRegistrationModel value)
        {
            await _flightService.UpdateAsync(id, _flightMapper.Map<Flight>(value));
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Policy = ApiPolicies.AdminPolicy)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _flightService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("hints")]
        public IActionResult GetHints([FromQuery] FlightFilterModel filter, int offset = 0, int limit = 6)
        {
            IEnumerable<FlightHint> hints = _flightService.GetHints(_mapper.Map<FlightFilter>(filter), offset, limit);
            var flightHints = _mapper.Map<IEnumerable<FlightHintModel>>(hints);
            return Ok(flightHints);
        }
    }
}
