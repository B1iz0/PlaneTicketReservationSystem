using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.BookingModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IDataService<Booking> _bookingService;

        private readonly Mapper _bookingMapper;

        public BookingsController(IDataService<Booking> service, ApiMappingsConfiguration conf)
        {
            _bookingService = service;
            _bookingMapper = new Mapper(conf.BookingMapperConfiguration);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var response = _bookingMapper.Map<IEnumerable<BookingResponse>>(await _bookingService.GetAllAsync());
            if (response == null)
            {
                throw new NullReferenceException();
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var response = _bookingMapper.Map<BookingResponse>(await _bookingService.GetByIdAsync(id));
            if (response == null)
            {
                throw new NullReferenceException();
            }
            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] BookingRegistration value)
        {
            await _bookingService.PostAsync(_bookingMapper.Map<Booking>(value));
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] BookingRegistration value)
        {
            await _bookingService.UpdateAsync(id, _bookingMapper.Map<Booking>(value));
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookingService.DeleteAsync(id);
            return Ok();
        }
    }
}
