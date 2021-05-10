using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Services;
using PlaneTicketReservationSystem.ReservationSystemApi.Mappers;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.CityModels;

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
        [Authorize]
        public IActionResult Get()
        {
            var response = _cityMapper.Map<IEnumerable<CityResponse>>(_cityService.GetAll());
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        // GET api/<CitiesController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var response = _cityMapper.Map<CityDetails>(_cityService.GetById(id));
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        // POST api/<CitiesController>
        [HttpPost]
        [Authorize]
        public void Post([FromBody] CityRegistration value)
        {
            _cityService.Post(_cityMapper.Map<City>(value));
        }

        // PUT api/<CitiesController>/5
        [HttpPut("{id}")]
        [Authorize]
        public void Put(int id, [FromBody] CityRegistration value)
        {
            _cityService.Update(id, _cityMapper.Map<City>(value));
        }

        // DELETE api/<CitiesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
            _cityService.Delete(id);
        }
    }
}
