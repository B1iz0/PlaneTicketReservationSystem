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
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Airplane;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.SearchFilters;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.SearchHints;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplanesController : ControllerBase
    {
        private readonly IAirplaneService _airplaneService;

        private readonly Mapper _airplaneMapper;

        private readonly IMapper _mapper;

        public AirplanesController(IAirplaneService service, ApiMappingsConfiguration conf, IMapper mapper)
        {
            _airplaneService = service;
            _airplaneMapper = new Mapper(conf.AirplaneMapperConfiguration);
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] AirplaneFilterModel filter, int offset, int limit)
        {
            IEnumerable<Airplane> airplanes =
                _airplaneService.GetFilteredAirplanes(_mapper.Map<AirplaneFilter>(filter), offset, limit);
            var response = _airplaneMapper.Map<IEnumerable<AirplaneResponseModel>>(airplanes);
            return Ok(response);
        }

        [HttpGet("count")]
        public IActionResult GetCount([FromQuery] AirplaneFilterModel filter)
        {
            var response = _airplaneService.GetFilteredAirplanesCount(_mapper.Map<AirplaneFilter>(filter));
            return Ok(response);
        }

        [HttpGet("free")]
        public IActionResult GetFreeAirplanes()
        {
            var response = _airplaneMapper.Map<IEnumerable<AirplaneResponseModel>>(_airplaneService.GetFreeAirplanes());
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = _airplaneMapper.Map<AirplaneResponseModel>(await _airplaneService.GetByIdAsync(id));
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Policy = ApiPolicies.AdminPolicy)]
        public async Task<IActionResult> Post([FromBody] AirplaneRegistrationModel value)
        {
            Airplane createdAirplane = await _airplaneService.PostAsync(_airplaneMapper.Map<Airplane>(value));
            var response = _airplaneMapper.Map<AirplaneResponseModel>(createdAirplane);
            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Policy = ApiPolicies.AdminPolicy)]
        public async Task<IActionResult> Put(Guid id, [FromBody] AirplaneRegistrationModel value)
        {
            await _airplaneService.UpdateAsync(id, _airplaneMapper.Map<Airplane>(value));
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Policy = ApiPolicies.AdminPolicy)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _airplaneService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("hints")]
        public IActionResult GetHints([FromQuery] AirplaneFilterModel filter, int offset = 0, int limit = 6)
        {
            IEnumerable<AirplaneHint> hints =
                _airplaneService.GetHints(_mapper.Map<AirplaneFilter>(filter), offset, limit);
            var response = _mapper.Map<IEnumerable<AirplaneHintModel>>(hints);
            return Ok(response);
        }
    }
}
