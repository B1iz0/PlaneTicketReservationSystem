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

        public IEnumerable<Airport> GetFilteredAirports(string company, string airportName, string city, string country, int offset, int limit)
        {
            Expression<Func<AirportEntity, bool>> predicate = airport =>
                (string.IsNullOrEmpty(company) || airport.Company.Name.Contains(company))
                && (string.IsNullOrEmpty(airportName) || airport.Name.Contains(airportName))
                && (string.IsNullOrEmpty(city) || airport.City.Name.Contains(city))
                && (string.IsNullOrEmpty(country) || airport.City.Country.Name.Contains(country));
            var result = _airports.FindWithLimitAndOffset(predicate, offset, limit);
            var airports = _airportMapper.Map<IEnumerable<Airport>>(result);
            return airports;
        }

        public int GetFilteredAirportsCount(string company, string airportName, string city, string country)
        {
            Expression<Func<AirportEntity, bool>> predicate = airport =>
                (string.IsNullOrEmpty(company) || airport.Company.Name.Contains(company))
                && (string.IsNullOrEmpty(airportName) || airport.Name.Contains(airportName))
                && (string.IsNullOrEmpty(city) || airport.City.Name.Contains(city))
                && (string.IsNullOrEmpty(country) || airport.City.Country.Name.Contains(country));
            IQueryable<AirportEntity> airportsEntities = _airports.Find(predicate);
            int count = airportsEntities.Count();
            return count;
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

        public async Task DeleteAsync(Guid id)
        {
            bool isAirportExisting = await _airports.IsExistingAsync(id);
            if (!isAirportExisting)
            {
                throw new ElementNotFoundException($"No such airport with id: {id}");
            }
            await _airports.DeleteAsync(id);
        }

        public async Task UpdateAsync(Guid id, Airport item)
        {
            item.Id = id;
            var airportEntity = _airportMapper.Map<AirportEntity>(item);
            await _airports.UpdateAsync(airportEntity);
        }
    }
}
