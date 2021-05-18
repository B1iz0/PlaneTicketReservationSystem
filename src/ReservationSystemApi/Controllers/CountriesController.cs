using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
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
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = _countryMapper.Map<IEnumerable<CountryResponse>>(await _countryService.GetAllAsync());
                if (response == null)
                    return BadRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CountriesController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = _countryMapper.Map<CountryDetails>(await _countryService.GetByIdAsync(id));
                if (response == null)
                    return BadRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CountriesController>
        [HttpPost]
        [Authorize(Policy = "AdminApp")]
        public async Task<IActionResult> Post([FromBody] CountryRegistration value)
        {
            try
            {
                await _countryService.PostAsync(_countryMapper.Map<Country>(value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CountriesController>/5
        [HttpPut("{id}")]
        [Authorize(Policy = "AdminApp")]
        public async Task<IActionResult> Put(int id, [FromBody] CountryRegistration value)
        {
            try
            {
                await _countryService.UpdateAsync(id, _countryMapper.Map<Country>(value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CountriesController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminApp")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _countryService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
