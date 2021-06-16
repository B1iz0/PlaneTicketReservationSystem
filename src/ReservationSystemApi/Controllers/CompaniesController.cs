using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.CompanyModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        private readonly Mapper _companyMapper;

        public CompaniesController(ICompanyService service, ApiMappingsConfiguration conf)
        {
            _companyService = service;
            _companyMapper = new Mapper(conf.CompanyMapperConfiguration);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var response = _companyMapper.Map<IEnumerable<CompanyResponse>>(await _companyService.GetAllAsync());
            return Ok(response);
        }

        [HttpGet]
        public IActionResult Get(string companyName, string countryName, int offset, int limit)
        {
            var response = _companyMapper.Map<IEnumerable<CompanyResponse>>(_companyService.GetFilteredCompanies(offset, limit, companyName, countryName));
            return Ok(response);
        }

        [HttpGet("count")]
        public IActionResult GetCount(string companyName, string countryName)
        {
            int response = _companyService.GetFilteredCompaniesCount(companyName, countryName);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = _companyMapper.Map<CompanyDetails>(await _companyService.GetByIdAsync(id));
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
