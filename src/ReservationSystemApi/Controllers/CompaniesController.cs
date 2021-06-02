using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.CompanyModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly IDataService<Company> _companyService;
        private readonly Mapper _companyMapper;

        public CompaniesController(IDataService<Company> service, ApiMappingsConfiguration conf)
        {
            _companyService = service;
            _companyMapper = new Mapper(conf.CompanyMapperConfiguration);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = _companyMapper.Map<IEnumerable<CompanyResponse>>(await _companyService.GetAllAsync());
            if (response == null)
            {
                throw new NullReferenceException();
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = _companyMapper.Map<CompanyDetails>(await _companyService.GetByIdAsync(id));
            if (response == null)
            {
                throw new NullReferenceException();
            }
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Policy = "AdminApp")]
        public async Task<IActionResult> Post([FromBody] CompanyRegistration value)
        {
            await _companyService.PostAsync(_companyMapper.Map<Company>(value));
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Put(int id, [FromBody] CompanyRegistration value)
        {
            await _companyService.UpdateAsync(id, _companyMapper.Map<Company>(value));
            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminApp")]
        public async Task<IActionResult> Delete(int id)
        {
            await _companyService.DeleteAsync(id);
            return Ok();
        }
    }
}
