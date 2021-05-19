using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
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
        public async Task<IActionResult> Get()
        {
            var response = _cityMapper.Map<IEnumerable<CityResponse>>(await _cityService.GetAllAsync());
            if (response == null)
                throw new NullReferenceException();
            return Ok(response);
        }

        // GET api/<CitiesController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            var response = _cityMapper.Map<CityDetails>(await _cityService.GetByIdAsync(id));
            if (response == null)
                throw new NullReferenceException();
            return Ok(response);
        }

        // POST api/<CitiesController>
        [HttpPost]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Post([FromBody] CityRegistration value)
        {
            await _cityService.PostAsync(_cityMapper.Map<City>(value));
            return Ok();
        }

        // PUT api/<CitiesController>/5
        [HttpPut("{id}")]
        [Authorize(Policy = "AdminApp")]
        public async Task<IActionResult> Put(int id, [FromBody] CityRegistration value)
        {
            await _cityService.UpdateAsync(id, _cityMapper.Map<City>(value));
            return Ok();
        }

        // DELETE api/<CitiesController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminApp")]
        public async Task<IActionResult> Delete(int id)
        {
            await _cityService.DeleteAsync(id);
            return Ok();
        }
    }
}
