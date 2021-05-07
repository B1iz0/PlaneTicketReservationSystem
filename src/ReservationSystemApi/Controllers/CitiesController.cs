using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Services;
using PlaneTicketReservationSystem.ReservationSystemApi.Mappers;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IDataService<City> _cityService;
        private readonly Mapper _cityMapper;

        public CitiesController(IDataService<City> service, ApiMappingsConfiguration conf)
        {
            _cityService = service;
            _cityMapper = new Mapper(conf.CityMapperConfiguration);
        }

        // GET: api/<CitiesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CitiesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CitiesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CitiesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CitiesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
