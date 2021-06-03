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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = _countryMapper.Map<IEnumerable<CountryResponse>>(await _countryService.GetAllAsync());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = _countryMapper.Map<CountryDetails>(await _countryService.GetByIdAsync(id));
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Policy = "AdminApp")]
        public async Task<IActionResult> Post([FromBody] CountryRegistration value)
        {
            await _countryService.PostAsync(_countryMapper.Map<Country>(value));
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminApp")]
        public async Task<IActionResult> Put(int id, [FromBody] CountryRegistration value)
        {
            await _countryService.UpdateAsync(id, _countryMapper.Map<Country>(value));
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminApp")]
        public async Task<IActionResult> Delete(int id)
        {
            await _countryService.DeleteAsync(id);
            return Ok();
        }
    }
}
