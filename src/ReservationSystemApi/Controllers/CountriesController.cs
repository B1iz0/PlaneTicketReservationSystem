using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Country;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;

        private readonly Mapper _countryMapper;

        public CountriesController(ICountryService service, ApiMappingsConfiguration conf)
        {
            _countryService = service;
            _countryMapper = new Mapper(conf.CountryMapperConfiguration);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = _countryMapper.Map<IEnumerable<CountryResponseModel>>(await _countryService.GetAllAsync());
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Policy = "AdminApp")]
        public async Task<IActionResult> Post([FromBody] CountryRegistrationModel value)
        {
            await _countryService.PostAsync(_countryMapper.Map<Country>(value));
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "AdminApp")]
        public async Task<IActionResult> Put(int id, [FromBody] CountryRegistrationModel value)
        {
            await _countryService.UpdateAsync(id, _countryMapper.Map<Country>(value));
            return Ok();
        }
    }
}
