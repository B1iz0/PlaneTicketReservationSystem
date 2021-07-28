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
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Airport;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.SearchFilters;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.SearchHints;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly IAirportService _airportService;

        private readonly Mapper _airportMapper;

        private readonly IMapper _mapper;

        public AirportsController(IAirportService service, ApiMappingsConfiguration conf, IMapper mapper)
        {
            _airportService = service;
            _airportMapper = new Mapper(conf.AirportConfiguration);
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var response = _airportMapper.Map<IEnumerable<AirportResponseModel>>(await _airportService.GetAllAsync());
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetFilteredAirports([FromQuery] AirportFilterModel filter, int offset, int limit)
        {
            IEnumerable<Airport> airports = _airportService.GetFilteredAirports(_mapper.Map<AirportFilter>(filter), offset, limit);
            var response = _airportMapper.Map<IEnumerable<AirportResponseModel>>(airports);
            return Ok(response);
        }

        [HttpGet("count")]
        public IActionResult GetFilteredAirportsCount([FromQuery] AirportFilterModel filter)
        {
            var airportsCount = _airportService.GetFilteredAirportsCount(_mapper.Map<AirportFilter>(filter));
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

        [HttpGet("hints")]
        public IActionResult GetHints([FromQuery] AirportFilterModel filter, int offset = 0, int limit = 6)
        {
            IEnumerable<AirportHint> hints = _airportService.GetHints(_mapper.Map<AirportFilter>(filter), offset, limit);
            var response = _mapper.Map<IEnumerable<AirportHintModel>>(hints);
            return Ok(response);
        }
    }
}
