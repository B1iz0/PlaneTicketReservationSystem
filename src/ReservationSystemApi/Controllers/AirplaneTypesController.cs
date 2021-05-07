using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using AutoMapper;
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
        public IEnumerable<AirplaneTypeResponse> Get()
        {
            return _airplaneTypeMapper.Map<IEnumerable<AirplaneTypeResponse>>(_airplaneTypeService.GetAll());
        }

        // GET api/<AirplaneTypesController>/5
        [HttpGet("{id}")]
        public AirplaneTypeDetails Get(int id)
        {
            return _airplaneTypeMapper.Map<AirplaneTypeDetails>(_airplaneTypeService.GetById(id));
        }

        // POST api/<AirplaneTypesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AirplaneTypesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AirplaneTypesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
