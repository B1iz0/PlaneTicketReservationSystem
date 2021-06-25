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
    public class AirportService : IAirportService
    {
        private readonly IAirportRepository _airports;

        private readonly IMapper _airportMapper;

        public AirportService(IAirportRepository airports, IMapper mapper)
        {
            _airports = airports;
            _airportMapper = mapper;
        }

        public async Task<IEnumerable<Airport>> GetAllAsync()
        {
            var airports = _airportMapper.Map<IEnumerable<Airport>>(await _airports.GetAllAsync());
            return airports;
        }

        public async Task PostAsync(Airport item)
        {
            bool isAirportExisting = _airports.Find(x => x.Name == item.Name).Any();
            if (isAirportExisting)
            {
                throw new ElementAlreadyExistException($"Airport {item.Name} is already exist");
            }
            var airportEntity = _airportMapper.Map<AirportEntity>(item);
            await _airports.CreateAsync(airportEntity);
        }

        public async Task DeleteAsync(int id)
        {
            bool isAirportExisting = await _airports.IsExistingAsync(id);
            if (!isAirportExisting)
            {
                throw new ElementNotFoundException($"No such airport with id: {id}");
            }
            await _airports.DeleteAsync(id);
        }

        public async Task UpdateAsync(int id, Airport item)
        {
            bool isAirportExisting = await _airports.IsExistingAsync(id);
            if (!isAirportExisting)
            {
                throw new ElementNotFoundException($"No such airport with id: {id}");
            }
            item.Id = id;
            var airportEntity = _airportMapper.Map<AirportEntity>(item);
            await _airports.UpdateAsync(airportEntity);
        }
    }
}
