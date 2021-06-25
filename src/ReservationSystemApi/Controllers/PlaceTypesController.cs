using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Helpers;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.PlaceType;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceTypesController : ControllerBase
    {
        private readonly IPlaceTypeService _placeTypeService;

        private readonly Mapper _placeTypeMapper;

        public PlaceTypesController(IPlaceTypeService placeTypeService, ApiMappingsConfiguration conf)
        {
            _placeTypeService = placeTypeService;
            _placeTypeMapper = new Mapper(conf.PlaceTypeMapperConfiguration);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = _placeTypeMapper.Map<IEnumerable<PlaceTypeResponseModel>>(await _placeTypeService.GetAllAsync());
            return Ok(response);
        }

        [Authorize(Policy = ApiPolicies.AdminPolicy)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PlaceTypeRegistrationModel value)
        {
            await _placeTypeService.PostAsync(_placeTypeMapper.Map<PlaceType>(value));
            return Ok();
        }

        [Authorize(Policy = ApiPolicies.AdminAppPolicy)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PlaceTypeRegistrationModel value)
        {
            await _placeTypeService.UpdateAsync(id, _placeTypeMapper.Map<PlaceType>(value));
            return Ok();
        }
    }
}
