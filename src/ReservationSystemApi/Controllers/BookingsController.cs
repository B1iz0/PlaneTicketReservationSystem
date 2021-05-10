using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Services;
using PlaneTicketReservationSystem.ReservationSystemApi.Mappers;
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
        public IActionResult Get()
        {
            var response = _bookingMapper.Map<IEnumerable<BookingResponse>>(_bookingService.GetAll());
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        // GET api/<BookingsController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var response = _bookingMapper.Map<BookingDetails>(_bookingService.GetById(id));
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        // POST api/<BookingsController>
        [HttpPost]
        [Authorize]
        public void Post([FromBody] BookingRegistration value)
        {
            _bookingService.Post(_bookingMapper.Map<Booking>(value));
        }

        // PUT api/<BookingsController>/5
        [HttpPut("{id}")]
        [Authorize]
        public void Put(int id, [FromBody] BookingRegistration value)
        {
            _bookingService.Update(id, _bookingMapper.Map<Booking>(value));
        }

        // DELETE api/<BookingsController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
            _bookingService.Delete(id);
        }
    }
}
