using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Helpers;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Price;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly IPriceService _priceService;

        private readonly Mapper _priceMapper;

        public PricesController(IPriceService priceService, ApiMappingsConfiguration conf)
        {
            _priceService = priceService;
            _priceMapper = new Mapper(conf.PriceMapperConfiguration);
        }

        [HttpGet("{airplaneId}")]
        public async Task<IActionResult> Get(int airplaneId)
        {
            var response = _priceMapper.Map<IEnumerable<PriceResponseModel>>(await _priceService.GetByAirplaneIdAsync(airplaneId));
            return Ok(response);
        }

        [Authorize(Policy = ApiPolicies.AdminPolicy)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PriceRegistrationModel value)
        {
            await _priceService.PostAsync(_priceMapper.Map<Price>(value));
            return Ok();
        }

        [Authorize(Policy = ApiPolicies.AdminPolicy)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PriceRegistrationModel value)
        {
            await _priceService.UpdateAsync(id, _priceMapper.Map<Price>(value));
            return Ok();
        }
    }
}
