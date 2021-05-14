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
    public class FlightService : IDataService<Flight>
    {
        private readonly FlightRepository _flights;
        private readonly Mapper _flightMapper;

        public FlightService(ReservationSystemContext context, BusinessMappingsConfiguration conf)
        {
            _flights = new FlightRepository(context);
            _flightMapper = new Mapper(conf.AirlineConfiguration);
        }

        public async Task<IEnumerable<Flight>> GetAllAsync()
        {
            return _flightMapper.Map<IEnumerable<Flight>>(await _flights.GetAllAsync());
        }

        public async Task<Flight> GetByIdAsync(int id)
        {
            if (!_flights.Find(x => x.Id == id).Any())
                throw new Exception($"No such flight with id: {id}");
            return _flightMapper.Map<Flight>(await _flights.GetAsync(id));
        }

        public async Task PostAsync(Flight item)
        {
            if (_flights.Find(x => x.AirplaneId == item.AirplaneId).Any())
                throw new Exception($"Flight with airplane id: {item.AirplaneId} is already exist");
            await _flights.CreateAsync(_flightMapper.Map<FlightEntity>(item));
        }

        public async Task DeleteAsync(int id)
        {
            if (!_flights.Find(x => x.Id == id).Any())
                throw new Exception($"No such flight with id: {id}");
            await _flights.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, Flight item)
        {
            if (!(await _flights.IsExistingAsync(id)))
                throw new Exception($"No such flight with id: {id}");
            await _flights.UpdateAsync(id, _flightMapper.Map<FlightEntity>(item));
        }
    }
}
