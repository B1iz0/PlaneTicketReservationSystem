using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Helpers;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.City;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        private readonly Mapper _cityMapper;

        public CitiesController(ICityService service, ApiMappingsConfiguration conf)
        {
            _cityService = service;
            _cityMapper = new Mapper(conf.CityMapperConfiguration);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = _cityMapper.Map<IEnumerable<CityResponseModel>>(await _cityService.GetAllAsync());
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Policy = ApiPolicies.AdminPolicy)]
        public async Task<IActionResult> Post([FromBody] CityRegistrationModel value)
        {
            await _cityService.PostAsync(_cityMapper.Map<City>(value));
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Policy = ApiPolicies.AdminAppPolicy)]
        public async Task<IActionResult> Put(int id, [FromBody] CityRegistrationModel value)
        {
            await _cityService.UpdateAsync(id, _cityMapper.Map<City>(value));
            return Ok();
        }
    }
}
