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
    public class AirportService : IDataService<Airport>
    {
        private readonly AirportRepository _airports;
        private readonly Mapper _airportMapper;

        public AirportService(ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _airports = new AirportRepository(context);
            _airportMapper = new Mapper(conf.AirlineConfiguration);
        }

        public async Task<IEnumerable<Airport>> GetAllAsync()
        {
            return _airportMapper.Map<IEnumerable<Airport>>(await _airports.GetAllAsync());
        }

        public async Task<Airport> GetByIdAsync(int id)
        {
            if (!_airports.Find(x => x.Id == id).Any())
                throw new Exception($"No such airport with id: {id}");
            return _airportMapper.Map<Airport>(await _airports.GetAsync(id));
        }

        public async Task PostAsync(Airport item)
        {
            if (_airports.Find(x => x.Name == item.Name).Any())
                throw new Exception($"Airport {item.Name} is already exist");
            await _airports.CreateAsync(_airportMapper.Map<AirportEntity>(item));
        }

        public async Task DeleteAsync(int id)
        {
            if (!_airports.Find(x => x.Id == id).Any())
                throw new Exception($"No such airport with id: {id}");
            await _airports.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, Airport item)
        {
            if (!(await _airports.IsExistingAsync(id)))
                throw new Exception($"No such airport with id: {id}");
            await _airports.UpdateAsync(id, _airportMapper.Map<AirportEntity>(item));
        }
    }
}
