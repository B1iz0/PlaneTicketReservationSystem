using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Services;
using PlaneTicketReservationSystem.ReservationSystemApi.Mappers;
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

        // GET: api/<CompaniesController>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var response = _companyMapper.Map<IEnumerable<CompanyResponse>>(_companyService.GetAll());
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        // GET api/<CompaniesController>/5
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var response = _companyMapper.Map<CompanyResponse>(_companyService.GetById(id));
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        // POST api/<CompaniesController>
        [HttpPost]
        [Authorize]
        public void Post([FromBody] CompanyRegistration value)
        {
            _companyService.Post(_companyMapper.Map<Company>(value));
        }

        // PUT api/<CompaniesController>/5
        [HttpPut("{id}")]
        [Authorize]
        public void Put(int id, [FromBody] CompanyRegistration value)
        {
            _companyService.Update(id, _companyMapper.Map<Company>(value));
        }

        // DELETE api/<CompaniesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public void Delete(int id)
        {
            _companyService.Delete(id);
        }
    }
}
