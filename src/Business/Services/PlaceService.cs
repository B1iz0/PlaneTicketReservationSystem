using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Exceptions;
using PlaneTicketReservationSystem.Business.Helpers;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Repositories;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class PlaceService : IDataService<Place>
    {
        private readonly PlaceRepository _places;
        private readonly Mapper _placeMapper;

        public PlaceService(ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _places = new PlaceRepository(context);
            _placeMapper = new Mapper(conf.AirlineConfiguration);
        }

        public async Task<IEnumerable<Place>> GetAllAsync()
        {
            var places = _placeMapper.Map<IEnumerable<Place>>(await _places.GetAllAsync());
            return places;
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

        public async Task DeleteAsync(int id)
        {
            bool isPlaceExisting = await _places.IsExistingAsync(id);
            if (!isPlaceExisting)
            {
                throw new ElementNotFoundException("No such place");
            }
            await _places.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, Place item)
        {
            bool isPlaceExisting = await _places.IsExistingAsync(id);
            if (!isPlaceExisting)
            {
                throw new ElementNotFoundException("No such place");
            }
            await _places.UpdateAsync(id, _placeMapper.Map<PlaceEntity>(item));
        }
    }
}
