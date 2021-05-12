using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.CodeAnalysis.CSharp.Syntax;
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

        public IEnumerable<Airport> GetAll()
        {
            return _airportMapper.Map<IEnumerable<Airport>>(_airports.GetAll());
        }

        public Airport GetById(int id)
        {
            if (!_airports.Find(x => x.Id == id).Any())
                throw new Exception($"No such airport with id: {id}");
            return _airportMapper.Map<Airport>(_airports.Get(id));
        }

        public void Post(Airport item)
        {
            if (_airports.Find(x => x.Name == item.Name).Any())
                throw new Exception($"Airport {item.Name} is already exist");
            _airports.Create(_airportMapper.Map<AirportEntity>(item));
        }

        public void Delete(int id)
        {
            if (!_airports.Find(x => x.Id == id).Any())
                throw new Exception($"No such airport with id: {id}");
            _airports.Delete(id);
        }

        public void Update(int id, Airport item)
        {
            if (!_airports.Find(x => x.Id == id).Any())
                throw new Exception($"No such airport with id: {id}");
            _airports.Update(id, _airportMapper.Map<AirportEntity>(item));
        }
    }
}
