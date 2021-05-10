using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Services;
using PlaneTicketReservationSystem.ReservationSystemApi.Mappers;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneTypeModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplaneTypesController : ControllerBase
    {
        private readonly IDataService<AirplaneType> _airplaneTypeService;
        private readonly Mapper _airplaneTypeMapper;

        public AirplaneTypesController(IDataService<AirplaneType> service, ApiMappingsConfiguration conf)
        {
            _airplaneTypeService = service;
            _airplaneTypeMapper = new Mapper(conf.AirplaneTypeMapperConfiguration);
        }

        // GET: api/<AirplaneTypesController>
        [HttpGet]
        public IActionResult Get()
        {
            var response = _airplaneTypeMapper.Map<IEnumerable<AirplaneTypeResponse>>(_airplaneTypeService.GetAll());
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        // GET api/<AirplaneTypesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var response = _airplaneTypeMapper.Map<AirplaneTypeDetails>(_airplaneTypeService.GetById(id));
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        // POST api/<AirplaneTypesController>
        [HttpPost]
        [Authorize(Policy = "AdminApp")]
        public void Post([FromBody] AirplaneTypeRegistration value)
        {
            _airplaneTypeService.Post(_airplaneTypeMapper.Map<AirplaneType>(value));
        }

        // PUT api/<AirplaneTypesController>/5
        [HttpPut("{id}")]
        [Authorize(Policy = "AdminApp")]
        public void Put(int id, [FromBody] AirplaneTypeRegistration value)
        {
            _airplaneTypeService.Update(id, _airplaneTypeMapper.Map<AirplaneType>(value));
        }

        // DELETE api/<AirplaneTypesController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminApp")]
        public void Delete(int id)
        {
            _airplaneTypeService.Delete(id);
        }
    }
}
