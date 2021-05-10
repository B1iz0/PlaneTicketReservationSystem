using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Services;
using PlaneTicketReservationSystem.ReservationSystemApi.Mappers;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.CountryModels;

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
        [Authorize]
        public IActionResult Get()
        {
            var response = _countryMapper.Map<IEnumerable<CountryResponse>>(_countryService.GetAll());
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        // GET api/<CountriesController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var response = _countryMapper.Map<CountryResponse>(_countryService.GetById(id));
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        // POST api/<CountriesController>
        [HttpPost]
        [Authorize]
        public void Post([FromBody] CountryRegistration value)
        {
            _countryService.Post(_countryMapper.Map<Country>(value));
        }

        // PUT api/<CountriesController>/5
        [HttpPut("{id}")]
        [Authorize]
        public void Put(int id, [FromBody] CountryRegistration value)
        {
            _countryService.Update(id, _countryMapper.Map<Country>(value));
        }

        // DELETE api/<CountriesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
            _countryService.Delete(id);
        }
    }
}
