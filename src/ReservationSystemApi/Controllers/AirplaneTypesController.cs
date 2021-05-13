using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneTypeModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplaneTypesController : ControllerBase
    {
        private readonly IDataService<AirplaneType> _airplaneTypeService;
        private readonly Mapper _airplaneTypeMapper;

        public AirplaneTypesController(IDataService<AirplaneType> service, ApiMappingsConfiguration conf)
        {
            _airplaneTypeService = service;
            _airplaneTypeMapper = new Mapper(conf.AirplaneTypeMapperConfiguration);
        }

        // GET: api/<AirplaneTypesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var response = _airplaneTypeMapper.Map<IEnumerable<AirplaneTypeResponse>>(_airplaneTypeService.GetAll());
                if (response == null)
                    return BadRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<AirplaneTypesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var response = _airplaneTypeMapper.Map<AirplaneTypeDetails>(_airplaneTypeService.GetById(id));
                if (response == null)
                    return BadRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AirplaneTypesController>
        [HttpPost]
        [Authorize(Policy = "AdminApp")]
        public IActionResult Post([FromBody] AirplaneTypeRegistration value)
        {
            try
            {
                _airplaneTypeService.Post(_airplaneTypeMapper.Map<AirplaneType>(value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AirplaneTypesController>/5
        [HttpPut("{id}")]
        [Authorize(Policy = "AdminApp")]
        public IActionResult Put(int id, [FromBody] AirplaneTypeRegistration value)
        {
            try
            {
                _airplaneTypeService.Update(id, _airplaneTypeMapper.Map<AirplaneType>(value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AirplaneTypesController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "AdminApp")]
        public IActionResult Delete(int id)
        {
            try
            {
                _airplaneTypeService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
