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

        // GET: api/<BookingsController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var response = _bookingMapper.Map<IEnumerable<BookingResponse>>(await _bookingService.GetAllAsync());
            if (response == null)
                throw new NullReferenceException();
            return Ok(response);
        }

        // GET api/<BookingsController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var response = _bookingMapper.Map<BookingResponse>(await _bookingService.GetByIdAsync(id));
            if (response == null)
                throw new NullReferenceException();
            return Ok(response);
        }

        // POST api/<BookingsController>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post([FromBody] BookingRegistration value)
        {
            await _bookingService.PostAsync(_bookingMapper.Map<Booking>(value));
            return Ok();
        }

        // PUT api/<BookingsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] BookingRegistration value)
        {
            await _bookingService.UpdateAsync(id, _bookingMapper.Map<Booking>(value));
            return Ok();
        }

        // DELETE api/<BookingsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookingService.DeleteAsync(id);
            return Ok();
        }
    }
}
