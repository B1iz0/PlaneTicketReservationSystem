using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Exceptions;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class PlaceService : IPlaceService
    {
        private readonly IPlaceRepository _places;

        private readonly IMapper _placeMapper;

        public PlaceService(IPlaceRepository places, IMapper mapper)
        {
            _places = places;
            _placeMapper = mapper;
        }

        public async Task<Place> GetByIdAsync(int id)
        {
            PlaceEntity placeEntity = await _places.GetAsync(id);
            if (placeEntity == null)
            {
                throw new ElementNotFoundException($"No such place with id: {id}");
            }
            var place = _placeMapper.Map<Place>(placeEntity);
            return place;
        }

        public async Task PostAsync(Place item)
        {
            bool isPlaceExisting = _places.Find(x => x.AirplaneId == item.AirplaneId && x.Row == item.Row && x.Column == item.Column).Any();
            if (isPlaceExisting)
            {
                throw new ElementAlreadyExistException("Such place is already exist");
            }
            var placeEntity = _placeMapper.Map<PlaceEntity>(item);
            await _places.CreateAsync(placeEntity);
        }
    }
}
