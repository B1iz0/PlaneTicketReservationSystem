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
            bool isPlaceExisting = await _places.IsExistingAsync(id);
            if (!isPlaceExisting)
            {
                throw new ElementNotFoundException($"No such place with id: {id}");
            }
            var place = _placeMapper.Map<Place>(await _places.GetAsync(id));
            return place;
        }

        public async Task PostAsync(Place item)
        {
            bool isPlaceExisting = _places.Find(x => x.AirplaneId == item.AirplaneId && x.Row == item.Row && x.Column == item.Column).Any();
            if (isPlaceExisting)
            {
                throw new ElementAlreadyExistException("Such place is already exist");
            }
            await _places.CreateAsync(_placeMapper.Map<PlaceEntity>(item));
        }
    }
}
