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
            var result = _flights.FindWithLimitAndOffset(x => (string.IsNullOrEmpty(departureCity) || x.From.City.Name == departureCity)
                                                                    && (string.IsNullOrEmpty(arrivalCity) || x.To.City.Name == arrivalCity), offset, limit);
            var flight = _flightMapper.Map<IEnumerable<Flight>>(result);
            return flight;
        }

        public int GetFilteredFlightsCount(string departureCity, string arrivalCity)
        {
            int count = _flights.Find(x => (string.IsNullOrEmpty(departureCity) || x.From.City.Name == departureCity)
                                           && (string.IsNullOrEmpty(arrivalCity) || x.To.City.Name == arrivalCity)).Count();
            return count;
        }

        public async Task<Flight> GetByIdAsync(int id)
        {
            bool isFlightExisting = await _flights.IsExistingAsync(id);
            if (!isFlightExisting)
            {
                throw new ElementNotFoundException($"No such flight with id: {id}");
            }
            var flight = _flightMapper.Map<Flight>(await _flights.GetAsync(id));
            return flight;
        }

        public async Task PostAsync(Flight item)
        {
            bool isFlightExisting = _flights.Find(x => x.AirplaneId == item.AirplaneId).Any();
            if (isFlightExisting)
            {
                throw new ElementAlreadyExistException($"Flight with airplane id: {item.AirplaneId} is already exist");
            }
            await _flights.CreateAsync(_flightMapper.Map<FlightEntity>(item));
        }

        public async Task DeleteAsync(int id)
        {
            bool isFlightExisting = await _flights.IsExistingAsync(id);
            if (!isFlightExisting)
            {
                throw new ElementNotFoundException($"No such flight with id: {id}");
            }
            await _flights.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, Flight item)
        {
            bool isFlightExisting = await _flights.IsExistingAsync(id);
            if (!isFlightExisting)
            {
                throw new ElementNotFoundException($"No such flight with id: {id}");
            }
            item.Id = id;
            await _flights.UpdateAsync(_flightMapper.Map<FlightEntity>(item));
        }
    }
}
