using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.PlaceTypeModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaceTypesController : ControllerBase
    {
        private readonly IDataService<PlaceType> _placeTypeService;
        private readonly Mapper _placeTypeMapper;

        public PlaceTypesController(IDataService<PlaceType> placeTypeService, ApiMappingsConfiguration conf)
        {
            _placeTypeService = placeTypeService;
            _placeTypeMapper = new Mapper(conf.PlaceTypeMapperConfiguration);
        }

        // GET: api/<PlaceTypesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = _placeTypeMapper.Map<IEnumerable<PlaceTypeResponse>>(await _placeTypeService.GetAllAsync());
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        // GET api/<PlaceTypesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = _placeTypeMapper.Map<PlaceTypeResponse>(await _placeTypeService.GetByIdAsync(id));
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        // POST api/<PlaceTypesController>
        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PlaceTypeRegistration value)
        {
            await _placeTypeService.PostAsync(_placeTypeMapper.Map<PlaceType>(value));
            return Ok();
        }

        // PUT api/<PlaceTypesController>/5
        [Authorize(Policy = "AdminApp")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PlaceTypeRegistration value)
        {
            await _placeTypeService.UpdateAsync(id, _placeTypeMapper.Map<PlaceType>(value));
            return Ok();
        }

        // DELETE api/<PlaceTypesController>/5
        [Authorize(Policy = "AdminApp")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _placeTypeService.DeleteAsync(id);
            return Ok();
        }
    }
}
