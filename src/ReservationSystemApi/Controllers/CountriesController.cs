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
    public class CountriesController : ControllerBase
    {
        private readonly IDataService<Country> _countryService;
        private readonly Mapper _countryMapper;

        public CountriesController(IDataService<Country> service, ApiMappingsConfiguration conf)
        {
            _countryService = service;
            _countryMapper = new Mapper(conf.CountryMapperConfiguration);
        }

        // GET: api/<CountriesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CountriesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CountriesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CountriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CountriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
