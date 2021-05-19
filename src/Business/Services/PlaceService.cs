using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
            return _placeMapper.Map<IEnumerable<Place>>(await _places.GetAllAsync());
        }

        public async Task<Place> GetByIdAsync(int id)
        {
            if (!(await _places.IsExistingAsync(id)))
                throw new Exception($"No such place with id: {id}");
            return _placeMapper.Map<Place>(await _places.GetAsync(id));
        }

        public async Task PostAsync(Place item)
        {
            if (_places.Find(x => x.AirplaneId == item.AirplaneId && x.Row == item.Row && x.Column == item.Column).Any())
                throw new Exception("Such place is already exist");
            await _places.CreateAsync(_placeMapper.Map<PlaceEntity>(item));
        }

        public async Task DeleteAsync(int id)
        {
            if (!(await _places.IsExistingAsync(id)))
                throw new Exception("No such place");
            await _places.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, Place item)
        {
            if (!(await _places.IsExistingAsync(id)))
                throw new Exception("No such place");
            await _places.UpdateAsync(id, _placeMapper.Map<PlaceEntity>(item));
        }
    }
}
