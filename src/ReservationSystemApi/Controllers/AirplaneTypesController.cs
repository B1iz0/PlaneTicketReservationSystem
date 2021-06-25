using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Helpers;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneType;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplaneTypesController : ControllerBase
    {
        private readonly IAirplaneTypeService _airplaneTypeService;

        private readonly Mapper _airplaneTypeMapper;

        public AirplaneTypesController(IAirplaneTypeService service, ApiMappingsConfiguration conf)
        {
            _airplaneTypeService = service;
            _airplaneTypeMapper = new Mapper(conf.AirplaneTypeMapperConfiguration);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = _airplaneTypeMapper.Map<IEnumerable<AirplaneTypeResponseModel>>(await _airplaneTypeService.GetAllAsync());
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Policy = ApiPolicies.AdminAppPolicy)]
        public async Task<IActionResult> Post([FromBody] AirplaneTypeRegistrationModel value)
        {
            await _airplaneTypeService.PostAsync(_airplaneTypeMapper.Map<AirplaneType>(value));
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Policy = ApiPolicies.AdminAppPolicy)]
        public async Task<IActionResult> Put(int id, [FromBody] AirplaneTypeRegistrationModel value)
        {
            await _airplaneTypeService.UpdateAsync(id, _airplaneTypeMapper.Map<AirplaneType>(value));
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = ApiPolicies.AdminAppPolicy)]
        public async Task<IActionResult> Delete(int id)
        {
            await _airplaneTypeService.DeleteAsync(id);
            return Ok();
        }
    }
}
