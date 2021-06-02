using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Services;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.PriceModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly PriceService _priceService;
        private readonly Mapper _priceMapper;

        public PricesController(PriceService priceService, ApiMappingsConfiguration conf)
        {
            _priceService = priceService;
            _priceMapper = new Mapper(conf.PriceMapperConfiguration);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = _priceMapper.Map<IEnumerable<PriceResponse>>(await _priceService.GetAllAsync());
            if (response == null)
            {
                throw new NullReferenceException();
            }
            return Ok(response);
        }

        [HttpGet("{airplaneId}")]
        public async Task<IActionResult> Get(int airplaneId)
        {
            var response = _priceMapper.Map<IEnumerable<PriceResponse>>(await _priceService.GetByAirplaneIdAsync(airplaneId));
            if (response == null)
            {
                throw new NullReferenceException();
            }
            return Ok(response);
        }

        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PriceRegistration value)
        {
            await _priceService.PostAsync(_priceMapper.Map<Price>(value));
            return Ok();
        }

        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PriceRegistration value)
        {
            await _priceService.UpdateAsync(id, _priceMapper.Map<Price>(value));
            return Ok();
        }

        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _priceService.DeleteAsync(id);
            return Ok();
        }
    }
}
