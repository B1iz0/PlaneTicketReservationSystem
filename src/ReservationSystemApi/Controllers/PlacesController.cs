using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.ReservationSystemApi.Mapping;
using PlaneTicketReservationSystem.ReservationSystemApi.Models.Place;

namespace PlaneTicketReservationSystem.ReservationSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlacesController : ControllerBase
    {
        private readonly IPlaceService _placeService;

        private readonly Mapper _placeMapper;

        public PlacesController(IPlaceService placeService, ApiMappingsConfiguration conf)
        {
            _placeService = placeService;
            _placeMapper = new Mapper(conf.PlaceMapperConfiguration);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = _placeMapper.Map<PlaceResponseModel>(await _placeService.GetByIdAsync(id));
            return Ok(response);
        }
    }
}
