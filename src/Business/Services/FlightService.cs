using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using PlaneTicketReservationSystem.Business.Exceptions;
using PlaneTicketReservationSystem.Business.Interfaces;
using PlaneTicketReservationSystem.Business.Models;
using PlaneTicketReservationSystem.Data.Entities;
using PlaneTicketReservationSystem.Data.Interfaces;

namespace PlaneTicketReservationSystem.Business.Services
{
    public class FlightService : IFlightService
    {
        private readonly IFlightRepository _flights;

        private readonly IMapper _flightMapper;

        public FlightService(IFlightRepository flights, IMapper mapper)
        {
            _flights = flights;
            _flightMapper = mapper;
        }

        public IEnumerable<Flight> GetFilteredFlights(int offset, int limit, string departureCity, string arrivalCity)
        {
            Expression<Func<FlightEntity, bool>> predicate = f =>
                (string.IsNullOrEmpty(departureCity) || f.From.City.Name.Contains(departureCity))
                && (string.IsNullOrEmpty(arrivalCity) || f.To.City.Name.Contains(arrivalCity));
            var result = _flights.FindWithLimitAndOffset(predicate, offset, limit);
            var flight = _flightMapper.Map<IEnumerable<Flight>>(result);
            return flight;
        }

        public int GetFilteredFlightsCount(string departureCity, string arrivalCity)
        {
            Expression<Func<FlightEntity, bool>> predicate = f =>
                (string.IsNullOrEmpty(departureCity) || f.From.City.Name.Contains(departureCity))
                && (string.IsNullOrEmpty(arrivalCity) || f.To.City.Name.Contains(arrivalCity));
            IQueryable<FlightEntity> flightsEntities = _flights.Find(predicate);
            int count = flightsEntities.Count();
            return count;
        }

        public async Task<Flight> GetByIdAsync(Guid id)
        {
            FlightEntity flightEntity = await _flights.GetAsync(id);
            if (flightEntity == null)
            {
                throw new ElementNotFoundException($"No such flight with id: {id}");
            }
            var flight = _flightMapper.Map<Flight>(flightEntity);
            return flight;
        }

        public async Task PostAsync(Flight item)
        {
            bool isFlightExisting = _flights.Find(x => x.AirplaneId == item.AirplaneId).Any();
            if (isFlightExisting)
            {
                throw new ElementAlreadyExistException($"Flight with airplane id: {item.AirplaneId} is already exist");
            }
            var flightEntity = _flightMapper.Map<FlightEntity>(item);
            await _flights.CreateAsync(flightEntity);
        }

        public async Task DeleteAsync(Guid id)
        {
            bool isFlightExisting = await _flights.IsExistingAsync(id);
            if (!isFlightExisting)
            {
                throw new ElementNotFoundException($"No such flight with id: {id}");
            }
            await _flights.DeleteAsync(id);
        }

        public async Task UpdateAsync(Guid id, Flight item)
        {
            bool isFlightExisting = await _flights.IsExistingAsync(id);
            if (!isFlightExisting)
            {
                throw new ElementNotFoundException($"No such flight with id: {id}");
            }
            item.Id = id;
            var flightEntity = _flightMapper.Map<FlightEntity>(item);
            await _flights.UpdateAsync(flightEntity);
        }
    }
}
