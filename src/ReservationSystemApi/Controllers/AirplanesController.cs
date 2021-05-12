using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Business.Services;
using PlaneTicketReservationSystem.ReservationSystemApi.Mappers;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.AirplaneModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirplanesController : ControllerBase
    {
        private readonly IDataService<Airplane> _airplaneService;
        private readonly Mapper _airplaneMapper;

        public AirplanesController(IDataService<Airplane> service, ApiMappingsConfiguration conf)
        {
            _airplaneService = service;
            _airplaneMapper = new Mapper(conf.AirplaneMapperConfiguration);
        }

        // GET: api/<AirplanesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var response = _airplaneMapper.Map<IEnumerable<AirplaneResponse>>(_airplaneService.GetAll());
                if (response == null)
                    return BadRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<AirplanesController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var response = _airplaneMapper.Map<AirplaneDetails>(_airplaneService.GetById(id));
                if (response == null)
                    return BadRequest();
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<AirplanesController>
        [HttpPost]
        [Authorize(Policy = "Admin")]
        public IActionResult Post([FromBody] AirplaneRegistration value)
        {
            try
            {
                _airplaneService.Post(_airplaneMapper.Map<Airplane>(value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<AirplanesController>/5
        [HttpPut("{id}")]
        [Authorize(Policy = "Admin")]
        public IActionResult Put(int id, [FromBody] AirplaneRegistration value)
        {
            try
            {
                _airplaneService.Update(id, _airplaneMapper.Map<Airplane>(value));
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<AirplanesController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = "Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                _airplaneService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
