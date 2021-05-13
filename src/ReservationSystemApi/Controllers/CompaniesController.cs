using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
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
            try
            {
                var response = _companyMapper.Map<IEnumerable<CompanyResponse>>(_companyService.GetAll());
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
        public IActionResult Get(int id)
        {
            try
            {
                var response = _companyMapper.Map<CompanyDetails>(_companyService.GetById(id));
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
        [Authorize]
        public IActionResult Post([FromBody] CompanyRegistration value)
        {
            try
            {
                _companyService.Post(_companyMapper.Map<Company>(value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CompaniesController>/5
        [HttpPut("{id}")]
        [Authorize]
        public IActionResult Put(int id, [FromBody] CompanyRegistration value)
        {
            try
            {
                _companyService.Update(id, _companyMapper.Map<Company>(value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CompaniesController>/5
        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                _companyService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
