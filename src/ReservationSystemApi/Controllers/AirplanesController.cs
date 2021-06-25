using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Helpers;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Airplane;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplanesController : ControllerBase
    {
        private readonly IAirplaneService _airplaneService;

        private readonly Mapper _airplaneMapper;

        public AirplanesController(IAirplaneService service, ApiMappingsConfiguration conf)
        {
            _airplaneService = service;
            _airplaneMapper = new Mapper(conf.AirplaneMapperConfiguration);
        }

        [HttpGet]
        public IActionResult Get(string airplaneType, string company, string model, int offset, int limit)
        {
            var response = _airplaneMapper.Map<IEnumerable<AirplaneResponseModel>>(_airplaneService.GetFilteredAirplanes(offset, limit, airplaneType, company, model));
            return Ok(response);
        }

        [HttpGet("count")]
        public IActionResult GetCount(string airplaneType, string company, string model)
        {
            var response = _airplaneService.GetFilteredAirplanesCount(airplaneType, company, model);
            return Ok(response);
        }

        [HttpGet("free")]
        public IActionResult GetFreeAirplanes()
        {
            var response = _airplaneMapper.Map<IEnumerable<AirplaneResponseModel>>(_airplaneService.GetFreeAirplanes());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = _airplaneMapper.Map<AirplaneResponseModel>(await _airplaneService.GetByIdAsync(id));
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Policy = ApiPolicies.AdminPolicy)]
        public async Task<IActionResult> Post([FromBody] AirplaneRegistrationModel value)
        {
            await _airplaneService.PostAsync(_airplaneMapper.Map<Airplane>(value));
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Policy = ApiPolicies.AdminPolicy)]
        public async Task<IActionResult> Put(int id, [FromBody] AirplaneRegistrationModel value)
        {
            await _airplaneService.UpdateAsync(id, _airplaneMapper.Map<Airplane>(value));
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = ApiPolicies.AdminPolicy)]
        public async Task<IActionResult> Delete(int id)
        {
            await _airplaneService.DeleteAsync(id);
            return Ok();
        }
    }
}
