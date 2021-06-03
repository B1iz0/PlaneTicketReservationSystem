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
            var airports = _airportMapper.Map<IEnumerable<Airport>>(await _airports.GetAllAsync());
            return airports;
        }

        public async Task<Airport> GetByIdAsync(int id)
        {
            bool isAirportExisting = await _airports.IsExistingAsync(id);
            if (!isAirportExisting)
            {
                throw new ElementNotFoundException($"No such airport with id: {id}");
            }

            var airport = _airportMapper.Map<Airport>(await _airports.GetAsync(id));
            return airport;
        }

        public async Task PostAsync(Airport item)
        {
            bool isAirportExisting = _airports.Find(x => x.Name == item.Name).Any();
            if (isAirportExisting)
            {
                throw new ElementAlreadyExistException($"Airport {item.Name} is already exist");
            }
            await _airports.CreateAsync(_airportMapper.Map<AirportEntity>(item));
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
            await _airports.UpdateAsync(_airportMapper.Map<AirportEntity>(item));
        }
    }
}
