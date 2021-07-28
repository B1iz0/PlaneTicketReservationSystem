using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Models.SearchFilters;
using PlaneTicketReservationSystem.Business.Models.SearchHints;
using PlaneTicketReservationSystem.ReservationSystemApi.Helpers;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Company;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.SearchFilters;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.SearchHints;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        private readonly Mapper _companyMapper;

        private readonly IMapper _mapper;

        public CompaniesController(ICompanyService service, ApiMappingsConfiguration conf, IMapper mapper)
        {
            _companyService = service;
            _companyMapper = new Mapper(conf.CompanyMapperConfiguration);
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var response = _companyMapper.Map<IEnumerable<CompanyResponseModel>>(await _companyService.GetAllAsync());
            return Ok(response);
        }

        [HttpGet]
        public IActionResult Get([FromQuery] CompanyFilterModel filter, int offset, int limit)
        {
            IEnumerable<Company> companies = _companyService.GetFilteredCompanies(_mapper.Map<CompanyFilter>(filter), offset, limit);
            var response = _companyMapper.Map<IEnumerable<CompanyResponseModel>>(companies);
            return Ok(response);
        }

        [HttpGet("count")]
        public IActionResult GetCount([FromQuery] CompanyFilterModel filter)
        {
            int response = _companyService.GetFilteredCompaniesCount(_mapper.Map<CompanyFilter>(filter));
            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = _companyMapper.Map<CompanyResponseModel>(await _companyService.GetByIdAsync(id));
            return Ok(response);
        }

        [HttpPost]
        [Authorize(Policy = ApiPolicies.AdminAppPolicy)]
        public async Task<IActionResult> Post([FromBody] CompanyRegistrationModel value)
        {
            Company createdCompany = await _companyService.PostAsync(_companyMapper.Map<Company>(value));
            var company = _companyMapper.Map<CompanyResponseModel>(createdCompany);
            return Ok(company);
        }

        [HttpPut("{id:guid}")]
        [Authorize(Policy = ApiPolicies.AdminPolicy)]
        public async Task<IActionResult> Put(Guid id, [FromBody] CompanyRegistrationModel value)
        {
            await _companyService.UpdateAsync(id, _companyMapper.Map<Company>(value));
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Policy = ApiPolicies.AdminAppPolicy)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _companyService.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("hints")]
        public IActionResult GetHints([FromQuery] CompanyFilterModel filter, int offset = 0, int limit = 6)
        {
            IEnumerable<CompanyHint>
                hints = _companyService.GetHints(_mapper.Map<CompanyFilter>(filter), offset, limit);
            var response = _mapper.Map<IEnumerable<CompanyHintModel>>(hints);
            return Ok(hints);
        }
    }
}
