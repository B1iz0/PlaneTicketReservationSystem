using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.PlaceModels;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IDataService<Place> _placeService;
        private readonly Mapper _placeMapper;

        public PlacesController(IDataService<Place> placeService, ApiMappingsConfiguration conf)
        {
            _placeService = placeService;
            _placeMapper = new Mapper(conf.PlaceMapperConfiguration);
        }

        // GET: api/<PlacesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = _placeMapper.Map<IEnumerable<PlaceResponse>>(await _placeService.GetAllAsync());
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        // GET api/<PlacesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = _placeMapper.Map<PlaceResponse>(await _placeService.GetByIdAsync(id));
            if (response == null)
                return BadRequest();
            return Ok(response);
        }

        // POST api/<PlacesController>
        [Authorize(Policy = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PlaceRegistration value)
        {
            await _placeService.PostAsync(_placeMapper.Map<Place>(value));
            return Ok();
        }

        // PUT api/<PlacesController>/5
        [Authorize(Policy = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PlaceRegistration value)
        {
            await _placeService.UpdateAsync(id, _placeMapper.Map<Place>(value));
            return Ok();
        }

        // DELETE api/<PlacesController>/5
        [Authorize(Policy = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _placeService.DeleteAsync(id);
            return Ok();
        }
    }
}
