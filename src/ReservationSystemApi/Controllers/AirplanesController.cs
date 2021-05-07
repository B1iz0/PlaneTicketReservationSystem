using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Services;
using PlaneTicketReservationSystem.ReservationSystemApi.Mappers;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplanesController : ControllerBase
    {
        private readonly IDataService<Airplane> _airplaneService;
        private readonly Mapper _airplaneMapper;

        public AirplanesController(IDataService<Airplane> service, ApiMappingsConfiguration conf)
        {
            _airplaneService = service;
            _airplaneMapper = new Mapper(conf.AirplaneMapperConfiguration);
        }

        // GET: api/<AirplanesController>
        [HttpGet]
        public IEnumerable<AirplaneResponse> Get()
        {
            return _airplaneMapper.Map<IEnumerable<AirplaneResponse>>(_airplaneService.GetAll());
        }

        // GET api/<AirplanesController>/5
        [HttpGet("{id}")]
        public AirplaneDetails Get(int id)
        {
            return _airplaneMapper.Map<AirplaneDetails>(_airplaneService.GetById(id));
        }

        // POST api/<AirplanesController>
        [HttpPost]
        public void Post([FromBody] AirplaneRegistration value)
        {
            _airplaneService.Post(_airplaneMapper.Map<Airplane>(value));
        }

        // PUT api/<AirplanesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AirplaneRegistration value)
        {
            _airplaneService.Update(id, _airplaneMapper.Map<Airplane>(value));
        }

        // DELETE api/<AirplanesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _airplaneService.Delete(id);
        }
    }
}
