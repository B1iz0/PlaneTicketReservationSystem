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

        // GET: api/<CompaniesController>
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                var response = _companyMapper.Map<IEnumerable<CompanyResponse>>(await _companyService.GetAllAsync());
                if (response == null)
                    return BadRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<CompaniesController>/5
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var response = _companyMapper.Map<CompanyDetails>(await _companyService.GetByIdAsync(id));
                if (response == null)
                    return BadRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<CompaniesController>
        [HttpPost]
        [Authorize(Policy = "AdminApp")]
        public async Task<IActionResult> Post([FromBody] CompanyRegistration value)
        {
            try
            {
                await _companyService.PostAsync(_companyMapper.Map<Company>(value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CompaniesController>/5
        [HttpPut("{id}")]
        [Authorize(Policy = "Admin")]
        public async Task<IActionResult> Put(int id, [FromBody] CompanyRegistration value)
        {
            try
            {
                await _companyService.UpdateAsync(id, _companyMapper.Map<Company>(value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CompaniesController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminApp")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _companyService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
